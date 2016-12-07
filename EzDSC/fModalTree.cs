using System;
using System.Windows.Forms;

namespace EzDSC
{
    // ReSharper disable once InconsistentNaming
    public partial class fModalTree : Form
    {
        public enum TreeType { TtResources, TtRoles }
        public object SelectedTag;

        public fModalTree(TreeNode node, ImageList list)
        {
            InitializeComponent();
            tvSelect.ImageList = list;
            tvSelect.Nodes.Add((TreeNode)node.Clone());
        }

        private void fModalTree_Load(object sender, EventArgs e)
        {

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            SelectedTag = tvSelect.SelectedNode.Tag;
        }
    }
}
