using System;
using System.Windows.Forms;

namespace EzDSC
{
    public partial class DialogText : Form
    {
        public string InputResult;

        public DialogText()
        {
            InitializeComponent();
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            InputResult = textboxInput.Text;
        }

        private void fModalName_Load(object sender, EventArgs e)
        {
            ActiveControl = textboxInput;
        }
    }
}
