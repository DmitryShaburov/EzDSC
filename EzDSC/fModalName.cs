using System;
using System.Windows.Forms;

namespace EzDSC
{
    // ReSharper disable once InconsistentNaming
    public partial class fModalName : Form
    {
        public string InputResult;

        public fModalName()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            InputResult = tbInput.Text;
        }

        private void fModalName_Load(object sender, EventArgs e)
        {
            ActiveControl = tbInput;
        }
    }
}
