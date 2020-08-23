using System;
using System.Windows.Forms;

using AboutJoeWare_Lib;

namespace CheckOutTheAboutBox
{
    public partial class DemoForm : Form
    {
        public DemoForm()
        {
            InitializeComponent();
        }

        private void OnAbout(object sender, EventArgs e)
        {
            JoeWare.ShowAboutBox();
        }
    }
}
