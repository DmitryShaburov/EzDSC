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
        private static readonly Dictionary<Type, int> TypeMap = new Dictionary<Type, int>
            {
                {typeof(DscConfigurationItemNode), 0},
                {typeof(DscRoleGroup), 1},
                {typeof(DscRoleNode), 2},
                {typeof(DscServerNode), 3}
            };

        public fMain()
        {
            InitializeComponent();
        }

        private TreeNode TreeNodeAdd(string text, object tag, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(text);

            switch (TypeMap[tag.GetType()])
            {
                // DscConfigurationItemNode
                // DscRoleGroup
                case 0:
                case 2:
                    node.ImageIndex = 1;
                    node.SelectedImageIndex = 1;
                    break;
                // DscRoleNode
                case 1:
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    node.ContextMenuStrip = cmRoles;
                    break;
                // DscServerNode
                case 3:
                    DscServerNode dscServerNode = tag as DscServerNode;
                    if (dscServerNode != null && dscServerNode.Type == DscServerNode.ServerType.Server)
                    {
                        node.ImageIndex = 2;
                        node.SelectedImageIndex = 2;
                        node.ContextMenuStrip = cmServerItem;
                    }
                    else
                    {
                        node.ImageIndex = 0;
                        node.SelectedImageIndex = 0;
                        node.ContextMenuStrip = cmServers;
                    }
                    break;
                // Default behavior
                default:
                    throw new ArgumentOutOfRangeException();
            }

            node.Tag = tag;
            return node;
        }

        // Create new configuration item
        private void miResourceTypeNewConfigurationItem_Click(object sender, EventArgs e)
        {
            DscResource parent = (tvLibrary.SelectedNode.Tag as DscResource);

            fModalName nameDialog = new fModalName();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBox.Show(this, "Configuration item with same name already exists!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscConfigurationItemNode configurationItemNode =
                _repositoryWorker.NewConfigurationItemNode(nameDialog.InputResult, parent);
            if (configurationItemNode == null) return;

            tvLibrary.SelectedNode = TreeNodeAdd(configurationItemNode.Name, configurationItemNode, tvLibrary.SelectedNode);
        }

        // Create new role
        private void createRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscRoleGroup parent = (tvLibrary.SelectedNode.Tag as DscRoleGroup);

            fModalName nameDialog = new fModalName();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBox.Show(this, "Role or roles group with same name already exists!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscRoleNode roleNode = _repositoryWorker.NewRoleNode(nameDialog.InputResult, parent);
            if (roleNode == null) return;

            tvLibrary.SelectedNode = TreeNodeAdd(roleNode.Name, roleNode, tvLibrary.SelectedNode);
        }

        // Create new roles group
        private void miRolesNewGroup_Click(object sender, EventArgs e)
        {
            DscRoleGroup parent = (tvLibrary.SelectedNode.Tag as DscRoleGroup);

            fModalName nameDialog = new fModalName();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBox.Show(this, "Role or roles group with same name already exists!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscRoleGroup roleGroup = _repositoryWorker.NewRoleGroup(nameDialog.InputResult, parent);
            if (roleGroup == null) return;

            tvLibrary.SelectedNode = TreeNodeAdd(roleGroup.Name, roleGroup, tvLibrary.SelectedNode);
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
                MessageBox.Show(this, "Server or group with same name already exists!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscServerNode serverNode = _repositoryWorker.NewServerNode(nameDialog.InputResult,
                DscServerNode.ServerType.Server, parent);

            tvLibrary.SelectedNode = TreeNodeAdd(serverNode.Name, serverNode, tvLibrary.SelectedNode);
        }

        // Create new Servers Group
        private void miServersNewGroup_Click(object sender, EventArgs e)
        {
            DscServerNode parent = (tvLibrary.SelectedNode.Tag as DscServerNode);

            fModalName nameDialog = new fModalName();
            if (nameDialog.ShowDialog() != DialogResult.OK) return;

            if (_repositoryWorker.Contains(nameDialog.InputResult, parent))
            {
                MessageBox.Show(this, "Server or group with same name already exists!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DscServerNode serverNode = _repositoryWorker.NewServerNode(nameDialog.InputResult,
                DscServerNode.ServerType.Group, parent);

            tvLibrary.SelectedNode = TreeNodeAdd(serverNode.Name, serverNode, tvLibrary.SelectedNode);
        }

        // Fills TreeView with modules, resources and configuration items from current repository
        private void FillResourceTree()
        {
            foreach (DscModule module in _repository.Modules)
            {
                TreeNode moduleNode = tvLibrary.Nodes["tviResources"].Nodes.Add(module.Name);
                moduleNode.Tag = module;
                moduleNode.ImageIndex = 0;
                moduleNode.SelectedImageIndex = 0;
                foreach (DscResource resource in module.Resources)
                {
                    TreeNode resourceNode = moduleNode.Nodes.Add(resource.FriendlyName);
                    resourceNode.Tag = resource;
                    resourceNode.ImageIndex = 0;
                    resourceNode.SelectedImageIndex = 0;
                    resourceNode.ContextMenuStrip = cmResourceType;
                    foreach (DscConfigurationItemNode configurationItem in resource.Nodes)
                    {
                        TreeNode configurationItemNode = resourceNode.Nodes.Add(configurationItem.Name);
                        configurationItemNode.Tag = configurationItem;
                        configurationItemNode.ImageIndex = 1;
                        configurationItemNode.SelectedImageIndex = 1;
                        configurationItemNode.ContextMenuStrip = cmConfigurationItem;
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
                TreeNode roleNode = treeNode.Nodes.Add(childRole.Name);
                roleNode.Tag = childRole;
                roleNode.ImageIndex = 1;
                roleNode.SelectedImageIndex = 1;
                roleNode.ContextMenuStrip = cmRoleItem;
            }
            foreach (DscRoleGroup childGroup in group.Groups)
            {
                TreeNode groupNode = treeNode.Nodes.Add(childGroup.Name);
                groupNode.Tag = childGroup;
                groupNode.ImageIndex = 0;
                groupNode.SelectedImageIndex = 0;
                groupNode.ContextMenuStrip = cmRoles;
                FillRoleTree(childGroup, groupNode);
            }
        }

        // Fill TreeView recursively with servers from current repository
        private void FillServerTree(DscServerNode serverNode, TreeNode treeNode)
        {
            treeNode.Tag = serverNode;
            foreach (DscServerNode child in serverNode.Nodes)
            {
                TreeNode childNode = treeNode.Nodes.Add(child.Name);
                childNode.Tag = child;
                if (child.Type != DscServerNode.ServerType.Group)
                {
                    childNode.ImageIndex = 2;
                    childNode.SelectedImageIndex = 2;
                    childNode.ContextMenuStrip = cmServerItem;
                }
                else
                {
                    childNode.ImageIndex = 0;
                    childNode.SelectedImageIndex = 0;
                    childNode.ContextMenuStrip = cmServers;
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

        // Export DSC Configuration for specific server
        private void miServerItemBuildConfiguration_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if ((sfdExportScript.ShowDialog() != DialogResult.OK) || string.IsNullOrWhiteSpace(sfdExportScript.FileName)) return;

            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            File.WriteAllLines(sfdExportScript.FileName, PsCodeBuilder.BuildScript(configurations, _repository));
        }

        // Save changes in selected configuration item properties
        private void pgEditor_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            if (configurationItemNode == null) return;

            configurationItemNode.Validate();
            configurationItemNode.ConfigurationItem.Save(configurationItemNode.FilePath);
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

        // Run DSC configuration for selected Server
        private void runConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            string filename = FileSystem.GetTempFile();

            File.WriteAllLines(filename, PsCodeBuilder.BuildScript(serverNode.GetConfigurations(), _repository));
            PsRunner.Start(filename);
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

        // Save changes in variable
        private void pgServerVariables_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            serverNode?.Node.Save(serverNode.FilePath);
        }

        // Export DSC Configuration for specific servers group
        private void miBuildConfiguration_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            if ((sfdExportScript.ShowDialog() != DialogResult.OK) || string.IsNullOrWhiteSpace(sfdExportScript.FileName)) return;

            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            File.WriteAllLines(sfdExportScript.FileName, PsCodeBuilder.BuildScript(configurations, _repository));
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

        // Run DSC configuration on selected servers group
        private void miRunConfiguration_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            string filename = FileSystem.GetTempFile();
            
            File.WriteAllLines(filename, PsCodeBuilder.BuildScript(serverNode.GetConfigurations(), _repository));
            PsRunner.Start(filename);
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

            MessageBox.Show(this, "Module installation completed!", "Done!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Install DSC modules on selected servers group
        private void installModulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            foreach (PsConfiguration configuration in configurations)
            {
                ModuleWorker.InstallModules(_repository, configuration.Servers, configuration.GetUsedModules(_repository));
            }

            MessageBox.Show(this, "Module installation completed!", "Done!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Delete selected server
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode == null) return;

            DialogResult dialogResult = MessageBox.Show(this, "Do you want to delete selected server?",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

            DialogResult dialogResult = MessageBox.Show(this, "Do you want to delete selected group?",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    "You cannot delete selected group because following servers/groups using it:" + Environment.NewLine +
                    usages, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(this, "Do you want to delete selected group?",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
                    "You cannot delete selected role because following servers/groups using it:" + Environment.NewLine +
                    usages, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(this, "Do you want to delete selected role?",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            roleNode.Parent.Nodes.Remove(roleNode);
            File.Delete(roleNode.FilePath);

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
                    "You cannot delete selected configuration item because following roles using it:" + Environment.NewLine +
                    usages, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult dialogResult = MessageBox.Show(this, "Do you want to delete selected configuration item?",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;

            configurationItemNode.Parent.Nodes.Remove(configurationItemNode);
            File.Delete(configurationItemNode.FilePath);

            tvLibrary.Nodes.Remove(tvLibrary.SelectedNode);
        }
    }
}
