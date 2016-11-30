using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EzDSC
{
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
