namespace EzDSC
{
    partial class FormMain
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
            System.Windows.Forms.ToolStripSeparator separatorRoleGroup1;
            System.Windows.Forms.ToolStripSeparator separatorServerGroup1;
            System.Windows.Forms.ToolStripSeparator separatorServerGroup2;
            System.Windows.Forms.ToolStripSeparator separatorServerGroup3;
            System.Windows.Forms.ToolStrip stripDependsOn;
            System.Windows.Forms.ToolStripLabel labelDepensOn;
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Resources");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Roles");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Servers");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.ToolStripSeparator separatorServer1;
            System.Windows.Forms.ToolStripSeparator separatorServer2;
            System.Windows.Forms.ToolStrip stripServerRoles;
            System.Windows.Forms.ToolStripLabel labelServerRoles;
            System.Windows.Forms.ToolStrip stripServerVariables;
            System.Windows.Forms.ToolStripLabel labelServerVariables;
            System.Windows.Forms.ToolStrip stripRoleItems;
            System.Windows.Forms.ToolStripLabel labelRoleConfigurationItems;
            System.Windows.Forms.ToolStripSeparator separatorMainFile1;
            this.menuRoleGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemRoleGroupNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRoleGroupNewRole = new System.Windows.Forms.ToolStripMenuItem();
            this.itemRoleGroupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuServerGroup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemServerGroupNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.itemServerGroupNewServer = new System.Windows.Forms.ToolStripMenuItem();
            this.itemServerGroupExport = new System.Windows.Forms.ToolStripMenuItem();
            this.itemServerGroupRun = new System.Windows.Forms.ToolStripMenuItem();
            this.itemServerGroupInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.itemServerGroupDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonConfigurationItemDependsOnAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonConfigurationItemDependsOnRemove = new System.Windows.Forms.ToolStripButton();
            this.treeLibrary = new System.Windows.Forms.TreeView();
            this.imagesMain = new System.Windows.Forms.ImageList(this.components);
            this.menuServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemServerExport = new System.Windows.Forms.ToolStripMenuItem();
            this.itemServerRun = new System.Windows.Forms.ToolStripMenuItem();
            this.itemServerInstall = new System.Windows.Forms.ToolStripMenuItem();
            this.itemServerDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMain = new System.Windows.Forms.SplitContainer();
            this.panelConfigurationItem = new System.Windows.Forms.SplitContainer();
            this.gridConfigurationItem = new System.Windows.Forms.PropertyGrid();
            this.listDependsOn = new System.Windows.Forms.ListBox();
            this.panelServer = new System.Windows.Forms.SplitContainer();
            this.listServerRoles = new System.Windows.Forms.ListBox();
            this.buttonServerRoleAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonServerRoleRemove = new System.Windows.Forms.ToolStripButton();
            this.gridServerVariables = new System.Windows.Forms.PropertyGrid();
            this.buttonVariableAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonVariableRemove = new System.Windows.Forms.ToolStripButton();
            this.panelRole = new System.Windows.Forms.Panel();
            this.listRoleItems = new System.Windows.Forms.ListBox();
            this.buttonRoleAdd = new System.Windows.Forms.ToolStripButton();
            this.buttonRoleRemove = new System.Windows.Forms.ToolStripButton();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.itemMainFile = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMainFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMainFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuResource = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemResourceNew = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.menuRole = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemRoleDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfigurationItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.itemConfigurationItemDelete = new System.Windows.Forms.ToolStripMenuItem();
            separatorRoleGroup1 = new System.Windows.Forms.ToolStripSeparator();
            separatorServerGroup1 = new System.Windows.Forms.ToolStripSeparator();
            separatorServerGroup2 = new System.Windows.Forms.ToolStripSeparator();
            separatorServerGroup3 = new System.Windows.Forms.ToolStripSeparator();
            stripDependsOn = new System.Windows.Forms.ToolStrip();
            labelDepensOn = new System.Windows.Forms.ToolStripLabel();
            separatorServer1 = new System.Windows.Forms.ToolStripSeparator();
            separatorServer2 = new System.Windows.Forms.ToolStripSeparator();
            stripServerRoles = new System.Windows.Forms.ToolStrip();
            labelServerRoles = new System.Windows.Forms.ToolStripLabel();
            stripServerVariables = new System.Windows.Forms.ToolStrip();
            labelServerVariables = new System.Windows.Forms.ToolStripLabel();
            stripRoleItems = new System.Windows.Forms.ToolStrip();
            labelRoleConfigurationItems = new System.Windows.Forms.ToolStripLabel();
            separatorMainFile1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuRoleGroup.SuspendLayout();
            this.menuServerGroup.SuspendLayout();
            stripDependsOn.SuspendLayout();
            this.menuServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).BeginInit();
            this.panelMain.Panel1.SuspendLayout();
            this.panelMain.Panel2.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelConfigurationItem)).BeginInit();
            this.panelConfigurationItem.Panel1.SuspendLayout();
            this.panelConfigurationItem.Panel2.SuspendLayout();
            this.panelConfigurationItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelServer)).BeginInit();
            this.panelServer.Panel1.SuspendLayout();
            this.panelServer.Panel2.SuspendLayout();
            this.panelServer.SuspendLayout();
            stripServerRoles.SuspendLayout();
            stripServerVariables.SuspendLayout();
            this.panelRole.SuspendLayout();
            stripRoleItems.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.menuResource.SuspendLayout();
            this.menuRole.SuspendLayout();
            this.menuConfigurationItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuRoleGroup
            // 
            this.menuRoleGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemRoleGroupNewGroup,
            this.itemRoleGroupNewRole,
            separatorRoleGroup1,
            this.itemRoleGroupDelete});
            this.menuRoleGroup.Name = "cmRoles";
            this.menuRoleGroup.Size = new System.Drawing.Size(143, 76);
            // 
            // itemRoleGroupNewGroup
            // 
            this.itemRoleGroupNewGroup.Image = global::EzDSC.Images.folder_new;
            this.itemRoleGroupNewGroup.Name = "itemRoleGroupNewGroup";
            this.itemRoleGroupNewGroup.Size = new System.Drawing.Size(142, 22);
            this.itemRoleGroupNewGroup.Text = "New group...";
            this.itemRoleGroupNewGroup.Click += new System.EventHandler(this.miRolesNewGroup_Click);
            // 
            // itemRoleGroupNewRole
            // 
            this.itemRoleGroupNewRole.Image = global::EzDSC.Images.document_new;
            this.itemRoleGroupNewRole.Name = "itemRoleGroupNewRole";
            this.itemRoleGroupNewRole.Size = new System.Drawing.Size(142, 22);
            this.itemRoleGroupNewRole.Text = "New role...";
            this.itemRoleGroupNewRole.Click += new System.EventHandler(this.createRoleToolStripMenuItem_Click);
            // 
            // separatorRoleGroup1
            // 
            separatorRoleGroup1.Name = "separatorRoleGroup1";
            separatorRoleGroup1.Size = new System.Drawing.Size(139, 6);
            // 
            // itemRoleGroupDelete
            // 
            this.itemRoleGroupDelete.Image = global::EzDSC.Images.edit_delete;
            this.itemRoleGroupDelete.Name = "itemRoleGroupDelete";
            this.itemRoleGroupDelete.Size = new System.Drawing.Size(142, 22);
            this.itemRoleGroupDelete.Text = "Delete";
            this.itemRoleGroupDelete.Click += new System.EventHandler(this.deleteToolStripMenuItem2_Click);
            // 
            // menuServerGroup
            // 
            this.menuServerGroup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemServerGroupNewGroup,
            this.itemServerGroupNewServer,
            separatorServerGroup1,
            this.itemServerGroupExport,
            this.itemServerGroupRun,
            separatorServerGroup2,
            this.itemServerGroupInstall,
            separatorServerGroup3,
            this.itemServerGroupDelete});
            this.menuServerGroup.Name = "cmServers";
            this.menuServerGroup.Size = new System.Drawing.Size(192, 154);
            // 
            // itemServerGroupNewGroup
            // 
            this.itemServerGroupNewGroup.Image = global::EzDSC.Images.folder_new;
            this.itemServerGroupNewGroup.Name = "itemServerGroupNewGroup";
            this.itemServerGroupNewGroup.Size = new System.Drawing.Size(191, 22);
            this.itemServerGroupNewGroup.Text = "New group...";
            this.itemServerGroupNewGroup.Click += new System.EventHandler(this.miServersNewGroup_Click);
            // 
            // itemServerGroupNewServer
            // 
            this.itemServerGroupNewServer.Image = global::EzDSC.Images.document_new;
            this.itemServerGroupNewServer.Name = "itemServerGroupNewServer";
            this.itemServerGroupNewServer.Size = new System.Drawing.Size(191, 22);
            this.itemServerGroupNewServer.Text = "New server...";
            this.itemServerGroupNewServer.Click += new System.EventHandler(this.miServersNewServer_Click);
            // 
            // separatorServerGroup1
            // 
            separatorServerGroup1.Name = "separatorServerGroup1";
            separatorServerGroup1.Size = new System.Drawing.Size(188, 6);
            // 
            // itemServerGroupExport
            // 
            this.itemServerGroupExport.Image = global::EzDSC.Images.document_save;
            this.itemServerGroupExport.Name = "itemServerGroupExport";
            this.itemServerGroupExport.Size = new System.Drawing.Size(191, 22);
            this.itemServerGroupExport.Text = "Export configuration...";
            this.itemServerGroupExport.Click += new System.EventHandler(this.miBuildConfiguration_Click);
            // 
            // itemServerGroupRun
            // 
            this.itemServerGroupRun.Image = global::EzDSC.Images.utilities_terminal;
            this.itemServerGroupRun.Name = "itemServerGroupRun";
            this.itemServerGroupRun.Size = new System.Drawing.Size(191, 22);
            this.itemServerGroupRun.Text = "Run configuration";
            this.itemServerGroupRun.Click += new System.EventHandler(this.miRunConfiguration_Click);
            // 
            // separatorServerGroup2
            // 
            separatorServerGroup2.Name = "separatorServerGroup2";
            separatorServerGroup2.Size = new System.Drawing.Size(188, 6);
            // 
            // itemServerGroupInstall
            // 
            this.itemServerGroupInstall.Image = global::EzDSC.Images.mail_send_receive;
            this.itemServerGroupInstall.Name = "itemServerGroupInstall";
            this.itemServerGroupInstall.Size = new System.Drawing.Size(191, 22);
            this.itemServerGroupInstall.Text = "Install modules";
            this.itemServerGroupInstall.Click += new System.EventHandler(this.installModulesToolStripMenuItem_Click);
            // 
            // separatorServerGroup3
            // 
            separatorServerGroup3.Name = "separatorServerGroup3";
            separatorServerGroup3.Size = new System.Drawing.Size(188, 6);
            // 
            // itemServerGroupDelete
            // 
            this.itemServerGroupDelete.Image = global::EzDSC.Images.edit_delete;
            this.itemServerGroupDelete.Name = "itemServerGroupDelete";
            this.itemServerGroupDelete.Size = new System.Drawing.Size(191, 22);
            this.itemServerGroupDelete.Text = "Delete";
            this.itemServerGroupDelete.Click += new System.EventHandler(this.deleteToolStripMenuItem1_Click);
            // 
            // stripDependsOn
            // 
            stripDependsOn.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            labelDepensOn,
            this.buttonConfigurationItemDependsOnAdd,
            this.buttonConfigurationItemDependsOnRemove});
            stripDependsOn.Location = new System.Drawing.Point(0, 0);
            stripDependsOn.Name = "stripDependsOn";
            stripDependsOn.Size = new System.Drawing.Size(347, 25);
            stripDependsOn.TabIndex = 0;
            stripDependsOn.Text = "toolStrip3";
            // 
            // labelDepensOn
            // 
            labelDepensOn.Name = "labelDepensOn";
            labelDepensOn.Size = new System.Drawing.Size(75, 22);
            labelDepensOn.Text = "Depends On:";
            // 
            // buttonConfigurationItemDependsOnAdd
            // 
            this.buttonConfigurationItemDependsOnAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonConfigurationItemDependsOnAdd.Image = global::EzDSC.Images.list_add;
            this.buttonConfigurationItemDependsOnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonConfigurationItemDependsOnAdd.Name = "buttonConfigurationItemDependsOnAdd";
            this.buttonConfigurationItemDependsOnAdd.Size = new System.Drawing.Size(23, 22);
            this.buttonConfigurationItemDependsOnAdd.Text = "Add...";
            this.buttonConfigurationItemDependsOnAdd.Click += new System.EventHandler(this.tsbCIAddDepends_Click);
            // 
            // buttonConfigurationItemDependsOnRemove
            // 
            this.buttonConfigurationItemDependsOnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonConfigurationItemDependsOnRemove.Image = global::EzDSC.Images.list_remove;
            this.buttonConfigurationItemDependsOnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonConfigurationItemDependsOnRemove.Name = "buttonConfigurationItemDependsOnRemove";
            this.buttonConfigurationItemDependsOnRemove.Size = new System.Drawing.Size(23, 22);
            this.buttonConfigurationItemDependsOnRemove.Text = "Remove...";
            this.buttonConfigurationItemDependsOnRemove.Click += new System.EventHandler(this.tsbCIRemoveDepends_Click);
            // 
            // treeLibrary
            // 
            this.treeLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeLibrary.ImageIndex = 0;
            this.treeLibrary.ImageList = this.imagesMain;
            this.treeLibrary.Location = new System.Drawing.Point(0, 0);
            this.treeLibrary.Name = "treeLibrary";
            treeNode1.Name = "tviResources";
            treeNode1.Text = "Resources";
            treeNode2.ContextMenuStrip = this.menuRoleGroup;
            treeNode2.Name = "tviRoles";
            treeNode2.Text = "Roles";
            treeNode3.ContextMenuStrip = this.menuServerGroup;
            treeNode3.ImageIndex = 0;
            treeNode3.Name = "tviServers";
            treeNode3.Text = "Servers";
            this.treeLibrary.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.treeLibrary.SelectedImageIndex = 0;
            this.treeLibrary.Size = new System.Drawing.Size(240, 514);
            this.treeLibrary.TabIndex = 0;
            this.treeLibrary.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLibrary_AfterSelect);
            this.treeLibrary.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvLibrary_NodeMouseClick);
            // 
            // imagesMain
            // 
            this.imagesMain.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imagesMain.ImageStream")));
            this.imagesMain.TransparentColor = System.Drawing.Color.Transparent;
            this.imagesMain.Images.SetKeyName(0, "folder");
            this.imagesMain.Images.SetKeyName(1, "text-x-generic");
            this.imagesMain.Images.SetKeyName(2, "network-server");
            // 
            // menuServer
            // 
            this.menuServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemServerExport,
            this.itemServerRun,
            separatorServer1,
            this.itemServerInstall,
            separatorServer2,
            this.itemServerDelete});
            this.menuServer.Name = "cmServerItem";
            this.menuServer.Size = new System.Drawing.Size(183, 104);
            // 
            // itemServerExport
            // 
            this.itemServerExport.Image = global::EzDSC.Images.document_save;
            this.itemServerExport.Name = "itemServerExport";
            this.itemServerExport.Size = new System.Drawing.Size(182, 22);
            this.itemServerExport.Text = "Export configuration";
            this.itemServerExport.Click += new System.EventHandler(this.miBuildConfiguration_Click);
            // 
            // itemServerRun
            // 
            this.itemServerRun.Image = global::EzDSC.Images.utilities_terminal;
            this.itemServerRun.Name = "itemServerRun";
            this.itemServerRun.Size = new System.Drawing.Size(182, 22);
            this.itemServerRun.Text = "Run configuration";
            this.itemServerRun.Click += new System.EventHandler(this.miRunConfiguration_Click);
            // 
            // separatorServer1
            // 
            separatorServer1.Name = "separatorServer1";
            separatorServer1.Size = new System.Drawing.Size(179, 6);
            // 
            // itemServerInstall
            // 
            this.itemServerInstall.Image = global::EzDSC.Images.mail_send_receive;
            this.itemServerInstall.Name = "itemServerInstall";
            this.itemServerInstall.Size = new System.Drawing.Size(182, 22);
            this.itemServerInstall.Text = "Install modules";
            this.itemServerInstall.Click += new System.EventHandler(this.installModulesToolStripMenuItem_Click);
            // 
            // separatorServer2
            // 
            separatorServer2.Name = "separatorServer2";
            separatorServer2.Size = new System.Drawing.Size(179, 6);
            // 
            // itemServerDelete
            // 
            this.itemServerDelete.Image = global::EzDSC.Images.edit_delete;
            this.itemServerDelete.Name = "itemServerDelete";
            this.itemServerDelete.Size = new System.Drawing.Size(182, 22);
            this.itemServerDelete.Text = "Delete";
            this.itemServerDelete.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 24);
            this.panelMain.Name = "panelMain";
            // 
            // panelMain.Panel1
            // 
            this.panelMain.Panel1.Controls.Add(this.treeLibrary);
            // 
            // panelMain.Panel2
            // 
            this.panelMain.Panel2.Controls.Add(this.panelConfigurationItem);
            this.panelMain.Panel2.Controls.Add(this.panelServer);
            this.panelMain.Panel2.Controls.Add(this.panelRole);
            this.panelMain.Size = new System.Drawing.Size(1250, 514);
            this.panelMain.SplitterDistance = 240;
            this.panelMain.TabIndex = 7;
            // 
            // panelConfigurationItem
            // 
            this.panelConfigurationItem.Location = new System.Drawing.Point(127, 201);
            this.panelConfigurationItem.Name = "panelConfigurationItem";
            this.panelConfigurationItem.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelConfigurationItem.Panel1
            // 
            this.panelConfigurationItem.Panel1.Controls.Add(this.gridConfigurationItem);
            // 
            // panelConfigurationItem.Panel2
            // 
            this.panelConfigurationItem.Panel2.Controls.Add(this.listDependsOn);
            this.panelConfigurationItem.Panel2.Controls.Add(stripDependsOn);
            this.panelConfigurationItem.Size = new System.Drawing.Size(347, 213);
            this.panelConfigurationItem.SplitterDistance = 139;
            this.panelConfigurationItem.TabIndex = 12;
            // 
            // gridConfigurationItem
            // 
            this.gridConfigurationItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridConfigurationItem.Location = new System.Drawing.Point(0, 0);
            this.gridConfigurationItem.Name = "gridConfigurationItem";
            this.gridConfigurationItem.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.gridConfigurationItem.Size = new System.Drawing.Size(347, 139);
            this.gridConfigurationItem.TabIndex = 10;
            this.gridConfigurationItem.ToolbarVisible = false;
            this.gridConfigurationItem.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgEditor_PropertyValueChanged);
            // 
            // listDependsOn
            // 
            this.listDependsOn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listDependsOn.FormattingEnabled = true;
            this.listDependsOn.Location = new System.Drawing.Point(0, 25);
            this.listDependsOn.Name = "listDependsOn";
            this.listDependsOn.Size = new System.Drawing.Size(347, 45);
            this.listDependsOn.TabIndex = 1;
            // 
            // panelServer
            // 
            this.panelServer.Location = new System.Drawing.Point(572, 61);
            this.panelServer.Name = "panelServer";
            this.panelServer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panelServer.Panel1
            // 
            this.panelServer.Panel1.Controls.Add(this.listServerRoles);
            this.panelServer.Panel1.Controls.Add(stripServerRoles);
            // 
            // panelServer.Panel2
            // 
            this.panelServer.Panel2.Controls.Add(this.gridServerVariables);
            this.panelServer.Panel2.Controls.Add(stripServerVariables);
            this.panelServer.Size = new System.Drawing.Size(396, 273);
            this.panelServer.SplitterDistance = 136;
            this.panelServer.TabIndex = 11;
            // 
            // listServerRoles
            // 
            this.listServerRoles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listServerRoles.FormattingEnabled = true;
            this.listServerRoles.Location = new System.Drawing.Point(0, 25);
            this.listServerRoles.Name = "listServerRoles";
            this.listServerRoles.Size = new System.Drawing.Size(396, 111);
            this.listServerRoles.TabIndex = 1;
            // 
            // stripServerRoles
            // 
            stripServerRoles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            labelServerRoles,
            this.buttonServerRoleAdd,
            this.buttonServerRoleRemove});
            stripServerRoles.Location = new System.Drawing.Point(0, 0);
            stripServerRoles.Name = "stripServerRoles";
            stripServerRoles.Size = new System.Drawing.Size(396, 25);
            stripServerRoles.TabIndex = 0;
            stripServerRoles.Text = "tsServerRoles";
            // 
            // labelServerRoles
            // 
            labelServerRoles.Name = "labelServerRoles";
            labelServerRoles.Size = new System.Drawing.Size(38, 22);
            labelServerRoles.Text = "Roles:";
            // 
            // buttonServerRoleAdd
            // 
            this.buttonServerRoleAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonServerRoleAdd.Image = global::EzDSC.Images.list_add;
            this.buttonServerRoleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonServerRoleAdd.Name = "buttonServerRoleAdd";
            this.buttonServerRoleAdd.Size = new System.Drawing.Size(23, 22);
            this.buttonServerRoleAdd.Text = "Add...";
            this.buttonServerRoleAdd.Click += new System.EventHandler(this.tsbServerRoleAdd_Click);
            // 
            // buttonServerRoleRemove
            // 
            this.buttonServerRoleRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonServerRoleRemove.Image = global::EzDSC.Images.list_remove;
            this.buttonServerRoleRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonServerRoleRemove.Name = "buttonServerRoleRemove";
            this.buttonServerRoleRemove.Size = new System.Drawing.Size(23, 22);
            this.buttonServerRoleRemove.Text = "Remove...";
            this.buttonServerRoleRemove.Click += new System.EventHandler(this.tsbServerRoleRemove_Click);
            // 
            // gridServerVariables
            // 
            this.gridServerVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridServerVariables.HelpVisible = false;
            this.gridServerVariables.Location = new System.Drawing.Point(0, 25);
            this.gridServerVariables.Name = "gridServerVariables";
            this.gridServerVariables.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.gridServerVariables.Size = new System.Drawing.Size(396, 108);
            this.gridServerVariables.TabIndex = 1;
            this.gridServerVariables.ToolbarVisible = false;
            this.gridServerVariables.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgServerVariables_PropertyValueChanged);
            // 
            // stripServerVariables
            // 
            stripServerVariables.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            labelServerVariables,
            this.buttonVariableAdd,
            this.buttonVariableRemove});
            stripServerVariables.Location = new System.Drawing.Point(0, 0);
            stripServerVariables.Name = "stripServerVariables";
            stripServerVariables.Size = new System.Drawing.Size(396, 25);
            stripServerVariables.TabIndex = 0;
            stripServerVariables.Text = "tsServerVariables";
            // 
            // labelServerVariables
            // 
            labelServerVariables.Name = "labelServerVariables";
            labelServerVariables.Size = new System.Drawing.Size(57, 22);
            labelServerVariables.Text = "Variables:";
            // 
            // buttonVariableAdd
            // 
            this.buttonVariableAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonVariableAdd.Image = global::EzDSC.Images.list_add;
            this.buttonVariableAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonVariableAdd.Name = "buttonVariableAdd";
            this.buttonVariableAdd.Size = new System.Drawing.Size(23, 22);
            this.buttonVariableAdd.Text = "Add..";
            this.buttonVariableAdd.Click += new System.EventHandler(this.tsbVariableAdd_Click);
            // 
            // buttonVariableRemove
            // 
            this.buttonVariableRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonVariableRemove.Image = global::EzDSC.Images.list_remove;
            this.buttonVariableRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonVariableRemove.Name = "buttonVariableRemove";
            this.buttonVariableRemove.Size = new System.Drawing.Size(23, 22);
            this.buttonVariableRemove.Text = "Remove...";
            this.buttonVariableRemove.Click += new System.EventHandler(this.tsbVariableRemove_Click);
            // 
            // panelRole
            // 
            this.panelRole.Controls.Add(this.listRoleItems);
            this.panelRole.Controls.Add(stripRoleItems);
            this.panelRole.Location = new System.Drawing.Point(3, 4);
            this.panelRole.Name = "panelRole";
            this.panelRole.Size = new System.Drawing.Size(200, 100);
            this.panelRole.TabIndex = 9;
            // 
            // listRoleItems
            // 
            this.listRoleItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listRoleItems.FormattingEnabled = true;
            this.listRoleItems.Location = new System.Drawing.Point(0, 25);
            this.listRoleItems.Name = "listRoleItems";
            this.listRoleItems.Size = new System.Drawing.Size(200, 75);
            this.listRoleItems.TabIndex = 7;
            // 
            // stripRoleItems
            // 
            stripRoleItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            labelRoleConfigurationItems,
            this.buttonRoleAdd,
            this.buttonRoleRemove});
            stripRoleItems.Location = new System.Drawing.Point(0, 0);
            stripRoleItems.Name = "stripRoleItems";
            stripRoleItems.Size = new System.Drawing.Size(200, 25);
            stripRoleItems.TabIndex = 6;
            stripRoleItems.Text = "toolStrip1";
            // 
            // labelRoleConfigurationItems
            // 
            labelRoleConfigurationItems.Name = "labelRoleConfigurationItems";
            labelRoleConfigurationItems.Size = new System.Drawing.Size(116, 22);
            labelRoleConfigurationItems.Text = "Configuration items:";
            // 
            // buttonRoleAdd
            // 
            this.buttonRoleAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRoleAdd.Image = global::EzDSC.Images.list_add;
            this.buttonRoleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRoleAdd.Name = "buttonRoleAdd";
            this.buttonRoleAdd.Size = new System.Drawing.Size(23, 22);
            this.buttonRoleAdd.Text = "Add...";
            this.buttonRoleAdd.Click += new System.EventHandler(this.tsbRoleAdd_Click);
            // 
            // buttonRoleRemove
            // 
            this.buttonRoleRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonRoleRemove.Image = global::EzDSC.Images.list_remove;
            this.buttonRoleRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonRoleRemove.Name = "buttonRoleRemove";
            this.buttonRoleRemove.Size = new System.Drawing.Size(23, 22);
            this.buttonRoleRemove.Text = "Remove...";
            this.buttonRoleRemove.Click += new System.EventHandler(this.tsbRoleRemove_Click);
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMainFile});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1250, 24);
            this.menuMain.TabIndex = 8;
            // 
            // itemMainFile
            // 
            this.itemMainFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMainFileOpen,
            separatorMainFile1,
            this.itemMainFileExit});
            this.itemMainFile.Name = "itemMainFile";
            this.itemMainFile.Size = new System.Drawing.Size(37, 20);
            this.itemMainFile.Text = "File";
            // 
            // itemMainFileOpen
            // 
            this.itemMainFileOpen.Image = global::EzDSC.Images.user_home;
            this.itemMainFileOpen.Name = "itemMainFileOpen";
            this.itemMainFileOpen.Size = new System.Drawing.Size(155, 22);
            this.itemMainFileOpen.Text = "Open / create...";
            this.itemMainFileOpen.Click += new System.EventHandler(this.miFileNew_Click);
            // 
            // separatorMainFile1
            // 
            separatorMainFile1.Name = "separatorMainFile1";
            separatorMainFile1.Size = new System.Drawing.Size(152, 6);
            // 
            // itemMainFileExit
            // 
            this.itemMainFileExit.Image = global::EzDSC.Images.system_log_out;
            this.itemMainFileExit.Name = "itemMainFileExit";
            this.itemMainFileExit.Size = new System.Drawing.Size(155, 22);
            this.itemMainFileExit.Text = "Exit";
            this.itemMainFileExit.Click += new System.EventHandler(this.miFileExit_Click);
            // 
            // menuResource
            // 
            this.menuResource.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemResourceNew});
            this.menuResource.Name = "cmResourceType";
            this.menuResource.Size = new System.Drawing.Size(210, 26);
            // 
            // itemResourceNew
            // 
            this.itemResourceNew.Image = global::EzDSC.Images.document_new;
            this.itemResourceNew.Name = "itemResourceNew";
            this.itemResourceNew.Size = new System.Drawing.Size(209, 22);
            this.itemResourceNew.Text = "New configuration item...";
            this.itemResourceNew.Click += new System.EventHandler(this.miResourceTypeNewConfigurationItem_Click);
            // 
            // dialogSaveFile
            // 
            this.dialogSaveFile.DefaultExt = "ps1";
            this.dialogSaveFile.Filter = "PowerShell Script|*.ps1";
            // 
            // menuRole
            // 
            this.menuRole.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemRoleDelete});
            this.menuRole.Name = "cmRoleItem";
            this.menuRole.Size = new System.Drawing.Size(108, 26);
            // 
            // itemRoleDelete
            // 
            this.itemRoleDelete.Image = global::EzDSC.Images.edit_delete;
            this.itemRoleDelete.Name = "itemRoleDelete";
            this.itemRoleDelete.Size = new System.Drawing.Size(107, 22);
            this.itemRoleDelete.Text = "Delete";
            this.itemRoleDelete.Click += new System.EventHandler(this.toolStripMenuItem6_Click);
            // 
            // menuConfigurationItem
            // 
            this.menuConfigurationItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemConfigurationItemDelete});
            this.menuConfigurationItem.Name = "cmConfigurationItem";
            this.menuConfigurationItem.Size = new System.Drawing.Size(108, 26);
            // 
            // itemConfigurationItemDelete
            // 
            this.itemConfigurationItemDelete.Image = global::EzDSC.Images.edit_delete;
            this.itemConfigurationItemDelete.Name = "itemConfigurationItemDelete";
            this.itemConfigurationItemDelete.Size = new System.Drawing.Size(107, 22);
            this.itemConfigurationItemDelete.Text = "Delete";
            this.itemConfigurationItemDelete.Click += new System.EventHandler(this.toolStripMenuItem7_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 538);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.menuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuMain;
            this.Name = "FormMain";
            this.Text = "EzDSC";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fMain_FormClosed);
            this.Load += new System.EventHandler(this.fMain_Load);
            this.menuRoleGroup.ResumeLayout(false);
            this.menuServerGroup.ResumeLayout(false);
            stripDependsOn.ResumeLayout(false);
            stripDependsOn.PerformLayout();
            this.menuServer.ResumeLayout(false);
            this.panelMain.Panel1.ResumeLayout(false);
            this.panelMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMain)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.panelConfigurationItem.Panel1.ResumeLayout(false);
            this.panelConfigurationItem.Panel2.ResumeLayout(false);
            this.panelConfigurationItem.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelConfigurationItem)).EndInit();
            this.panelConfigurationItem.ResumeLayout(false);
            this.panelServer.Panel1.ResumeLayout(false);
            this.panelServer.Panel1.PerformLayout();
            this.panelServer.Panel2.ResumeLayout(false);
            this.panelServer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelServer)).EndInit();
            this.panelServer.ResumeLayout(false);
            stripServerRoles.ResumeLayout(false);
            stripServerRoles.PerformLayout();
            stripServerVariables.ResumeLayout(false);
            stripServerVariables.PerformLayout();
            this.panelRole.ResumeLayout(false);
            this.panelRole.PerformLayout();
            stripRoleItems.ResumeLayout(false);
            stripRoleItems.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.menuResource.ResumeLayout(false);
            this.menuRole.ResumeLayout(false);
            this.menuConfigurationItem.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeLibrary;
        private System.Windows.Forms.ContextMenuStrip menuRoleGroup;
        private System.Windows.Forms.ToolStripMenuItem itemRoleGroupNewRole;
        private System.Windows.Forms.ContextMenuStrip menuServerGroup;
        private System.Windows.Forms.ToolStripMenuItem itemRoleGroupNewGroup;
        private System.Windows.Forms.ToolStripMenuItem itemServerGroupNewGroup;
        private System.Windows.Forms.ToolStripMenuItem itemServerGroupNewServer;
        private System.Windows.Forms.ContextMenuStrip menuServer;
        private System.Windows.Forms.ToolStripMenuItem itemServerExport;
        private System.Windows.Forms.ToolStripMenuItem itemServerGroupExport;
        private System.Windows.Forms.SplitContainer panelMain;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem itemMainFile;
        private System.Windows.Forms.ToolStripMenuItem itemMainFileOpen;
        private System.Windows.Forms.ToolStripMenuItem itemMainFileExit;
        private System.Windows.Forms.ContextMenuStrip menuResource;
        private System.Windows.Forms.ToolStripMenuItem itemResourceNew;
        private System.Windows.Forms.Panel panelRole;
        private System.Windows.Forms.ListBox listRoleItems;
        private System.Windows.Forms.ToolStripButton buttonRoleAdd;
        private System.Windows.Forms.ToolStripButton buttonRoleRemove;
        private System.Windows.Forms.PropertyGrid gridConfigurationItem;
        private System.Windows.Forms.SplitContainer panelServer;
        private System.Windows.Forms.ListBox listServerRoles;
        private System.Windows.Forms.ToolStripButton buttonServerRoleAdd;
        private System.Windows.Forms.ToolStripButton buttonServerRoleRemove;
        private System.Windows.Forms.PropertyGrid gridServerVariables;
        private System.Windows.Forms.ToolStripButton buttonVariableAdd;
        private System.Windows.Forms.ToolStripButton buttonVariableRemove;
        private System.Windows.Forms.ToolStripMenuItem itemServerRun;
        private System.Windows.Forms.SplitContainer panelConfigurationItem;
        private System.Windows.Forms.ToolStripButton buttonConfigurationItemDependsOnAdd;
        private System.Windows.Forms.ToolStripButton buttonConfigurationItemDependsOnRemove;
        private System.Windows.Forms.ListBox listDependsOn;
        private System.Windows.Forms.ImageList imagesMain;
        private System.Windows.Forms.ToolStripMenuItem itemServerGroupRun;
        private System.Windows.Forms.SaveFileDialog dialogSaveFile;
        private System.Windows.Forms.ToolStripMenuItem itemServerInstall;
        private System.Windows.Forms.ToolStripMenuItem itemServerGroupInstall;
        private System.Windows.Forms.ToolStripMenuItem itemServerDelete;
        private System.Windows.Forms.ToolStripMenuItem itemServerGroupDelete;
        private System.Windows.Forms.ToolStripMenuItem itemRoleGroupDelete;
        private System.Windows.Forms.ContextMenuStrip menuRole;
        private System.Windows.Forms.ToolStripMenuItem itemRoleDelete;
        private System.Windows.Forms.ContextMenuStrip menuConfigurationItem;
        private System.Windows.Forms.ToolStripMenuItem itemConfigurationItemDelete;
    }
}

