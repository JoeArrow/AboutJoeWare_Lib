using System;
using System.Windows.Forms;

using AboutJoeWare_Lib;

namespace CheckOutTheAboutBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void OnAbout(object sender, EventArgs e)
        {
            JoeWare.ShowAboutBox();
        }
    }
}
