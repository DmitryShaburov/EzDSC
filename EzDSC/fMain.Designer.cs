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
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Resources");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Roles");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Servers");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.cmRoles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miRolesAddGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.tssRoles = new System.Windows.Forms.ToolStripSeparator();
            this.miRolesNewRole = new System.Windows.Forms.ToolStripMenuItem();
            this.cmServers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miServersNewGroup = new System.Windows.Forms.ToolStripMenuItem();
            this.miServersNewServer = new System.Windows.Forms.ToolStripMenuItem();
            this.tssServers = new System.Windows.Forms.ToolStripSeparator();
            this.miBuildConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.tvLibrary = new System.Windows.Forms.TreeView();
            this.cmServerItem = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.miServerItemBuildConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.runConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.scServer = new System.Windows.Forms.SplitContainer();
            this.lbServerRoles = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbServerRoleAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbServerRoleRemove = new System.Windows.Forms.ToolStripButton();
            this.pgServerVariables = new System.Windows.Forms.PropertyGrid();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbVariableAdd = new System.Windows.Forms.ToolStripButton();
            this.tsbVariableRemove = new System.Windows.Forms.ToolStripButton();
            this.pgEditor = new System.Windows.Forms.PropertyGrid();
            this.pRolePanel = new System.Windows.Forms.Panel();
            this.lbRole = new System.Windows.Forms.ListBox();
            this.tsRole = new System.Windows.Forms.ToolStrip();
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
            this.cmRoles.SuspendLayout();
            this.cmServers.SuspendLayout();
            this.cmServerItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scServer)).BeginInit();
            this.scServer.Panel1.SuspendLayout();
            this.scServer.Panel2.SuspendLayout();
            this.scServer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.pRolePanel.SuspendLayout();
            this.tsRole.SuspendLayout();
            this.msMainMenu.SuspendLayout();
            this.cmResourceType.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmRoles
            // 
            this.cmRoles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miRolesAddGroup,
            this.tssRoles,
            this.miRolesNewRole});
            this.cmRoles.Name = "cmRoles";
            this.cmRoles.Size = new System.Drawing.Size(141, 54);
            // 
            // miRolesAddGroup
            // 
            this.miRolesAddGroup.Enabled = false;
            this.miRolesAddGroup.Name = "miRolesAddGroup";
            this.miRolesAddGroup.Size = new System.Drawing.Size(140, 22);
            this.miRolesAddGroup.Text = "Add group...";
            // 
            // tssRoles
            // 
            this.tssRoles.Name = "tssRoles";
            this.tssRoles.Size = new System.Drawing.Size(137, 6);
            // 
            // miRolesNewRole
            // 
            this.miRolesNewRole.Name = "miRolesNewRole";
            this.miRolesNewRole.Size = new System.Drawing.Size(140, 22);
            this.miRolesNewRole.Text = "New role...";
            this.miRolesNewRole.Click += new System.EventHandler(this.createRoleToolStripMenuItem_Click);
            // 
            // cmServers
            // 
            this.cmServers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miServersNewGroup,
            this.miServersNewServer,
            this.tssServers,
            this.miBuildConfiguration});
            this.cmServers.Name = "cmServers";
            this.cmServers.Size = new System.Drawing.Size(177, 76);
            // 
            // miServersNewGroup
            // 
            this.miServersNewGroup.Name = "miServersNewGroup";
            this.miServersNewGroup.Size = new System.Drawing.Size(176, 22);
            this.miServersNewGroup.Text = "New group...";
            this.miServersNewGroup.Click += new System.EventHandler(this.miServersNewGroup_Click);
            // 
            // miServersNewServer
            // 
            this.miServersNewServer.Name = "miServersNewServer";
            this.miServersNewServer.Size = new System.Drawing.Size(176, 22);
            this.miServersNewServer.Text = "New server...";
            this.miServersNewServer.Click += new System.EventHandler(this.miServersNewServer_Click);
            // 
            // tssServers
            // 
            this.tssServers.Name = "tssServers";
            this.tssServers.Size = new System.Drawing.Size(173, 6);
            // 
            // miBuildConfiguration
            // 
            this.miBuildConfiguration.Name = "miBuildConfiguration";
            this.miBuildConfiguration.Size = new System.Drawing.Size(176, 22);
            this.miBuildConfiguration.Text = "Build configuration";
            this.miBuildConfiguration.Click += new System.EventHandler(this.miBuildConfiguration_Click);
            // 
            // tvLibrary
            // 
            this.tvLibrary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLibrary.Location = new System.Drawing.Point(0, 0);
            this.tvLibrary.Name = "tvLibrary";
            treeNode7.Name = "tviResources";
            treeNode7.Text = "Resources";
            treeNode8.ContextMenuStrip = this.cmRoles;
            treeNode8.Name = "tviRoles";
            treeNode8.Text = "Roles";
            treeNode9.ContextMenuStrip = this.cmServers;
            treeNode9.Name = "tviServers";
            treeNode9.Text = "Servers";
            this.tvLibrary.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.tvLibrary.Size = new System.Drawing.Size(240, 514);
            this.tvLibrary.TabIndex = 0;
            this.tvLibrary.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvLibrary_AfterSelect);
            // 
            // cmServerItem
            // 
            this.cmServerItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miServerItemBuildConfiguration,
            this.runConfigurationToolStripMenuItem});
            this.cmServerItem.Name = "cmServerItem";
            this.cmServerItem.Size = new System.Drawing.Size(177, 48);
            // 
            // miServerItemBuildConfiguration
            // 
            this.miServerItemBuildConfiguration.Name = "miServerItemBuildConfiguration";
            this.miServerItemBuildConfiguration.Size = new System.Drawing.Size(176, 22);
            this.miServerItemBuildConfiguration.Text = "Build configuration";
            this.miServerItemBuildConfiguration.Click += new System.EventHandler(this.miServerItemBuildConfiguration_Click);
            // 
            // runConfigurationToolStripMenuItem
            // 
            this.runConfigurationToolStripMenuItem.Name = "runConfigurationToolStripMenuItem";
            this.runConfigurationToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.runConfigurationToolStripMenuItem.Text = "Run configuration";
            this.runConfigurationToolStripMenuItem.Click += new System.EventHandler(this.runConfigurationToolStripMenuItem_Click);
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
            this.scMain.Panel2.Controls.Add(this.scServer);
            this.scMain.Panel2.Controls.Add(this.pgEditor);
            this.scMain.Panel2.Controls.Add(this.pRolePanel);
            this.scMain.Size = new System.Drawing.Size(1250, 514);
            this.scMain.SplitterDistance = 240;
            this.scMain.TabIndex = 7;
            // 
            // scServer
            // 
            this.scServer.Location = new System.Drawing.Point(427, 147);
            this.scServer.Name = "scServer";
            this.scServer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scServer.Panel1
            // 
            this.scServer.Panel1.Controls.Add(this.lbServerRoles);
            this.scServer.Panel1.Controls.Add(this.toolStrip1);
            // 
            // scServer.Panel2
            // 
            this.scServer.Panel2.Controls.Add(this.pgServerVariables);
            this.scServer.Panel2.Controls.Add(this.toolStrip2);
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbServerRoleAdd,
            this.tsbServerRoleRemove});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(396, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbServerRoleAdd
            // 
            this.tsbServerRoleAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbServerRoleAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbServerRoleAdd.Image")));
            this.tsbServerRoleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbServerRoleAdd.Name = "tsbServerRoleAdd";
            this.tsbServerRoleAdd.Size = new System.Drawing.Size(42, 22);
            this.tsbServerRoleAdd.Text = "Add...";
            this.tsbServerRoleAdd.Click += new System.EventHandler(this.tsbServerRoleAdd_Click);
            // 
            // tsbServerRoleRemove
            // 
            this.tsbServerRoleRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbServerRoleRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbServerRoleRemove.Image")));
            this.tsbServerRoleRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbServerRoleRemove.Name = "tsbServerRoleRemove";
            this.tsbServerRoleRemove.Size = new System.Drawing.Size(63, 22);
            this.tsbServerRoleRemove.Text = "Remove...";
            this.tsbServerRoleRemove.Click += new System.EventHandler(this.tsbServerRoleRemove_Click);
            // 
            // pgServerVariables
            // 
            this.pgServerVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgServerVariables.HelpVisible = false;
            this.pgServerVariables.Location = new System.Drawing.Point(0, 25);
            this.pgServerVariables.Name = "pgServerVariables";
            this.pgServerVariables.Size = new System.Drawing.Size(396, 108);
            this.pgServerVariables.TabIndex = 1;
            this.pgServerVariables.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgServerVariables_PropertyValueChanged);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbVariableAdd,
            this.tsbVariableRemove});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(396, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbVariableAdd
            // 
            this.tsbVariableAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbVariableAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbVariableAdd.Image")));
            this.tsbVariableAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVariableAdd.Name = "tsbVariableAdd";
            this.tsbVariableAdd.Size = new System.Drawing.Size(39, 22);
            this.tsbVariableAdd.Text = "Add..";
            this.tsbVariableAdd.Click += new System.EventHandler(this.tsbVariableAdd_Click);
            // 
            // tsbVariableRemove
            // 
            this.tsbVariableRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbVariableRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbVariableRemove.Image")));
            this.tsbVariableRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbVariableRemove.Name = "tsbVariableRemove";
            this.tsbVariableRemove.Size = new System.Drawing.Size(63, 22);
            this.tsbVariableRemove.Text = "Remove...";
            // 
            // pgEditor
            // 
            this.pgEditor.Location = new System.Drawing.Point(74, 302);
            this.pgEditor.Name = "pgEditor";
            this.pgEditor.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.pgEditor.Size = new System.Drawing.Size(200, 75);
            this.pgEditor.TabIndex = 10;
            this.pgEditor.ToolbarVisible = false;
            this.pgEditor.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgEditor_PropertyValueChanged);
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
            this.tsbRoleAdd,
            this.tsbRoleRemove});
            this.tsRole.Location = new System.Drawing.Point(0, 0);
            this.tsRole.Name = "tsRole";
            this.tsRole.Size = new System.Drawing.Size(200, 25);
            this.tsRole.TabIndex = 6;
            this.tsRole.Text = "toolStrip1";
            // 
            // tsbRoleAdd
            // 
            this.tsbRoleAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRoleAdd.Image = ((System.Drawing.Image)(resources.GetObject("tsbRoleAdd.Image")));
            this.tsbRoleAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRoleAdd.Name = "tsbRoleAdd";
            this.tsbRoleAdd.Size = new System.Drawing.Size(42, 22);
            this.tsbRoleAdd.Text = "Add...";
            this.tsbRoleAdd.Click += new System.EventHandler(this.tsbRoleAdd_Click);
            // 
            // tsbRoleRemove
            // 
            this.tsbRoleRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRoleRemove.Image = ((System.Drawing.Image)(resources.GetObject("tsbRoleRemove.Image")));
            this.tsbRoleRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRoleRemove.Name = "tsbRoleRemove";
            this.tsbRoleRemove.Size = new System.Drawing.Size(63, 22);
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
            this.miResourceTypeNewConfigurationItem.Name = "miResourceTypeNewConfigurationItem";
            this.miResourceTypeNewConfigurationItem.Size = new System.Drawing.Size(209, 22);
            this.miResourceTypeNewConfigurationItem.Text = "New configuration item...";
            this.miResourceTypeNewConfigurationItem.Click += new System.EventHandler(this.miResourceTypeNewConfigurationItem_Click);
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
            this.scServer.Panel1.ResumeLayout(false);
            this.scServer.Panel1.PerformLayout();
            this.scServer.Panel2.ResumeLayout(false);
            this.scServer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scServer)).EndInit();
            this.scServer.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem miRolesAddGroup;
        private System.Windows.Forms.ToolStripSeparator tssRoles;
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbServerRoleAdd;
        private System.Windows.Forms.ToolStripButton tsbServerRoleRemove;
        private System.Windows.Forms.PropertyGrid pgServerVariables;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbVariableAdd;
        private System.Windows.Forms.ToolStripButton tsbVariableRemove;
        private System.Windows.Forms.ToolStripMenuItem runConfigurationToolStripMenuItem;
    }
}

