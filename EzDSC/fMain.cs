using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Policy;
using Workers;

namespace EzDSC
{
    public partial class fMain : Form
    {
        private DscRepository _repository;
        private EzSettings _settings;

        public fMain()
        {
            InitializeComponent();
        }

        private void createRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.InputResult == "")) return;
            DscRoleGroup roleGroup = (tvLibrary.SelectedNode.Tag as DscRoleGroup);
            DscRole role = new DscRole();
            string fileName = roleGroup.DirectoryPath + "\\" + nameDialog.InputResult + ".json";
            role.Save(fileName);
            DscRoleNode newRoleNode = new DscRoleNode(fileName, roleGroup);
            roleGroup.Nodes.Add(newRoleNode);
            TreeNode newTreeNode = tvLibrary.SelectedNode.Nodes.Add(newRoleNode.BuildName(), newRoleNode.Name);
            newTreeNode.ImageIndex = 1;
            newTreeNode.SelectedImageIndex = 1;
            newTreeNode.Tag = newRoleNode;
            tvLibrary.SelectedNode = newTreeNode;
        }

        private void FillResourceTree()
        {
            foreach (DscModule module in _repository.Modules)
            {
                TreeNode moduleNode = tvLibrary.Nodes["tviResources"].Nodes.Add(module.Name);
                moduleNode.ImageIndex = 0;
                moduleNode.SelectedImageIndex = 0;
                moduleNode.Tag = module;
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
                    }
                }
               
            }
        }

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

        private void FillServerTree(DscServerNode serverNode, TreeNode treeNode)
        {
            treeNode.Tag = serverNode;
            foreach (DscServerNode child in serverNode.Nodes)
            {
                TreeNode childNode = treeNode.Nodes.Add(child.Name);
                childNode.Tag = child;
                childNode.ImageIndex = 2;
                childNode.SelectedImageIndex = 2;
                childNode.ContextMenuStrip = cmServerItem;
                if (child.Type != DscServerNode.ServerType.Group) continue;
                childNode.ImageIndex = 0;
                childNode.SelectedImageIndex = 0;
                childNode.ContextMenuStrip = cmServers;
                FillServerTree(child, childNode);
            }
        }

        private void UnblockModules()
        {
            string[] allFiles = Directory.GetFiles(_repository.Dir.Modules, "*", SearchOption.AllDirectories);
            List<string> blockedFiles = new List<string>();
            foreach (string file in allFiles)
            {
                Uri uri = new Uri(file);
                Zone zone = Zone.CreateFromUrl(uri.AbsoluteUri);
                if (zone.SecurityZone != SecurityZone.MyComputer)
                {
                    blockedFiles.Add(file);
                }
            }
            if (blockedFiles.Count == 0) return;
            string filename = Path.GetTempPath() + Guid.NewGuid() + ".ps1";
            File.WriteAllLines(filename, PsCodeBuilder.BuildUnblockFile(blockedFiles));
            Process.Start("powershell.exe", "-ExecutionPolicy Unrestricted -File " + filename);
        }

        private void LoadRepository(string path)
        {
            _repository = new DscRepository(path);
            FillResourceTree();
            FillRoleTree(_repository.Roles, tvLibrary.Nodes["tviRoles"]);
            FillServerTree(_repository.Servers, tvLibrary.Nodes["tviServers"]);
            UnblockModules();
            ModuleWorker.InstallLocalModules(_repository);
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            // Setting default controls state
            pRolePanel.Dock = DockStyle.Fill;
            scServer.Dock = DockStyle.Fill;
            scConfigurationItem.Dock = DockStyle.Fill;
            pRolePanel.Hide();
            scServer.Hide();
            scConfigurationItem.Hide();

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

        private void tvLibrary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvLibrary.SelectedNode.Tag == null) return;
            Type selectedType = tvLibrary.SelectedNode.Tag.GetType();

            pRolePanel.Hide();
            scServer.Hide();
            scConfigurationItem.Hide();

            if (selectedType == typeof(DscConfigurationItemNode))
            {
                DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
                scConfigurationItem.Show();
                pgEditor.SelectedObject = new DictionaryPropertyGridAdapter(configurationItemNode.ConfigurationItem.Properties, configurationItemNode.Parent);
                lbCIDependency.DataSource = configurationItemNode.ConfigurationItem.DependsOn;
            }

            if (selectedType == typeof(DscRoleNode))
            {
                DscRoleNode roleNode = (tvLibrary.SelectedNode.Tag as DscRoleNode);
                pRolePanel.Show();
                lbRole.DataSource = roleNode.Role.Resources;
            }

            if (selectedType == typeof(DscServerNode))
            {
                DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
                scServer.Show();
                lbServerRoles.DataSource = serverNode.Node.Roles;
                pgServerVariables.SelectedObject = new DictionaryPropertyGridAdapter(serverNode.Node.Variables);
            }
        }

        private void miServerItemBuildConfiguration_Click(object sender, EventArgs e)
        {
            if ((sfdExportScript.ShowDialog() != DialogResult.OK) || (sfdExportScript.FileName == "")) return;
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            File.WriteAllLines(sfdExportScript.FileName, PsCodeBuilder.BuildScript(configurations, _repository));
        }

        private void pgEditor_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            configurationItemNode.Validate();
            configurationItemNode.ConfigurationItem.Save(_repository.Dir.Resources +
                                                         configurationItemNode.Parent.Parent.Name + "\\" +
                                                         configurationItemNode.Parent.FriendlyName + "\\" +
                                                         configurationItemNode.Name + ".json");
        }

        private void miServersNewServer_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.InputResult == "")) return;
            DscServerNode parentNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (parentNode.Nodes.Any(x => x.Name == nameDialog.InputResult))
            {
                MessageBox.Show(this, "Server or group with same name already exists!", "Error!", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            string fileName = Path.GetDirectoryName(parentNode.FilePath) + "\\" + nameDialog.InputResult + ".json";
            DscServer server = new DscServer();
            server.Save(fileName);
            DscServerNode serverNode =
                new DscServerNode(DscServerNode.ServerType.Server, fileName, parentNode);
            parentNode.Nodes.Add(serverNode);
            TreeNode newTreeNode = tvLibrary.SelectedNode.Nodes.Add(serverNode.FilePath, serverNode.Name);
            newTreeNode.ImageIndex = 2;
            newTreeNode.SelectedImageIndex = 2;
            newTreeNode.Tag = serverNode;
            newTreeNode.ContextMenuStrip = cmServerItem;
            tvLibrary.SelectedNode = newTreeNode;
        }

        private void miServersNewGroup_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.InputResult == "")) return;
            DscServerNode parentNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            string fileName = Path.GetDirectoryName(parentNode.FilePath) + "\\" + nameDialog.InputResult + "\\.group";
            FileSystem.DirectoryCreateIfNotExists(Path.GetDirectoryName(fileName));
            DscServer server = new DscServer();
            server.Save(fileName);
            DscServerNode serverNode =
                new DscServerNode(DscServerNode.ServerType.Group, fileName, parentNode);
            parentNode.Nodes.Add(serverNode);
            TreeNode newTreeNode = tvLibrary.SelectedNode.Nodes.Add(serverNode.FilePath, serverNode.Name);
            newTreeNode.ImageIndex = 0;
            newTreeNode.SelectedImageIndex = 0;
            newTreeNode.Tag = serverNode;
            newTreeNode.ContextMenuStrip = cmServers;
            tvLibrary.SelectedNode = newTreeNode;
        }

        private void miFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void miFileNew_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();
            if (!string.IsNullOrWhiteSpace(fbd.SelectedPath))
            {
                LoadRepository(fbd.SelectedPath);
            }
        }

        private void miResourceTypeNewConfigurationItem_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.InputResult == "")) return;
            DscResource resource = (tvLibrary.SelectedNode.Tag as DscResource);
            DscConfigurationItem configurationItem = new DscConfigurationItem(resource);
            string fileName = _repository.Dir.Resources + resource.Parent.Name + "\\" + resource.FriendlyName + "\\" +
                              nameDialog.InputResult + ".json";
            configurationItem.Save(fileName);
            DscConfigurationItemNode configurationItemNode = new DscConfigurationItemNode(fileName, resource);
            configurationItemNode.Validate();
            resource.Nodes.Add(configurationItemNode);
            TreeNode newTreeNode = tvLibrary.SelectedNode.Nodes.Add(configurationItemNode.GetFullName(), configurationItemNode.Name);
            newTreeNode.ImageIndex = 1;
            newTreeNode.SelectedImageIndex = 1;
            newTreeNode.Tag = configurationItemNode;
            tvLibrary.SelectedNode = newTreeNode;
        }

        private void tsbRoleAdd_Click(object sender, EventArgs e)
        {
            fModalTree treeDialog = new fModalTree(tvLibrary.Nodes["tviResources"], ilMain);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscConfigurationItemNode)) return;
            DscConfigurationItemNode configurationItemNode = (treeDialog.SelectedTag as DscConfigurationItemNode);
            DscRoleNode roleNode = (tvLibrary.SelectedNode.Tag as DscRoleNode);
            roleNode.Role.Resources.Add(configurationItemNode.GetFullName());
            lbRole.DataSource = null;
            lbRole.DataSource = roleNode.Role.Resources;
            roleNode.Role.Save(roleNode.FilePath);
        }

        private void tsbRoleRemove_Click(object sender, EventArgs e)
        {
            if (lbRole.SelectedItem == null) return;
            DscRoleNode roleNode = (tvLibrary.SelectedNode.Tag as DscRoleNode);
            roleNode.Role.Resources.Remove(lbRole.SelectedItem.ToString());
            lbRole.DataSource = null;
            lbRole.DataSource = roleNode.Role.Resources;
            roleNode.Role.Save(roleNode.FilePath);
        }

        private void tsbServerRoleAdd_Click(object sender, EventArgs e)
        {
            fModalTree treeDialog = new fModalTree(tvLibrary.Nodes["tviRoles"], ilMain);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscRoleNode)) return;
            DscRoleNode roleNode = (treeDialog.SelectedTag as DscRoleNode);
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            serverNode.Node.Roles.Add(roleNode.BuildName());
            lbServerRoles.DataSource = null;
            lbServerRoles.DataSource = serverNode.Node.Roles;
            serverNode.Node.Save(serverNode.FilePath);
        }

        private void runConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string filename = Path.GetTempPath() + Guid.NewGuid() + ".ps1";
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            File.WriteAllLines(filename, PsCodeBuilder.BuildScript(configurations, _repository));
            Process.Start("powershell.exe", "-ExecutionPolicy Unrestricted -File " + filename);
        }

        private void tsbServerRoleRemove_Click(object sender, EventArgs e)
        {
            if (lbServerRoles.SelectedItem == null) return;
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            serverNode.Node.Roles.Remove(lbServerRoles.SelectedItem.ToString());
            lbServerRoles.DataSource = null;
            lbServerRoles.DataSource = serverNode.Node.Roles;
            serverNode.Node.Save(serverNode.FilePath);
        }

        private void tsbVariableAdd_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.InputResult == "")) return;
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            string variableName = nameDialog.InputResult.Replace("$", "");
            serverNode.Node.Variables.Add(variableName, "");
            serverNode.Node.Save(serverNode.FilePath);
            pgServerVariables.SelectedObject = new DictionaryPropertyGridAdapter(serverNode.Node.Variables);
        }

        private void pgServerVariables_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            serverNode.Node.Save(serverNode.FilePath);
        }

        private void miBuildConfiguration_Click(object sender, EventArgs e)
        {
            if ((sfdExportScript.ShowDialog() != DialogResult.OK) || (sfdExportScript.FileName == "")) return;
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            File.WriteAllLines(sfdExportScript.FileName, PsCodeBuilder.BuildScript(configurations, _repository));
        }

        private void tsbCIAddDepends_Click(object sender, EventArgs e)
        {
            fModalTree treeDialog = new fModalTree(tvLibrary.Nodes["tviResources"], ilMain);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscConfigurationItemNode)) return;
            DscConfigurationItemNode selectedConfigurationItemNode = (treeDialog.SelectedTag as DscConfigurationItemNode);
            DscConfigurationItemNode currentConfigurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            currentConfigurationItemNode.ConfigurationItem.DependsOn.Add(selectedConfigurationItemNode.GetFullName());
            lbCIDependency.DataSource = null;
            lbCIDependency.DataSource = currentConfigurationItemNode.ConfigurationItem.DependsOn;
            currentConfigurationItemNode.ConfigurationItem.Save(_repository.Dir.Resources +
                                                         currentConfigurationItemNode.Parent.Parent.Name + "\\" +
                                                         currentConfigurationItemNode.Parent.FriendlyName + "\\" +
                                                         currentConfigurationItemNode.Name + ".json");
        }

        private void tsbCIRemoveDepends_Click(object sender, EventArgs e)
        {
            if (lbCIDependency.SelectedItem == null) return;
            DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            configurationItemNode.ConfigurationItem.DependsOn.Remove(lbCIDependency.SelectedItem.ToString());
            lbCIDependency.DataSource = null;
            lbCIDependency.DataSource = configurationItemNode.ConfigurationItem.DependsOn;
            configurationItemNode.ConfigurationItem.Save(_repository.Dir.Resources +
                                                         configurationItemNode.Parent.Parent.Name + "\\" +
                                                         configurationItemNode.Parent.FriendlyName + "\\" +
                                                         configurationItemNode.Name + ".json");
        }

        private void tvLibrary_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvLibrary.SelectedNode = e.Node;
        }

        private void miRolesNewGroup_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.InputResult == "")) return;
            DscRoleGroup roleGroup = (tvLibrary.SelectedNode.Tag as DscRoleGroup);
            string path = roleGroup.DirectoryPath + nameDialog.InputResult + "\\";
            FileSystem.DirectoryCreateIfNotExists(path);
            DscRoleGroup newRoleGroup = new DscRoleGroup(path, roleGroup);
            roleGroup.Groups.Add(newRoleGroup);
            TreeNode newTreeNode = tvLibrary.SelectedNode.Nodes.Add(newRoleGroup.BuildName(), newRoleGroup.Name);
            newTreeNode.Tag = newRoleGroup;
            newTreeNode.ImageIndex = 0;
            newTreeNode.SelectedImageIndex = 0;
            newTreeNode.ContextMenuStrip = cmRoles;
            tvLibrary.SelectedNode = newTreeNode;
        }

        private void tsbVariableRemove_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            serverNode.Node.Variables.Remove(pgServerVariables.SelectedGridItem.Label);
            serverNode.Node.Save(serverNode.FilePath);
            pgServerVariables.SelectedObject = new DictionaryPropertyGridAdapter(serverNode.Node.Variables);
        }

        private void miRunConfiguration_Click(object sender, EventArgs e)
        {
            string filename = Path.GetTempPath() + Guid.NewGuid() + ".ps1";
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            File.WriteAllLines(filename, PsCodeBuilder.BuildScript(configurations, _repository));
            Process.Start("powershell.exe", "-ExecutionPolicy Unrestricted -File " + filename);
        }

        private void installModulesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            foreach (PsConfiguration configuration in configurations)
            {
                ModuleWorker.InstallModules(_repository, configuration.Servers, configuration.GetUsedModules(_repository));
            }
            MessageBox.Show(this, "Module installation completed!", "Done!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void installModulesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            foreach (PsConfiguration configuration in configurations)
            {
                ModuleWorker.InstallModules(_repository, configuration.Servers, configuration.GetUsedModules(_repository));
            }
            MessageBox.Show(this, "Module installation completed!", "Done!", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            DialogResult dialogResult = MessageBox.Show(this, "Do you want to delete selected server?",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;
            serverNode.Parent.Nodes.Remove(serverNode);
            File.Delete(serverNode.FilePath);
            tvLibrary.Nodes.Remove(tvLibrary.SelectedNode);
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            if (serverNode.Type == DscServerNode.ServerType.Root) return;
            DialogResult dialogResult = MessageBox.Show(this, "Do you want to delete selected group?",
                "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult != DialogResult.Yes) return;
            serverNode.Parent.Nodes.Remove(serverNode);
            Directory.Delete(Path.GetDirectoryName(serverNode.FilePath), true);
            tvLibrary.Nodes.Remove(tvLibrary.SelectedNode);
        }

        private void deleteToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DscRoleGroup roleGroup = (tvLibrary.SelectedNode.Tag as DscRoleGroup);
            if (roleGroup.Parent == null) return;
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

        private void cmRoleItem_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            DscRoleNode roleNode = (tvLibrary.SelectedNode.Tag as DscRoleNode);
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

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _settings.WindowSize = Size;
            _settings.WindowState = WindowState;
            _settings.LastRepositoryPath = _repository?.Dir.Root;
            _settings.Save();
        }

        private void miFileOpen_Click(object sender, EventArgs e)
        {

        }
    }
}
