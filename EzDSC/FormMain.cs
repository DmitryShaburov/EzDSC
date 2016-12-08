using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Policy;

namespace EzDSC
{
    public partial class FormMain : Form
    {
        private DscRepository _repository;
        private RepositoryWorker _repositoryWorker;
        private EzSettings _settings;

        public FormMain()
        {
            InitializeComponent();
        }

        // Create new configuration item
        private void miResourceTypeNewConfigurationItem_Click(object sender, EventArgs e)
        {
            DscResource parent = (treeLibrary.SelectedNode.Tag as DscResource);

            DialogText nameDialog = new DialogText();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBoxWorker.SameItemExists(this, Strings.UI_Text_ConfigurationItemC);
                return;
            }

            DscConfigurationItemNode configurationItemNode =
                _repositoryWorker.NewConfigurationItemNode(nameDialog.InputResult, parent);
            if (configurationItemNode == null) return;

            treeLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(configurationItemNode.Name, configurationItemNode, 1,
                menuConfigurationItem, treeLibrary.SelectedNode);
        }

        // Create new role
        private void createRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscRoleGroup parent = (treeLibrary.SelectedNode.Tag as DscRoleGroup);

            DialogText nameDialog = new DialogText();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBoxWorker.SameItemExists(this, Strings.UI_Text_RoleOrGroupC);
                return;
            }

            DscRoleNode roleNode = _repositoryWorker.NewRoleNode(nameDialog.InputResult, parent);
            if (roleNode == null) return;

            treeLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(roleNode.Name, roleNode, 1, menuRole,
                treeLibrary.SelectedNode);
        }

        // Create new roles group
        private void miRolesNewGroup_Click(object sender, EventArgs e)
        {
            DscRoleGroup parent = (treeLibrary.SelectedNode.Tag as DscRoleGroup);

            DialogText nameDialog = new DialogText();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBoxWorker.SameItemExists(this, Strings.UI_Text_RoleOrGroupC);
                return;
            }

            DscRoleGroup roleGroup = _repositoryWorker.NewRoleGroup(nameDialog.InputResult, parent);
            if (roleGroup == null) return;

            treeLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(roleGroup.Name, roleGroup, 0, menuRoleGroup,
                treeLibrary.SelectedNode);
        }

        // Create new server
        private void miServersNewServer_Click(object sender, EventArgs e)
        {
            DscServerNode parent = (treeLibrary.SelectedNode.Tag as DscServerNode);
            if (parent == null) return;

            DialogText nameDialog = new DialogText();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBoxWorker.SameItemExists(this, Strings.UI_Text_ServerOrGroupC);
                return;
            }

            DscServerNode serverNode = _repositoryWorker.NewServerNode(nameDialog.InputResult,
                DscServerNode.ServerType.Server, parent);

            treeLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(serverNode.Name, serverNode, 2, menuServer,
                treeLibrary.SelectedNode);
        }

        // Create new Servers Group
        private void miServersNewGroup_Click(object sender, EventArgs e)
        {
            DscServerNode parent = (treeLibrary.SelectedNode.Tag as DscServerNode);

            DialogText nameDialog = new DialogText();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBoxWorker.SameItemExists(this, Strings.UI_Text_ServerOrGroupC);
                return;
            }

            DscServerNode serverNode = _repositoryWorker.NewServerNode(nameDialog.InputResult,
                DscServerNode.ServerType.Group, parent);

            treeLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(serverNode.Name, serverNode, 0, menuServerGroup,
                treeLibrary.SelectedNode);
        }

        // Fills TreeView with modules, resources and configuration items from current repository
        private void FillResourceTree()
        {
            foreach (DscModule module in _repository.Modules)
            {
                TreeNode moduleNode = TreeViewWorker.TreeNodeAdd(module.Name, module, 0, null,
                    treeLibrary.Nodes["tviResources"]);

                foreach (DscResource resource in module.Resources)
                {
                    TreeNode resourceNode = TreeViewWorker.TreeNodeAdd(resource.FriendlyName, resource, 0,
                        menuResource, moduleNode);

                    foreach (DscConfigurationItemNode configurationItem in resource.Nodes)
                    {
                        TreeViewWorker.TreeNodeAdd(configurationItem.Name, configurationItem, 1, menuConfigurationItem,
                            resourceNode);
                    }
                }
               
            }
        }

        // Fill TreeView recursively with roles from current repository
        private void FillRoleTree(DscRoleGroup group, TreeNode treeNode)
        {
            treeNode.Tag = group;
            foreach (DscRoleNode childRole in group.Nodes)
            {
                TreeViewWorker.TreeNodeAdd(childRole.Name, childRole, 1, menuRole, treeNode);
            }
            foreach (DscRoleGroup childGroup in group.Groups)
            {
                TreeNode groupNode = TreeViewWorker.TreeNodeAdd(childGroup.Name, childGroup, 0, menuRoleGroup, treeNode);
                FillRoleTree(childGroup, groupNode);
            }
        }

        // Fill TreeView recursively with servers from current repository
        private void FillServerTree(DscServerNode serverNode, TreeNode treeNode)
        {
            treeNode.Tag = serverNode;
            foreach (DscServerNode child in serverNode.Nodes)
            {
                if (child.Type != DscServerNode.ServerType.Group)
                {
                    TreeViewWorker.TreeNodeAdd(child.Name, child, 2, menuServer, treeNode);
                }
                else
                {
                    TreeNode childNode = TreeViewWorker.TreeNodeAdd(child.Name, child, 2, menuServerGroup, treeNode);
                    FillServerTree(child, childNode);
                }
            }
        }

        // Execute Unblock-File on all locked modules in current repository
        private void UnblockModules()
        {
            string[] allFiles = Directory.GetFiles(_repository.Dir.Modules, "*", SearchOption.AllDirectories);

            List<string> blockedFiles = (from file in allFiles
                let uri = new Uri(file)
                let zone = Zone.CreateFromUrl(uri.AbsoluteUri)
                where zone.SecurityZone != SecurityZone.MyComputer
                select file).ToList();
            if (blockedFiles.Count == 0) return;

            string filename = FileSystem.GetTempFile();
            File.WriteAllLines(filename, PsCodeBuilder.BuildUnblockFile(blockedFiles));
            PsRunner.Start(filename);
        }

        // Load DscRepository from specific path and fill UI
        private void LoadRepository(string path)
        {
            _repository = new DscRepository(path);
            _repositoryWorker = new RepositoryWorker(_repository);

            treeLibrary.Nodes["tviResources"].Nodes.Clear();
            treeLibrary.Nodes["tviRoles"].Nodes.Clear();
            treeLibrary.Nodes["tviServers"].Nodes.Clear();

            FillResourceTree();
            FillRoleTree(_repository.Roles, treeLibrary.Nodes["tviRoles"]);
            FillServerTree(_repository.Servers, treeLibrary.Nodes["tviServers"]);

            UnblockModules();
            ModuleWorker.InstallLocalModules(_repository);
        }

        // Hide all selected item specific controls
        private void HideControls()
        {
            panelRole.Hide();
            panelServer.Hide();
            panelConfigurationItem.Hide();
        }

        // Main application init code
        private void fMain_Load(object sender, EventArgs e)
        {
            // Setting default controls state
            panelRole.Dock = DockStyle.Fill;
            panelServer.Dock = DockStyle.Fill;
            panelConfigurationItem.Dock = DockStyle.Fill;
            HideControls();

            // Loading application settings
            _settings = EzSettings.Load();
            Size = _settings.WindowSize;
            WindowState = _settings.WindowState;

            // Loading last opened repository
            if (_settings.LastRepositoryPath == null) return;
            if (Directory.Exists(_settings.LastRepositoryPath))
            {
                LoadRepository(_settings.LastRepositoryPath);
            }
        }

        // Show selected item specific controls
        private void tvLibrary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeLibrary.SelectedNode.Tag == null) return;
            Type selectedType = treeLibrary.SelectedNode.Tag.GetType();

            HideControls();

            if (selectedType == typeof(DscConfigurationItemNode))
            {
                DscConfigurationItemNode configurationItemNode = (treeLibrary.SelectedNode.Tag as DscConfigurationItemNode);
                if (configurationItemNode == null) return;

                panelConfigurationItem.Show();
                gridConfigurationItem.SelectedObject = new DictionaryPropertyGridAdapter(configurationItemNode.ConfigurationItem.Properties, configurationItemNode.Parent);
                listDependsOn.DataSource = configurationItemNode.ConfigurationItem.DependsOn;
            }

            if (selectedType == typeof(DscRoleNode))
            {
                DscRoleNode roleNode = (treeLibrary.SelectedNode.Tag as DscRoleNode);
                if (roleNode == null) return;

                panelRole.Show();
                listRoleItems.DataSource = roleNode.Role.Resources;
            }

            if (selectedType == typeof(DscServerNode))
            {
                DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
                if (serverNode == null) return;

                panelServer.Show();
                listServerRoles.DataSource = serverNode.Node.Roles;
                gridServerVariables.SelectedObject = new DictionaryPropertyGridAdapter(serverNode.Node.Variables);
            }
        }

        // Export DSC configuration for server node
        private void miBuildConfiguration_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if ((dialogSaveFile.ShowDialog() != DialogResult.OK) || string.IsNullOrWhiteSpace(dialogSaveFile.FileName)) return;

            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            File.WriteAllLines(dialogSaveFile.FileName, PsCodeBuilder.BuildScript(configurations, _repository));
        }

        // Run DSC configuration on server node
        private void miRunConfiguration_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            string filename = FileSystem.GetTempFile();
            
            File.WriteAllLines(filename, PsCodeBuilder.BuildScript(serverNode.GetConfigurations(), _repository));
            PsRunner.Start(filename);
        }

        // Save changes in selected configuration item properties
        private void pgEditor_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscConfigurationItemNode configurationItemNode = (treeLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            if (configurationItemNode == null) return;

            configurationItemNode.Validate();
            configurationItemNode.ConfigurationItem.Save(configurationItemNode.FilePath);
        }

        // Save changes in selected server node variables
        private void pgServerVariables_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
            serverNode?.Node.Save(serverNode.FilePath);
        }

        // Exit application
        private void miFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Load or create repository
        private void miFileNew_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if ((fbd.ShowDialog() != DialogResult.OK) || string.IsNullOrWhiteSpace(fbd.SelectedPath)) return;
            
            LoadRepository(fbd.SelectedPath);
        }

        // Add Configuration Item to Role
        private void tsbRoleAdd_Click(object sender, EventArgs e)
        {
            DscRoleNode roleNode = (treeLibrary.SelectedNode.Tag as DscRoleNode);
            if (roleNode == null) return;

            DialogTree treeDialog = new DialogTree(treeLibrary.Nodes["tviResources"], imagesMain);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscConfigurationItemNode)) return;

            DscConfigurationItemNode configurationItemNode = (treeDialog.SelectedTag as DscConfigurationItemNode);
            if (configurationItemNode == null) return;

            roleNode.Role.Resources.Add(configurationItemNode.GetFullName());
            roleNode.Role.Save(roleNode.FilePath);

            listRoleItems.DataSource = null;
            listRoleItems.DataSource = roleNode.Role.Resources;
        }

        // Remove Configuration Item from Role
        private void tsbRoleRemove_Click(object sender, EventArgs e)
        {
            DscRoleNode roleNode = (treeLibrary.SelectedNode.Tag as DscRoleNode);
            if (roleNode == null) return;

            if (listRoleItems.SelectedItem == null) return;

            roleNode.Role.Resources.Remove(listRoleItems.SelectedItem.ToString());
            roleNode.Role.Save(roleNode.FilePath);

            listRoleItems.DataSource = null;
            listRoleItems.DataSource = roleNode.Role.Resources;
        }
        
        // Add Role to Server Node
        private void tsbServerRoleAdd_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            DialogTree treeDialog = new DialogTree(treeLibrary.Nodes["tviRoles"], imagesMain);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscRoleNode)) return;

            DscRoleNode roleNode = (treeDialog.SelectedTag as DscRoleNode);
            if (roleNode == null) return;

            serverNode.Node.Roles.Add(roleNode.BuildName());
            serverNode.Node.Save(serverNode.FilePath);

            listServerRoles.DataSource = null;
            listServerRoles.DataSource = serverNode.Node.Roles;
        }

        // Remove Role from Server Node
        private void tsbServerRoleRemove_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if (listServerRoles.SelectedItem == null) return;
            
            serverNode.Node.Roles.Remove(listServerRoles.SelectedItem.ToString());
            serverNode.Node.Save(serverNode.FilePath);

            listServerRoles.DataSource = null;
            listServerRoles.DataSource = serverNode.Node.Roles;
        }

        // Add variable to Server or Servers Groups
        private void tsbVariableAdd_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            DialogText nameDialog = new DialogText();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || string.IsNullOrWhiteSpace(nameDialog.InputResult)) return;
            
            string variableName = nameDialog.InputResult.Replace("$", "");
            if (string.IsNullOrWhiteSpace(variableName)) return;

            serverNode.Node.Variables.Add(variableName, "");
            serverNode.Node.Save(serverNode.FilePath);

            gridServerVariables.SelectedObject = new DictionaryPropertyGridAdapter(serverNode.Node.Variables);
        }

        // Remove variable from server or servers group
        private void tsbVariableRemove_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if (gridServerVariables.SelectedGridItem.Label == null) return;

            serverNode.Node.Variables.Remove(gridServerVariables.SelectedGridItem.Label);
            serverNode.Node.Save(serverNode.FilePath);

            gridServerVariables.SelectedObject = new DictionaryPropertyGridAdapter(serverNode.Node.Variables);
        }

        // Add dependency to configuration item
        private void tsbCIAddDepends_Click(object sender, EventArgs e)
        {
            DscConfigurationItemNode currentConfigurationItemNode = (treeLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            if (currentConfigurationItemNode == null) return;

            DialogTree treeDialog = new DialogTree(treeLibrary.Nodes["tviResources"], imagesMain);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscConfigurationItemNode)) return;

            DscConfigurationItemNode selectedConfigurationItemNode = (treeDialog.SelectedTag as DscConfigurationItemNode);
            if (selectedConfigurationItemNode == null) return;

            currentConfigurationItemNode.ConfigurationItem.DependsOn.Add(selectedConfigurationItemNode.GetFullName());
            currentConfigurationItemNode.ConfigurationItem.Save(currentConfigurationItemNode.FilePath);

            listDependsOn.DataSource = null;
            listDependsOn.DataSource = currentConfigurationItemNode.ConfigurationItem.DependsOn;
        }

        // Remove dependency from configuration item
        private void tsbCIRemoveDepends_Click(object sender, EventArgs e)
        {
            DscConfigurationItemNode configurationItemNode = (treeLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            if (configurationItemNode == null) return;

            if (listDependsOn.SelectedItem == null) return;

            configurationItemNode.ConfigurationItem.DependsOn.Remove(listDependsOn.SelectedItem.ToString());
            configurationItemNode.ConfigurationItem.Save(configurationItemNode.FilePath);

            listDependsOn.DataSource = null;
            listDependsOn.DataSource = configurationItemNode.ConfigurationItem.DependsOn;
        }

        // Select TreeViewNode on right click
        private void tvLibrary_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            treeLibrary.SelectedNode = e.Node;
        }

        // Install DSC modules on selected server
        private void installModulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);

            ModuleWorker.InstallModules(_repository, serverNode);

            MessageBoxWorker.Done(this, Strings.UI_Text_ModuleInstallComplete);
        }

        // Delete selected server
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if (MessageBoxWorker.ConfirmDelete(this, Strings.UI_Text_ServerL) != DialogResult.Yes) return;

            _repositoryWorker.RemoveItem(serverNode);

            treeLibrary.Nodes.Remove(treeLibrary.SelectedNode);
        }

        // Delete selected servers group
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (treeLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if (serverNode.Type == DscServerNode.ServerType.Root) return;

            if (MessageBoxWorker.ConfirmDelete(this, Strings.UI_Text_GroupL) != DialogResult.Yes) return;

            _repositoryWorker.RemoveItem(serverNode);

            treeLibrary.Nodes.Remove(treeLibrary.SelectedNode);
        }

        // Delete selected roles group
        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DscRoleGroup roleGroup = (treeLibrary.SelectedNode.Tag as DscRoleGroup);
            if (roleGroup?.Parent == null) return;

            HashSet<string> roleUsages = roleGroup.FindUsages(_repository.Servers);
            if (roleUsages.Count > 0)
            {
                MessageBoxWorker.CannotDeleteAreUsed(this, Strings.UI_Text_CannotDeleteServersGroups, roleUsages);
                return;
            }

            if (MessageBoxWorker.ConfirmDelete(this, Strings.UI_Text_GroupL) != DialogResult.Yes) return;

            _repositoryWorker.RemoveItem(roleGroup);

            treeLibrary.Nodes.Remove(treeLibrary.SelectedNode);
        }

        // Delete selected role
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DscRoleNode roleNode = (treeLibrary.SelectedNode.Tag as DscRoleNode);
            if (roleNode == null) return;

            HashSet<string> roleUsages = roleNode.FindUsages(_repository.Servers);
            if (roleUsages.Count > 0)
            {
                MessageBoxWorker.CannotDeleteAreUsed(this, Strings.UI_Text_CannotDeleteServersGroups, roleUsages);
                return;
            }

            if (MessageBoxWorker.ConfirmDelete(this, Strings.UI_Text_RoleL) != DialogResult.Yes) return;

            _repositoryWorker.RemoveItem(roleNode);

            treeLibrary.Nodes.Remove(treeLibrary.SelectedNode);
        }

        // Delete selected configuration item
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            DscConfigurationItemNode configurationItemNode = (treeLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            if (configurationItemNode == null) return;

            HashSet<string> configurationItemUsages = configurationItemNode.FindUsages(_repository.Roles);
            if (configurationItemUsages.Count > 0)
            {
                MessageBoxWorker.CannotDeleteAreUsed(this, Strings.UI_Text_CannotDeleteRoles, configurationItemUsages);
                return;
            }

            if (MessageBoxWorker.ConfirmDelete(this, Strings.UI_Text_ConfigurationItemL) != DialogResult.Yes) return;

            _repositoryWorker.RemoveItem(configurationItemNode);

            treeLibrary.Nodes.Remove(treeLibrary.SelectedNode);
        }

        // Save application settings
        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _settings.WindowSize = Size;
            _settings.WindowState = WindowState;
            _settings.LastRepositoryPath = _repository?.Dir.Root;
            _settings.Save();
        }
    }
}
