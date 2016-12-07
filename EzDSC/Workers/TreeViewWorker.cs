using System.Windows.Forms;

namespace EzDSC
{
    internal class TreeViewWorker
    {
        public static TreeNode TreeNodeAdd(string text, object tag, int image, ContextMenuStrip menu, TreeNode parent)
        {
            TreeNode node = parent.Nodes.Add(text);
            node.ImageIndex = image;
            node.SelectedImageIndex = image;
            node.ContextMenuStrip = menu;
            node.Tag = tag;
            return node;
        }
    }
}
