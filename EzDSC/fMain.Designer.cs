namespace EzDSC
{
    partial class fMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Resources");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Roles");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Servers");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.cmRoles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRolesNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.miRolesNewRole = new System.Windows.Forms.ToolStripMenuItem();
            this.cmServers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miServersNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.miServersNewServer = new System.Windows.Forms.ToolStripMenuItem();
            this.tssServers = new System.Windows.Forms.ToolStripSeparator();
            this.miBuildConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.miRunConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.installModulesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tvLibrary = new System.Windows.Forms.TreeView();
            this.ilMain = new System.Windows.Forms.ImageList(this.components);
            this.cmServerItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miServerItemBuildConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.runConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.installModulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.scConfigurationItem = new System.Windows.Forms.SplitContainer();
            this.pgEditor = new System.Windows.Forms.PropertyGrid();
            this.lbCIDependency = new System.Windows.Forms.ListBox();
            this.tsCIDependsOn = new System.Windows.Forms.ToolStrip();
            this.tslCIDepends = new System.Windows.Forms.ToolStripLabel();
            this.tsbCIAddDepends = new System.Windows.Forms.ToolStripButton();
            this.tsbCIRemoveDepends = new System.Windows.Forms.ToolStripButton();
            this.scServer = new System.Windows.Forms.SplitContainer();
            this.lbServerRoles = new System.Windows.Forms.ListBox();
            this.tsServerRoles = new System.Windows.Forms.ToolStrip();
            this.tslServerRoles = new System.Windows.Forms.ToolStripLabel();
            this.tsbServerRoleAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbServerRoleRemove = new System.Windows.Forms.ToolStripButton();
            this.pgServerVariables = new System.Windows.Forms.PropertyGrid();
            this.tsServerVariables = new System.Windows.Forms.ToolStrip();
            this.tslServerVariables = new System.Windows.Forms.ToolStripLabel();
            this.tsbVariableAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbVariableRemove = new System.Windows.Forms.ToolStripButton();
            this.pRolePanel = new System.Windows.Forms.Panel();
            this.lbRole = new System.Windows.Forms.ListBox();
            this.tsRole = new System.Windows.Forms.ToolStrip();
            this.tslRoleCI = new System.Windows.Forms.ToolStripLabel();
            this.tsbRoleAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbRoleRemove = new System.Windows.Forms.ToolStripButton();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.miFile = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.miFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.tsFileStrip = new System.Windows.Forms.ToolStripSeparator();
            this.miFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmResourceType = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miResourceTypeNewConfigurationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sfdExportScript = new System.Windows.Forms.SaveFileDialog();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cmRoles.SuspendLayout();
            this.cmServers.SuspendLayout();
            this.cmServerItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scConfigurationItem)).BeginInit();
            this.scConfigurationItem.Panel1.SuspendLayout();
            this.scConfigurationItem.Panel2.SuspendLayout();
            this.scConfigurationItem.SuspendLayout();
            this.tsCIDependsOn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scServer)).BeginInit();
            this.scServer.Panel1.SuspendLayout();
            this.scServer.Panel2.SuspendLayout();
            this.scServer.SuspendLayout();
            this.tsServerRoles.SuspendLayout();
            this.tsServerVariables.SuspendLayout();
            this.pRolePanel.SuspendLayout();
            this.tsRole.SuspendLayout();
            this.msMainMenu.SuspendLayout();
            this.cmResourceType.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmRoles
            // 
            this.cmRoles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRolesNewGroup,
            this.miRolesNewRole});
            this.cmRoles.Name = "cmRoles";
            this.cmRoles.Size = new System.Drawing.Size(143, 48);
            // 
            // miRolesNewGroup
            // 
            this.miRolesNewGroup.Image = global::EzDSC.Images.folder_new;
            this.miRolesNewGroup.Name = "miRolesNewGroup";
            this.miRolesNewGroup.Size = new System.Drawing.Size(142, 22);
            this.miRolesNewGroup.Text = "New group...";
            this.miRolesNewGroup.Click += new System.EventHandler(this.miRolesNewGroup_Click);
            // 
            // miRolesNewRole
            // 
            this.miRolesNewRole.Image = global::EzDSC.Images.document_new;
            this.miRolesNewRole.Name = "miRolesNewRole";
            this.miRolesNewRole.Size = new System.Drawing.Size(142, 22);
            this.miRolesNewRole.Text = "New role...";
            this.miRolesNewRole.Click += new System.EventHandler(this.createRoleToolStripMenuItem_Click);
            // 
            // cmServers
            // 
            this.cmServers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miServersNewGroup,
            this.miServersNewServer,
            this.tssServers,
            this.miBuildConfiguration,
            this.miRunConfiguration,
            this.toolStripMenuItem2,
            this.installModulesToolStripMenuItem1,
            this.toolStripMenuItem4,
            this.deleteToolStripMenuItem1});
            this.cmServers.Name = "cmServers";
            this.cmServers.Size = new System.Drawing.Size(192, 176);
            // 
            // miServersNewGroup
            // 
            this.miServersNewGroup.Image = global::EzDSC.Images.folder_new;
            this.miServersNewGroup.Name = "miServersNewGroup";
            this.miServersNewGroup.Size = new System.Drawing.Size(191, 22);
            this.miServersNewGroup.Text = "New group...";
            this.miServersNewGroup.Click += new System.EventHandler(this.miServersNewGroup_Click);
            // 
            // miServersNewServer
            // 
            this.miServersNewServer.Image = global::EzDSC.Images.document_new;
            this.miServersNewServer.Name = "miServersNewServer";
            this.miServersNewServer.Size = new System.Drawing.Size(191, 22);
            this.miServersNewServer.Text = "New server...";
            this.miServersNewServer.Click += new System.EventHandler(this.miServersNewServer_Click);
            // 
            // tssServers
            // 
            this.tssServers.Name = "tssServers";
            this.tssServers.Size = new System.Drawing.Size(188, 6);
            // 
            // miBuildConfiguration
            // 
            this.miBuildConfiguration.Image = global::EzDSC.Images.document_save;
            this.miBuildConfiguration.Name = "miBuildConfiguration";
            this.miBuildConfiguration.Size = new System.Drawing.Size(191, 22);
            this.miBuildConfiguration.Text = "Export configuration...";
            this.miBuildConfiguration.Click += new System.EventHandler(this.miBuildConfiguration_Click);
            // 
            // miRunConfiguration
            // 
            this.miRunConfiguration.Image = global::EzDSC.Images.utilities_terminal;
            this.miRunConfiguration.Name = "miRunConfiguration";
            this.miRunConfiguration.Size = new System.Drawing.Size(191, 22);
            this.miRunConfiguration.Text = "Run configuration";
            this.miRunConfiguration.Click += new System.EventHandler(this.miRunConfiguration_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(188, 6);
            // 
            // installModulesToolStripMenuItem1
            // 
            this.installModulesToolStripMenuItem1.Name = "installModulesToolStripMenuItem1";
            this.installModulesToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.installModulesToolStripMenuItem1.Text = "Install modules";
            this.installModulesToolStripMenuItem1.Click += new System.EventHandler(this.installModulesToolStripMenuItem1_Click);
            // 
            // tvLibrary
            // 
            this.tvLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLibrary.ImageIndex = 0;
            this.tvLibrary.ImageList = this.ilMain;
            this.tvLibrary.Location = new System.Drawing.Point(0, 0);
            this.tvLibrary.Name = "tvLibrary";
            treeNode1.Name = "tviResources";
            treeNode1.Text = "Resources";
            treeNode2.ContextMenuStrip = this.cmRoles;
            treeNode2.Name = "tviRoles";
            treeNode2.Text = "Roles";
            treeNode3.ContextMenuStrip = this.cmServers;
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "tviServers";
            treeNode3.Text = "Servers";
            this.tvLibrary.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.tvLibrary.SelectedImageIndex = 0;
            this.tvLibrary.Size = new System.Drawing.Size(240, 514);
            this.tvLibrary.TabIndex = 0;
            this.tvLibrary.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLibrary_AfterSelect);
            this.tvLibrary.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvLibrary_NodeMouseClick);
            // 
            // ilMain
            // 
            this.ilMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMain.ImageStream")));
            this.ilMain.TransparentColor = System.Drawing.Color.Transparent;
            this.ilMain.Images.SetKeyName(0, "folder");
            this.ilMain.Images.SetKeyName(1, "text-x-generic");
            this.ilMain.Images.SetKeyName(2, "network-server");
            // 
            // cmServerItem
            // 
            this.cmServerItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miServerItemBuildConfiguration,
            this.runConfigurationToolStripMenuItem,
            this.toolStripMenuItem1,
            this.installModulesToolStripMenuItem,
            this.toolStripMenuItem3,
            this.deleteToolStripMenuItem});
            this.cmServerItem.Name = "cmServerItem";
            this.cmServerItem.Size = new System.Drawing.Size(183, 104);
            // 
            // miServerItemBuildConfiguration
            // 
            this.miServerItemBuildConfiguration.Image = global::EzDSC.Images.document_save;
            this.miServerItemBuildConfiguration.Name = "miServerItemBuildConfiguration";
            this.miServerItemBuildConfiguration.Size = new System.Drawing.Size(182, 22);
            this.miServerItemBuildConfiguration.Text = "Export configuration";
            this.miServerItemBuildConfiguration.Click += new System.EventHandler(this.miServerItemBuildConfiguration_Click);
            // 
            // runConfigurationToolStripMenuItem
            // 
            this.runConfigurationToolStripMenuItem.Image = global::EzDSC.Images.utilities_terminal;
            this.runConfigurationToolStripMenuItem.Name = "runConfigurationToolStripMenuItem";
            this.runConfigurationToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.runConfigurationToolStripMenuItem.Text = "Run configuration";
            this.runConfigurationToolStripMenuItem.Click += new System.EventHandler(this.runConfigurationToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(179, 6);
            // 
            // installModulesToolStripMenuItem
            // 
            this.installModulesToolStripMenuItem.Name = "installModulesToolStripMenuItem";
            this.installModulesToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.installModulesToolStripMenuItem.Text = "Install modules";
            this.installModulesToolStripMenuItem.Click += new System.EventHandler(this.installModulesToolStripMenuItem_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 24);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.tvLibrary);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.scConfigurationItem);
            this.scMain.Panel2.Controls.Add(this.scServer);
            this.scMain.Panel2.Controls.Add(this.pRolePanel);
            this.scMain.Size = new System.Drawing.Size(1250, 514);
            this.scMain.SplitterDistance = 240;
            this.scMain.TabIndex = 7;
            // 
            // scConfigurationItem
            // 
            this.scConfigurationItem.Location = new System.Drawing.Point(127, 201);
            this.scConfigurationItem.Name = "scConfigurationItem";
            this.scConfigurationItem.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scConfigurationItem.Panel1
            // 
            this.scConfigurationItem.Panel1.Controls.Add(this.pgEditor);
            // 
            // scConfigurationItem.Panel2
            // 
            this.scConfigurationItem.Panel2.Controls.Add(this.lbCIDependency);
            this.scConfigurationItem.Panel2.Controls.Add(this.tsCIDependsOn);
            this.scConfigurationItem.Size = new System.Drawing.Size(347, 213);
            this.scConfigurationItem.SplitterDistance = 139;
            this.scConfigurationItem.TabIndex = 12;
            // 
            // pgEditor
            // 
            this.pgEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgEditor.Location = new System.Drawing.Point(0, 0);
            this.pgEditor.Name = "pgEditor";
            this.pgEditor.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgEditor.Size = new System.Drawing.Size(347, 139);
            this.pgEditor.TabIndex = 10;
            this.pgEditor.ToolbarVisible = false;
            this.pgEditor.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgEditor_PropertyValueChanged);
            // 
            // lbCIDependency
            // 
            this.lbCIDependency.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCIDependency.FormattingEnabled = true;
            this.lbCIDependency.Location = new System.Drawing.Point(0, 25);
            this.lbCIDependency.Name = "lbCIDependency";
            this.lbCIDependency.Size = new System.Drawing.Size(347, 45);
            this.lbCIDependency.TabIndex = 1;
            // 
            // tsCIDependsOn
            // 
            this.tsCIDependsOn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslCIDepends,
            this.tsbCIAddDepends,
            this.tsbCIRemoveDepends});
            this.tsCIDependsOn.Location = new System.Drawing.Point(0, 0);
            this.tsCIDependsOn.Name = "tsCIDependsOn";
            this.tsCIDependsOn.Size = new System.Drawing.Size(347, 25);
            this.tsCIDependsOn.TabIndex = 0;
            this.tsCIDependsOn.Text = "toolStrip3";
            // 
            // tslCIDepends
            // 
            this.tslCIDepends.Name = "tslCIDepends";
            this.tslCIDepends.Size = new System.Drawing.Size(75, 22);
            this.tslCIDepends.Text = "Depends On:";
            // 
            // tsbCIAddDepends
            // 
            this.tsbCIAddDepends.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCIAddDepends.Image = global::EzDSC.Images.list_add;
            this.tsbCIAddDepends.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCIAddDepends.Name = "tsbCIAddDepends";
            this.tsbCIAddDepends.Size = new System.Drawing.Size(23, 22);
            this.tsbCIAddDepends.Text = "Add...";
            this.tsbCIAddDepends.Click += new System.EventHandler(this.tsbCIAddDepends_Click);
            // 
            // tsbCIRemoveDepends
            // 
            this.tsbCIRemoveDepends.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCIRemoveDepends.Image = global::EzDSC.Images.list_remove;
            this.tsbCIRemoveDepends.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCIRemoveDepends.Name = "tsbCIRemoveDepends";
            this.tsbCIRemoveDepends.Size = new System.Drawing.Size(23, 22);
            this.tsbCIRemoveDepends.Text = "Remove...";
            this.tsbCIRemoveDepends.Click += new System.EventHandler(this.tsbCIRemoveDepends_Click);
            // 
            // scServer
            // 
            this.scServer.Location = new System.Drawing.Point(572, 61);
            this.scServer.Name = "scServer";
            this.scServer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scServer.Panel1
            // 
            this.scServer.Panel1.Controls.Add(this.lbServerRoles);
            this.scServer.Panel1.Controls.Add(this.tsServerRoles);
            // 
            // scServer.Panel2
            // 
            this.scServer.Panel2.Controls.Add(this.pgServerVariables);
            this.scServer.Panel2.Controls.Add(this.tsServerVariables);
            this.scServer.Size = new System.Drawing.Size(396, 273);
            this.scServer.SplitterDistance = 136;
            this.scServer.TabIndex = 11;
            // 
            // lbServerRoles
            // 
            this.lbServerRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbServerRoles.FormattingEnabled = true;
            this.lbServerRoles.Location = new System.Drawing.Point(0, 25);
            this.lbServerRoles.Name = "lbServerRoles";
            this.lbServerRoles.Size = new System.Drawing.Size(396, 111);
            this.lbServerRoles.TabIndex = 1;
            // 
            // tsServerRoles
            // 
            this.tsServerRoles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslServerRoles,
            this.tsbServerRoleAdd,
            this.tsbServerRoleRemove});
            this.tsServerRoles.Location = new System.Drawing.Point(0, 0);
            this.tsServerRoles.Name = "tsServerRoles";
            this.tsServerRoles.Size = new System.Drawing.Size(396, 25);
            this.tsServerRoles.TabIndex = 0;
            this.tsServerRoles.Text = "tsServerRoles";
            // 
            // tslServerRoles
            // 
            this.tslServerRoles.Name = "tslServerRoles";
            this.tslServerRoles.Size = new System.Drawing.Size(38, 22);
            this.tslServerRoles.Text = "Roles:";
            // 
            // tsbServerRoleAdd
            // 
            this.tsbServerRoleAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbServerRoleAdd.Image = global::EzDSC.Images.list_add;
            this.tsbServerRoleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbServerRoleAdd.Name = "tsbServerRoleAdd";
            this.tsbServerRoleAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbServerRoleAdd.Text = "Add...";
            this.tsbServerRoleAdd.Click += new System.EventHandler(this.tsbServerRoleAdd_Click);
            // 
            // tsbServerRoleRemove
            // 
            this.tsbServerRoleRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbServerRoleRemove.Image = global::EzDSC.Images.list_remove;
            this.tsbServerRoleRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbServerRoleRemove.Name = "tsbServerRoleRemove";
            this.tsbServerRoleRemove.Size = new System.Drawing.Size(23, 22);
            this.tsbServerRoleRemove.Text = "Remove...";
            this.tsbServerRoleRemove.Click += new System.EventHandler(this.tsbServerRoleRemove_Click);
            // 
            // pgServerVariables
            // 
            this.pgServerVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgServerVariables.HelpVisible = false;
            this.pgServerVariables.Location = new System.Drawing.Point(0, 25);
            this.pgServerVariables.Name = "pgServerVariables";
            this.pgServerVariables.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgServerVariables.Size = new System.Drawing.Size(396, 108);
            this.pgServerVariables.TabIndex = 1;
            this.pgServerVariables.ToolbarVisible = false;
            this.pgServerVariables.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgServerVariables_PropertyValueChanged);
            // 
            // tsServerVariables
            // 
            this.tsServerVariables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslServerVariables,
            this.tsbVariableAdd,
            this.tsbVariableRemove});
            this.tsServerVariables.Location = new System.Drawing.Point(0, 0);
            this.tsServerVariables.Name = "tsServerVariables";
            this.tsServerVariables.Size = new System.Drawing.Size(396, 25);
            this.tsServerVariables.TabIndex = 0;
            this.tsServerVariables.Text = "tsServerVariables";
            // 
            // tslServerVariables
            // 
            this.tslServerVariables.Name = "tslServerVariables";
            this.tslServerVariables.Size = new System.Drawing.Size(57, 22);
            this.tslServerVariables.Text = "Variables:";
            // 
            // tsbVariableAdd
            // 
            this.tsbVariableAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbVariableAdd.Image = global::EzDSC.Images.list_add;
            this.tsbVariableAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVariableAdd.Name = "tsbVariableAdd";
            this.tsbVariableAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbVariableAdd.Text = "Add..";
            this.tsbVariableAdd.Click += new System.EventHandler(this.tsbVariableAdd_Click);
            // 
            // tsbVariableRemove
            // 
            this.tsbVariableRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbVariableRemove.Image = global::EzDSC.Images.list_remove;
            this.tsbVariableRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVariableRemove.Name = "tsbVariableRemove";
            this.tsbVariableRemove.Size = new System.Drawing.Size(23, 22);
            this.tsbVariableRemove.Text = "Remove...";
            this.tsbVariableRemove.Click += new System.EventHandler(this.tsbVariableRemove_Click);
            // 
            // pRolePanel
            // 
            this.pRolePanel.Controls.Add(this.lbRole);
            this.pRolePanel.Controls.Add(this.tsRole);
            this.pRolePanel.Location = new System.Drawing.Point(3, 4);
            this.pRolePanel.Name = "pRolePanel";
            this.pRolePanel.Size = new System.Drawing.Size(200, 100);
            this.pRolePanel.TabIndex = 9;
            // 
            // lbRole
            // 
            this.lbRole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRole.FormattingEnabled = true;
            this.lbRole.Location = new System.Drawing.Point(0, 25);
            this.lbRole.Name = "lbRole";
            this.lbRole.Size = new System.Drawing.Size(200, 75);
            this.lbRole.TabIndex = 7;
            // 
            // tsRole
            // 
            this.tsRole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslRoleCI,
            this.tsbRoleAdd,
            this.tsbRoleRemove});
            this.tsRole.Location = new System.Drawing.Point(0, 0);
            this.tsRole.Name = "tsRole";
            this.tsRole.Size = new System.Drawing.Size(200, 25);
            this.tsRole.TabIndex = 6;
            this.tsRole.Text = "toolStrip1";
            // 
            // tslRoleCI
            // 
            this.tslRoleCI.Name = "tslRoleCI";
            this.tslRoleCI.Size = new System.Drawing.Size(116, 22);
            this.tslRoleCI.Text = "Configuration items:";
            // 
            // tsbRoleAdd
            // 
            this.tsbRoleAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRoleAdd.Image = global::EzDSC.Images.list_add;
            this.tsbRoleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRoleAdd.Name = "tsbRoleAdd";
            this.tsbRoleAdd.Size = new System.Drawing.Size(23, 22);
            this.tsbRoleAdd.Text = "Add...";
            this.tsbRoleAdd.Click += new System.EventHandler(this.tsbRoleAdd_Click);
            // 
            // tsbRoleRemove
            // 
            this.tsbRoleRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbRoleRemove.Image = global::EzDSC.Images.list_remove;
            this.tsbRoleRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRoleRemove.Name = "tsbRoleRemove";
            this.tsbRoleRemove.Size = new System.Drawing.Size(23, 22);
            this.tsbRoleRemove.Text = "Remove...";
            this.tsbRoleRemove.Click += new System.EventHandler(this.tsbRoleRemove_Click);
            // 
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFile});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(1250, 24);
            this.msMainMenu.TabIndex = 8;
            // 
            // miFile
            // 
            this.miFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miFileNew,
            this.miFileOpen,
            this.tsFileStrip,
            this.miFileExit});
            this.miFile.Name = "miFile";
            this.miFile.Size = new System.Drawing.Size(37, 20);
            this.miFile.Text = "File";
            // 
            // miFileNew
            // 
            this.miFileNew.Name = "miFileNew";
            this.miFileNew.Size = new System.Drawing.Size(112, 22);
            this.miFileNew.Text = "New...";
            this.miFileNew.Click += new System.EventHandler(this.miFileNew_Click);
            // 
            // miFileOpen
            // 
            this.miFileOpen.Name = "miFileOpen";
            this.miFileOpen.Size = new System.Drawing.Size(112, 22);
            this.miFileOpen.Text = "Open...";
            // 
            // tsFileStrip
            // 
            this.tsFileStrip.Name = "tsFileStrip";
            this.tsFileStrip.Size = new System.Drawing.Size(109, 6);
            // 
            // miFileExit
            // 
            this.miFileExit.Name = "miFileExit";
            this.miFileExit.Size = new System.Drawing.Size(112, 22);
            this.miFileExit.Text = "Exit";
            this.miFileExit.Click += new System.EventHandler(this.miFileExit_Click);
            // 
            // cmResourceType
            // 
            this.cmResourceType.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miResourceTypeNewConfigurationItem});
            this.cmResourceType.Name = "cmResourceType";
            this.cmResourceType.Size = new System.Drawing.Size(210, 26);
            // 
            // miResourceTypeNewConfigurationItem
            // 
            this.miResourceTypeNewConfigurationItem.Image = global::EzDSC.Images.document_new;
            this.miResourceTypeNewConfigurationItem.Name = "miResourceTypeNewConfigurationItem";
            this.miResourceTypeNewConfigurationItem.Size = new System.Drawing.Size(209, 22);
            this.miResourceTypeNewConfigurationItem.Text = "New configuration item...";
            this.miResourceTypeNewConfigurationItem.Click += new System.EventHandler(this.miResourceTypeNewConfigurationItem_Click);
            // 
            // sfdExportScript
            // 
            this.sfdExportScript.DefaultExt = "ps1";
            this.sfdExportScript.Filter = "PowerShell Script|*.ps1";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(179, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(188, 6);
            // 
            // deleteToolStripMenuItem1
            // 
            this.deleteToolStripMenuItem1.Name = "deleteToolStripMenuItem1";
            this.deleteToolStripMenuItem1.Size = new System.Drawing.Size(191, 22);
            this.deleteToolStripMenuItem1.Text = "Delete";
            this.deleteToolStripMenuItem1.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 538);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.msMainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msMainMenu;
            this.Name = "fMain";
            this.Text = "EzDSC";
            this.Load += new System.EventHandler(this.fMain_Load);
            this.cmRoles.ResumeLayout(false);
            this.cmServers.ResumeLayout(false);
            this.cmServerItem.ResumeLayout(false);
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.scConfigurationItem.Panel1.ResumeLayout(false);
            this.scConfigurationItem.Panel2.ResumeLayout(false);
            this.scConfigurationItem.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scConfigurationItem)).EndInit();
            this.scConfigurationItem.ResumeLayout(false);
            this.tsCIDependsOn.ResumeLayout(false);
            this.tsCIDependsOn.PerformLayout();
            this.scServer.Panel1.ResumeLayout(false);
            this.scServer.Panel1.PerformLayout();
            this.scServer.Panel2.ResumeLayout(false);
            this.scServer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scServer)).EndInit();
            this.scServer.ResumeLayout(false);
            this.tsServerRoles.ResumeLayout(false);
            this.tsServerRoles.PerformLayout();
            this.tsServerVariables.ResumeLayout(false);
            this.tsServerVariables.PerformLayout();
            this.pRolePanel.ResumeLayout(false);
            this.pRolePanel.PerformLayout();
            this.tsRole.ResumeLayout(false);
            this.tsRole.PerformLayout();
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.cmResourceType.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvLibrary;
        private System.Windows.Forms.ContextMenuStrip cmRoles;
        private System.Windows.Forms.ToolStripMenuItem miRolesNewRole;
        private System.Windows.Forms.ContextMenuStrip cmServers;
        private System.Windows.Forms.ToolStripMenuItem miRolesNewGroup;
        private System.Windows.Forms.ToolStripMenuItem miServersNewGroup;
        private System.Windows.Forms.ToolStripSeparator tssServers;
        private System.Windows.Forms.ToolStripMenuItem miServersNewServer;
        private System.Windows.Forms.ContextMenuStrip cmServerItem;
        private System.Windows.Forms.ToolStripMenuItem miServerItemBuildConfiguration;
        private System.Windows.Forms.ToolStripMenuItem miBuildConfiguration;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem miFile;
        private System.Windows.Forms.ToolStripMenuItem miFileNew;
        private System.Windows.Forms.ToolStripMenuItem miFileOpen;
        private System.Windows.Forms.ToolStripSeparator tsFileStrip;
        private System.Windows.Forms.ToolStripMenuItem miFileExit;
        private System.Windows.Forms.ContextMenuStrip cmResourceType;
        private System.Windows.Forms.ToolStripMenuItem miResourceTypeNewConfigurationItem;
        private System.Windows.Forms.Panel pRolePanel;
        private System.Windows.Forms.ListBox lbRole;
        private System.Windows.Forms.ToolStrip tsRole;
        private System.Windows.Forms.ToolStripButton tsbRoleAdd;
        private System.Windows.Forms.ToolStripButton tsbRoleRemove;
        private System.Windows.Forms.PropertyGrid pgEditor;
        private System.Windows.Forms.SplitContainer scServer;
        private System.Windows.Forms.ListBox lbServerRoles;
        private System.Windows.Forms.ToolStrip tsServerRoles;
        private System.Windows.Forms.ToolStripButton tsbServerRoleAdd;
        private System.Windows.Forms.ToolStripButton tsbServerRoleRemove;
        private System.Windows.Forms.PropertyGrid pgServerVariables;
        private System.Windows.Forms.ToolStrip tsServerVariables;
        private System.Windows.Forms.ToolStripButton tsbVariableAdd;
        private System.Windows.Forms.ToolStripButton tsbVariableRemove;
        private System.Windows.Forms.ToolStripMenuItem runConfigurationToolStripMenuItem;
        private System.Windows.Forms.SplitContainer scConfigurationItem;
        private System.Windows.Forms.ToolStrip tsCIDependsOn;
        private System.Windows.Forms.ToolStripButton tsbCIAddDepends;
        private System.Windows.Forms.ToolStripButton tsbCIRemoveDepends;
        private System.Windows.Forms.ListBox lbCIDependency;
        private System.Windows.Forms.ImageList ilMain;
        private System.Windows.Forms.ToolStripLabel tslCIDepends;
        private System.Windows.Forms.ToolStripLabel tslServerRoles;
        private System.Windows.Forms.ToolStripLabel tslServerVariables;
        private System.Windows.Forms.ToolStripLabel tslRoleCI;
        private System.Windows.Forms.ToolStripMenuItem miRunConfiguration;
        private System.Windows.Forms.SaveFileDialog sfdExportScript;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem installModulesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem installModulesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem1;
    }
}

