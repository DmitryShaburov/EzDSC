using System;
using System.Windows.Forms;

namespace EzDSC
{
    public partial class DialogTree : Form
    {
        public enum TreeType { TtResources, TtRoles }
        public object SelectedTag;

        public DialogTree(TreeNode node, ImageList list)
        {
            InitializeComponent();
            treeSelect.ImageList = list;
            treeSelect.Nodes.Add((TreeNode)node.Clone());
        }

        private void fModalTree_Load(object sender, EventArgs e)
        {

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            SelectedTag = treeSelect.SelectedNode.Tag;
        }
    }
}
