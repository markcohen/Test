using System;
using System.Windows.Forms;

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
            MessageBox.Show("Hello");
        }

        private void BtnExitClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
