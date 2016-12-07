using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Policy;

namespace EzDSC
{
    // ReSharper disable once InconsistentNaming
    public partial class fMain : Form
    {
        private DscRepository _repository;
        private RepositoryWorker _repositoryWorker;
        private EzSettings _settings;

        public fMain()
        {
            InitializeComponent();
        }

        // Create new configuration item
        private void miResourceTypeNewConfigurationItem_Click(object sender, EventArgs e)
        {
            DscResource parent = (tvLibrary.SelectedNode.Tag as DscResource);

            fModalName nameDialog = new fModalName();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBox.Show(this,
                    string.Concat(Strings.UI_Text_ConfigurationItemC, Strings.UI_Text_SameAlreadyExists),
                    Strings.UI_Caption_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscConfigurationItemNode configurationItemNode =
                _repositoryWorker.NewConfigurationItemNode(nameDialog.InputResult, parent);
            if (configurationItemNode == null) return;

            tvLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(configurationItemNode.Name, configurationItemNode, 1,
                cmConfigurationItem, tvLibrary.SelectedNode);
        }

        // Create new role
        private void createRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscRoleGroup parent = (tvLibrary.SelectedNode.Tag as DscRoleGroup);

            fModalName nameDialog = new fModalName();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBox.Show(this,
                    string.Concat(Strings.UI_Text_RoleOrGroupC, Strings.UI_Text_SameAlreadyExists),
                    Strings.UI_Caption_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscRoleNode roleNode = _repositoryWorker.NewRoleNode(nameDialog.InputResult, parent);
            if (roleNode == null) return;

            tvLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(roleNode.Name, roleNode, 1, cmRoleItem,
                tvLibrary.SelectedNode);
        }

        // Create new roles group
        private void miRolesNewGroup_Click(object sender, EventArgs e)
        {
            DscRoleGroup parent = (tvLibrary.SelectedNode.Tag as DscRoleGroup);

            fModalName nameDialog = new fModalName();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBox.Show(this,
                    string.Concat(Strings.UI_Text_RoleOrGroupC, Strings.UI_Text_SameAlreadyExists),
                    Strings.UI_Caption_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscRoleGroup roleGroup = _repositoryWorker.NewRoleGroup(nameDialog.InputResult, parent);
            if (roleGroup == null) return;

            tvLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(roleGroup.Name, roleGroup, 0, cmRoles,
                tvLibrary.SelectedNode);
        }

        // Create new server
        private void miServersNewServer_Click(object sender, EventArgs e)
        {
            DscServerNode parent = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (parent == null) return;

            fModalName nameDialog = new fModalName();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBox.Show(this,
                    string.Concat(Strings.UI_Text_ServerOrGroupC, Strings.UI_Text_SameAlreadyExists),
                    Strings.UI_Caption_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscServerNode serverNode = _repositoryWorker.NewServerNode(nameDialog.InputResult,
                DscServerNode.ServerType.Server, parent);

            tvLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(serverNode.Name, serverNode, 2, cmServerItem,
                tvLibrary.SelectedNode);
        }

        // Create new Servers Group
        private void miServersNewGroup_Click(object sender, EventArgs e)
        {
            DscServerNode parent = (tvLibrary.SelectedNode.Tag as DscServerNode);

            fModalName nameDialog = new fModalName();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBox.Show(this,
                    string.Concat(Strings.UI_Text_ServerOrGroupC, Strings.UI_Text_SameAlreadyExists),
                    Strings.UI_Caption_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscServerNode serverNode = _repositoryWorker.NewServerNode(nameDialog.InputResult,
                DscServerNode.ServerType.Group, parent);

            tvLibrary.SelectedNode = TreeViewWorker.TreeNodeAdd(serverNode.Name, serverNode, 0, cmServers,
                tvLibrary.SelectedNode);
        }

        // Fills TreeView with modules, resources and configuration items from current repository
        private void FillResourceTree()
        {
            foreach (DscModule module in _repository.Modules)
            {
                TreeNode moduleNode = TreeViewWorker.TreeNodeAdd(module.Name, module, 0, null,
                    tvLibrary.Nodes["tviResources"]);

                foreach (DscResource resource in module.Resources)
                {
                    TreeNode resourceNode = TreeViewWorker.TreeNodeAdd(resource.FriendlyName, resource, 0,
                        cmResourceType, moduleNode);

                    foreach (DscConfigurationItemNode configurationItem in resource.Nodes)
                    {
                        TreeViewWorker.TreeNodeAdd(configurationItem.Name, configurationItem, 1, cmConfigurationItem,
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
                TreeViewWorker.TreeNodeAdd(childRole.Name, childRole, 1, cmRoleItem, treeNode);
            }
            foreach (DscRoleGroup childGroup in group.Groups)
            {
                TreeNode groupNode = TreeViewWorker.TreeNodeAdd(childGroup.Name, childGroup, 0, cmRoles, treeNode);
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
                    TreeViewWorker.TreeNodeAdd(child.Name, child, 2, cmServerItem, treeNode);
                }
                else
                {
                    TreeNode childNode = TreeViewWorker.TreeNodeAdd(child.Name, child, 2, cmServers, treeNode);
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

            tvLibrary.Nodes["tviResources"].Nodes.Clear();
            tvLibrary.Nodes["tviRoles"].Nodes.Clear();
            tvLibrary.Nodes["tviServers"].Nodes.Clear();

            FillResourceTree();
            FillRoleTree(_repository.Roles, tvLibrary.Nodes["tviRoles"]);
            FillServerTree(_repository.Servers, tvLibrary.Nodes["tviServers"]);

            UnblockModules();
            ModuleWorker.InstallLocalModules(_repository);
        }

        // Hide all selected item specific controls
        private void HideControls()
        {
            pRolePanel.Hide();
            scServer.Hide();
            scConfigurationItem.Hide();
        }

        // Main application init code
        private void fMain_Load(object sender, EventArgs e)
        {
            // Setting default controls state
            pRolePanel.Dock = DockStyle.Fill;
            scServer.Dock = DockStyle.Fill;
            scConfigurationItem.Dock = DockStyle.Fill;
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
            if (tvLibrary.SelectedNode.Tag == null) return;
            Type selectedType = tvLibrary.SelectedNode.Tag.GetType();

            HideControls();

            if (selectedType == typeof(DscConfigurationItemNode))
            {
                DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
                if (configurationItemNode == null) return;

                scConfigurationItem.Show();
                pgEditor.SelectedObject = new DictionaryPropertyGridAdapter(configurationItemNode.ConfigurationItem.Properties, configurationItemNode.Parent);
                lbCIDependency.DataSource = configurationItemNode.ConfigurationItem.DependsOn;
            }

            if (selectedType == typeof(DscRoleNode))
            {
                DscRoleNode roleNode = (tvLibrary.SelectedNode.Tag as DscRoleNode);
                if (roleNode == null) return;

                pRolePanel.Show();
                lbRole.DataSource = roleNode.Role.Resources;
            }

            if (selectedType == typeof(DscServerNode))
            {
                DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
                if (serverNode == null) return;

                scServer.Show();
                lbServerRoles.DataSource = serverNode.Node.Roles;
                pgServerVariables.SelectedObject = new DictionaryPropertyGridAdapter(serverNode.Node.Variables);
            }
        }

        // Export DSC configuration for server node
        private void miBuildConfiguration_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if ((sfdExportScript.ShowDialog() != DialogResult.OK) || string.IsNullOrWhiteSpace(sfdExportScript.FileName)) return;

            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            File.WriteAllLines(sfdExportScript.FileName, PsCodeBuilder.BuildScript(configurations, _repository));
        }

        // Run DSC configuration on server node
        private void miRunConfiguration_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            string filename = FileSystem.GetTempFile();
            
            File.WriteAllLines(filename, PsCodeBuilder.BuildScript(serverNode.GetConfigurations(), _repository));
            PsRunner.Start(filename);
        }

        // Save changes in selected configuration item properties
        private void pgEditor_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            if (configurationItemNode == null) return;

            configurationItemNode.Validate();
            configurationItemNode.ConfigurationItem.Save(configurationItemNode.FilePath);
        }

        // Save changes in selected server node variables
        private void pgServerVariables_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
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
            DscRoleNode roleNode = (tvLibrary.SelectedNode.Tag as DscRoleNode);
            if (roleNode == null) return;

            fModalTree treeDialog = new fModalTree(tvLibrary.Nodes["tviResources"], ilMain);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscConfigurationItemNode)) return;

            DscConfigurationItemNode configurationItemNode = (treeDialog.SelectedTag as DscConfigurationItemNode);
            if (configurationItemNode == null) return;

            roleNode.Role.Resources.Add(configurationItemNode.GetFullName());
            roleNode.Role.Save(roleNode.FilePath);

            lbRole.DataSource = null;
            lbRole.DataSource = roleNode.Role.Resources;
        }

        // Remove Configuration Item from Role
        private void tsbRoleRemove_Click(object sender, EventArgs e)
        {
            DscRoleNode roleNode = (tvLibrary.SelectedNode.Tag as DscRoleNode);
            if (roleNode == null) return;

            if (lbRole.SelectedItem == null) return;

            roleNode.Role.Resources.Remove(lbRole.SelectedItem.ToString());
            roleNode.Role.Save(roleNode.FilePath);

            lbRole.DataSource = null;
            lbRole.DataSource = roleNode.Role.Resources;
        }
        
        // Add Role to Server Node
        private void tsbServerRoleAdd_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            fModalTree treeDialog = new fModalTree(tvLibrary.Nodes["tviRoles"], ilMain);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscRoleNode)) return;

            DscRoleNode roleNode = (treeDialog.SelectedTag as DscRoleNode);
            if (roleNode == null) return;

            serverNode.Node.Roles.Add(roleNode.BuildName());
            serverNode.Node.Save(serverNode.FilePath);

            lbServerRoles.DataSource = null;
            lbServerRoles.DataSource = serverNode.Node.Roles;
        }

        // Remove Role from Server Node
        private void tsbServerRoleRemove_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if (lbServerRoles.SelectedItem == null) return;
            
            serverNode.Node.Roles.Remove(lbServerRoles.SelectedItem.ToString());
            serverNode.Node.Save(serverNode.FilePath);

            lbServerRoles.DataSource = null;
            lbServerRoles.DataSource = serverNode.Node.Roles;
        }

        // Add variable to Server or Servers Groups
        private void tsbVariableAdd_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || string.IsNullOrWhiteSpace(nameDialog.InputResult)) return;
            
            string variableName = nameDialog.InputResult.Replace("$", "");
            if (string.IsNullOrWhiteSpace(variableName)) return;

            serverNode.Node.Variables.Add(variableName, "");
            serverNode.Node.Save(serverNode.FilePath);

            pgServerVariables.SelectedObject = new DictionaryPropertyGridAdapter(serverNode.Node.Variables);
        }

        // Remove variable from server or servers group
        private void tsbVariableRemove_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if (pgServerVariables.SelectedGridItem.Label == null) return;

            serverNode.Node.Variables.Remove(pgServerVariables.SelectedGridItem.Label);
            serverNode.Node.Save(serverNode.FilePath);

            pgServerVariables.SelectedObject = new DictionaryPropertyGridAdapter(serverNode.Node.Variables);
        }

        // Add dependency to configuration item
        private void tsbCIAddDepends_Click(object sender, EventArgs e)
        {
            DscConfigurationItemNode currentConfigurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            if (currentConfigurationItemNode == null) return;

            fModalTree treeDialog = new fModalTree(tvLibrary.Nodes["tviResources"], ilMain);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscConfigurationItemNode)) return;

            DscConfigurationItemNode selectedConfigurationItemNode = (treeDialog.SelectedTag as DscConfigurationItemNode);
            if (selectedConfigurationItemNode == null) return;

            currentConfigurationItemNode.ConfigurationItem.DependsOn.Add(selectedConfigurationItemNode.GetFullName());
            currentConfigurationItemNode.ConfigurationItem.Save(currentConfigurationItemNode.FilePath);

            lbCIDependency.DataSource = null;
            lbCIDependency.DataSource = currentConfigurationItemNode.ConfigurationItem.DependsOn;
        }

        // Remove dependency from configuration item
        private void tsbCIRemoveDepends_Click(object sender, EventArgs e)
        {
            DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            if (configurationItemNode == null) return;

            if (lbCIDependency.SelectedItem == null) return;

            configurationItemNode.ConfigurationItem.DependsOn.Remove(lbCIDependency.SelectedItem.ToString());
            configurationItemNode.ConfigurationItem.Save(configurationItemNode.FilePath);

            lbCIDependency.DataSource = null;
            lbCIDependency.DataSource = configurationItemNode.ConfigurationItem.DependsOn;
        }

        // Select TreeViewNode on right click
        private void tvLibrary_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvLibrary.SelectedNode = e.Node;
        }

        // Install DSC modules on selected server
        private void installModulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            foreach (PsConfiguration configuration in configurations)
            {
                ModuleWorker.InstallModules(_repository, configuration.Servers, configuration.GetUsedModules(_repository));
            }

            MessageBox.Show(this,
                Strings.UI_Text_ModuleInstallComplete,
                Strings.UI_Caption_Done,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Delete selected server
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;
            DialogResult dialogResult = MessageBox.Show(this,
                string.Concat(Strings.UI_Text_DoYouWantToDelete, Strings.UI_Text_ServerL, "?"),
                Strings.UI_Caption_ConfirmDelete, 
                MessageBoxButtons.YesNo, 
                MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            serverNode.Parent.Nodes.Remove(serverNode);
            File.Delete(serverNode.FilePath);

            tvLibrary.Nodes.Remove(tvLibrary.SelectedNode);
        }

        // Delete selected servers group
        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if (serverNode.Type == DscServerNode.ServerType.Root) return;

            DialogResult dialogResult = MessageBox.Show(this,
                string.Concat(Strings.UI_Text_DoYouWantToDelete, Strings.UI_Text_GroupL, "?"),
                Strings.UI_Caption_ConfirmDelete,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            serverNode.Parent.Nodes.Remove(serverNode);
            string folder = Path.GetDirectoryName(serverNode.FilePath);
            if (folder != null) Directory.Delete(folder, true);

            tvLibrary.Nodes.Remove(tvLibrary.SelectedNode);
        }

        // Delete selected roles group
        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DscRoleGroup roleGroup = (tvLibrary.SelectedNode.Tag as DscRoleGroup);
            if (roleGroup?.Parent == null) return;

            HashSet<string> roleUsages = roleGroup.FindUsages(_repository.Servers);
            if (roleUsages.Count > 0)
            {
                string usages = string.Join(Environment.NewLine, roleUsages);
                MessageBox.Show(this,
                    string.Concat(Strings.UI_Text_CannotDeleteServersGroups, Environment.NewLine, usages),
                    Strings.UI_Caption_Error, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(this,
                string.Concat(Strings.UI_Text_DoYouWantToDelete, Strings.UI_Text_GroupL, "?"),
                Strings.UI_Caption_ConfirmDelete,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            roleGroup.Parent.Groups.Remove(roleGroup);
            Directory.Delete(roleGroup.DirectoryPath, true);

            tvLibrary.Nodes.Remove(tvLibrary.SelectedNode);
        }

        // Delete selected role
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DscRoleNode roleNode = (tvLibrary.SelectedNode.Tag as DscRoleNode);
            if (roleNode == null) return;

            HashSet<string> roleUsages = roleNode.FindUsages(_repository.Servers);
            if (roleUsages.Count > 0)
            {
                string usages = string.Join(Environment.NewLine, roleUsages);
                MessageBox.Show(this,
                    string.Concat(Strings.UI_Text_CannotDeleteServersGroups, Environment.NewLine, usages),
                    Strings.UI_Caption_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(this,
                string.Concat(Strings.UI_Text_DoYouWantToDelete, Strings.UI_Text_RoleL, "?"),
                Strings.UI_Caption_ConfirmDelete,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            roleNode.Parent.Nodes.Remove(roleNode);
            File.Delete(roleNode.FilePath);

            tvLibrary.Nodes.Remove(tvLibrary.SelectedNode);
        }

        // Delete selected configuration item
        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            if (configurationItemNode == null) return;

            HashSet<string> configurationItemUsages = configurationItemNode.FindUsages(_repository.Roles);
            if (configurationItemUsages.Count > 0)
            {
                string usages = string.Join(Environment.NewLine, configurationItemUsages);
                MessageBox.Show(this,
                    string.Concat(Strings.UI_Text_CannotDeleteRoles, Environment.NewLine, usages),
                    Strings.UI_Caption_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(this,
                string.Concat(Strings.UI_Text_DoYouWantToDelete, Strings.UI_Text_ConfigurationItemL, "?"),
                Strings.UI_Caption_ConfirmDelete,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            configurationItemNode.Parent.Nodes.Remove(configurationItemNode);
            File.Delete(configurationItemNode.FilePath);

            tvLibrary.Nodes.Remove(tvLibrary.SelectedNode);
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
