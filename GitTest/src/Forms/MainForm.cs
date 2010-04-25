using System;
using System.Windows.Forms;
using GitTest.Extensions;

namespace GitTest.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void BtnGoClick(object sender, EventArgs e)
        {
            MessageBox.Show("Hello".GetHex());
        }

        private void BtnExitClick(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnTestExceptionClick(object sender, EventArgs e)
        {
            throw new ApplicationException("Test Exception");
        }
    }
}
