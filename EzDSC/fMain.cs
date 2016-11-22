using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EzDSC
{
    public partial class fMain : Form
    {
        private DscRepository _repository;

        public fMain()
        {
            InitializeComponent();
        }

        private void createRoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.inputResult == "")) return;
            DscRoleGroup roleGroup = (tvLibrary.SelectedNode.Tag as DscRoleGroup);
            DscRole role = new DscRole();
            string fileName = _repository.Dir.Roles + nameDialog.inputResult + ".json";
            role.Save(fileName);
            roleGroup.Nodes.Add(new DscRoleNode(fileName, roleGroup));
            tvLibrary.Nodes["tviRoles"].Nodes.Clear();
            FillRoleTree(_repository.Roles, tvLibrary.Nodes["tviRoles"]);
        }

        private void FillResourceTree()
        {
            foreach (DscModule module in _repository.Modules)
            {
                TreeNode moduleNode = tvLibrary.Nodes["tviResources"].Nodes.Add(module.Name);
                moduleNode.Tag = module;
                foreach (DscResource resource in module.Resources)
                {
                    TreeNode resourceNode = moduleNode.Nodes.Add(resource.FriendlyName);
                    resourceNode.Tag = resource;
                    resourceNode.ContextMenuStrip = cmResourceType;
                    foreach (DscConfigurationItemNode configurationItem in resource.Nodes)
                    {
                        TreeNode configurationItemNode = resourceNode.Nodes.Add(configurationItem.Name);
                        configurationItemNode.Tag = configurationItem;
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
            }
            foreach (DscRoleGroup childGroup in group.Groups)
            {
                TreeNode groupNode = treeNode.Nodes.Add(childGroup.Name);
                groupNode.Tag = childGroup;
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
                childNode.ContextMenuStrip = cmServerItem;
                if (child.Type != DscServerNode.ServerType.Group) continue;
                childNode.ContextMenuStrip = cmServers;
                FillServerTree(child, childNode);
            }
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            _repository = new DscRepository("E:\\EZDSC");
            FillResourceTree();
            FillRoleTree(_repository.Roles, tvLibrary.Nodes["tviRoles"]);
            FillServerTree(_repository.Servers, tvLibrary.Nodes["tviServers"]);

            pRolePanel.Dock = DockStyle.Fill;
            scServer.Dock = DockStyle.Fill;
            pgEditor.Dock = DockStyle.Fill;;
            pRolePanel.Hide();
            scServer.Hide();
            pgEditor.Hide();
        }

        private void tvLibrary_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvLibrary.SelectedNode.Tag == null) return;
            Type selectedType = tvLibrary.SelectedNode.Tag.GetType();

            pRolePanel.Hide();
            scServer.Hide();
            pgEditor.Hide();

            if (selectedType == typeof(DscConfigurationItemNode))
            {
                DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
                pgEditor.Show();
                pgEditor.SelectedObject = new DictionaryPropertyGridAdapter(configurationItemNode.ConfigurationItem.Properties, configurationItemNode.Parent);
                pgEditor.Tag = configurationItemNode.ConfigurationItem;
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
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            string fileName = _repository.Dir.Output + Guid.NewGuid() + ".ps1";
            File.WriteAllLines(fileName, PsCodeBuilder.BuildScript(configurations, _repository));
            MessageBox.Show(this, "Result file: " + fileName, "Done!");
        }

        private void pgEditor_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscConfigurationItemNode configurationItemNode = (tvLibrary.SelectedNode.Tag as DscConfigurationItemNode);
            configurationItemNode.ConfigurationItem.Save(_repository.Dir.Resources +
                                                         configurationItemNode.Parent.Parent.Name + "\\" +
                                                         configurationItemNode.Parent.FriendlyName + "\\" +
                                                         configurationItemNode.Name + ".json");
        }

        private void miServersNewServer_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.inputResult == "")) return;
            DscServerNode parentNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            string fileName = Path.GetDirectoryName(parentNode.FilePath) + "\\" + nameDialog.inputResult + ".json";
            DscServer server = new DscServer();
            server.Save(fileName);
            DscServerNode serverNode =
                new DscServerNode(DscServerNode.ServerType.Server, fileName, parentNode);
            parentNode.Nodes.Add(serverNode);
            tvLibrary.Nodes["tviServers"].Nodes.Clear();
            FillServerTree(_repository.Servers, tvLibrary.Nodes["tviServers"]);
        }

        private void miServersNewGroup_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.inputResult == "")) return;
            DscServerNode parentNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            string fileName = Path.GetDirectoryName(parentNode.FilePath) + "\\" + nameDialog.inputResult + "\\.group";
            _repository.Dir.DirectoryCreateIfNotExists(Path.GetDirectoryName(fileName));
            DscServer server = new DscServer();
            server.Save(fileName);
            DscServerNode serverNode =
                new DscServerNode(DscServerNode.ServerType.Group, fileName, parentNode);
            parentNode.Nodes.Add(serverNode);
            tvLibrary.Nodes["tviServers"].Nodes.Clear();
            FillServerTree(_repository.Servers, tvLibrary.Nodes["tviServers"]);
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
                string[] files = Directory.GetFiles(fbd.SelectedPath);
                System.Windows.Forms.MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
            }
        }

        private void miResourceTypeNewConfigurationItem_Click(object sender, EventArgs e)
        {
            fModalName nameDialog = new fModalName();
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.inputResult == "")) return;
            DscResource resource = (tvLibrary.SelectedNode.Tag as DscResource);
            DscConfigurationItem configurationItem = new DscConfigurationItem(resource);
            string fileName = _repository.Dir.Resources + resource.Parent.Name + "\\" + resource.FriendlyName + "\\" +
                              nameDialog.inputResult + ".json";
            configurationItem.Save(fileName);
            resource.Nodes.Add(new DscConfigurationItemNode(fileName, resource));
            tvLibrary.Nodes["tviResources"].Nodes.Clear();
            FillResourceTree();
        }

        private void tsbRoleAdd_Click(object sender, EventArgs e)
        {
            fModalTree treeDialog = new fModalTree(tvLibrary.Nodes["tviResources"]);
            if ((treeDialog.ShowDialog() != DialogResult.OK) || (treeDialog.SelectedTag == null)) return;
            if (treeDialog.SelectedTag.GetType() != typeof(DscConfigurationItemNode)) return;
            DscConfigurationItemNode configurationItemNode = (treeDialog.SelectedTag as DscConfigurationItemNode);
            DscRoleNode roleNode = (tvLibrary.SelectedNode.Tag as DscRoleNode);
            roleNode.Role.Resources.Add(configurationItemNode.Parent.Parent.Name + "." + configurationItemNode.Parent.FriendlyName + "." + configurationItemNode.Name);
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
            fModalTree treeDialog = new fModalTree(tvLibrary.Nodes["tviRoles"]);
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
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            string fileName = _repository.Dir.Output + Guid.NewGuid() + ".ps1";
            File.WriteAllLines(fileName, PsCodeBuilder.BuildScript(configurations, _repository));
            Process.Start("powershell.exe", "-ExecutionPolicy UnRestricted -File " + fileName);
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
            if ((nameDialog.ShowDialog() != DialogResult.OK) || (nameDialog.inputResult == "")) return;
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            serverNode.Node.Variables.Add(nameDialog.inputResult, "");
            serverNode.Node.Save(serverNode.FilePath);
        }

        private void pgServerVariables_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            serverNode.Node.Save(serverNode.FilePath);
        }

        private void miBuildConfiguration_Click(object sender, EventArgs e)
        {
            DscServerNode serverNode = (tvLibrary.SelectedNode.Tag as DscServerNode);
            List<PsConfiguration> configurations = serverNode.GetConfigurations();
            string fileName = _repository.Dir.Output + Guid.NewGuid() + ".ps1";
            File.WriteAllLines(fileName, PsCodeBuilder.BuildScript(configurations, _repository));
            MessageBox.Show(this, "Result file: " + fileName, "Done!");
        }
    }
}
