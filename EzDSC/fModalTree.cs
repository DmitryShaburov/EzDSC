using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EzDSC
{
    public partial class fModalTree : Form
    {
        public enum TreeType { TtResources, TtRoles }
        public object SelectedTag;

        public fModalTree(TreeNode node)
        {
            InitializeComponent();
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
