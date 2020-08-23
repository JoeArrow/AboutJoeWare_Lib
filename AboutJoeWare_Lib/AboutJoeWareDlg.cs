
using System;
using System.Reflection;
using System.Windows.Forms;

namespace AboutJoeWare_Lib
{
    public partial class AboutJoeWareDlg : Form
    {
        private const int PADDING = 35;

        private Attribute[] assemblyAttributes = null;
        private Assembly ParentAssembly = Assembly.GetEntryAssembly();

        // ------------------------------------------------

        public AboutJoeWareDlg()
        {
            InitializeComponent();

            // ---------------------------------------------------------------------------------
            // This will retrieve the information from the app which loads this lib into memory.

            assemblyAttributes = ParentAssembly.GetCustomAttributes() as Attribute[];

            labelProductName.Text = AssemblyProduct;
            labelCopyright.Text = AssemblyCopyright;
            labelTrademark.Text = AssemblyTrademark;
            tbDescription.Text = AssemblyDescription;
            Text = string.Format("About {0}", AssemblyTitle);
            labelVersion.Text = string.Format("Version: {0}", AssemblyVersion);

            SetWidth(tbDescription.Text);
        }

        // ------------------------------------------------

        private void OnOk(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        // ------------------------------------------------

        private string AssemblyTitle
        {
            get
            {
                var attr = FindAttribute("Title");
                return attr == null ? string.Empty : ((AssemblyTitleAttribute)attr).Title;
            }
        }

        // ------------------------------------------------

        public string AssemblyVersion
        {
            get
            {
                return ParentAssembly.GetName().Version.ToString();
            }
        }

        // ------------------------------------------------

        private string AssemblyTrademark
        {
            get
            {
                var attr = FindAttribute("Trademark");
                return attr == null ? string.Empty : ((AssemblyTrademarkAttribute)attr).Trademark;
            }
        }

        // ------------------------------------------------

        private string AssemblyDescription
        {
            get
            {
                var attr = FindAttribute("Description");
                return attr == null ? string.Empty : ((AssemblyDescriptionAttribute)attr).Description;
            }
        }

        // ------------------------------------------------

        private string AssemblyProduct
        {
            get
            {
                var attr = FindAttribute("Product");
                return attr == null ? string.Empty : ((AssemblyProductAttribute)attr).Product;
            }
        }

        // ------------------------------------------------

        private string AssemblyCopyright
        {
            get
            {
                var attr = FindAttribute("Copyright");
                return attr == null ? string.Empty : ((AssemblyCopyrightAttribute)attr).Copyright;
            }
        }

        // ------------------------------------------------

        private Attribute FindAttribute(string name)
        {
            Attribute retVal = null;

            foreach(Attribute attr in assemblyAttributes)
            {
                var attrName = attr.GetType().Name;

                if(attrName.Equals(string.Format("Assembly{0}Attribute", name), StringComparison.CurrentCultureIgnoreCase))
                {
                    retVal = attr;
                    break;
                }
            }

            return retVal;
        }

        // ------------------------------------------------

        private void SetWidth(string verbiage)
        {
            var graphics = tbDescription.CreateGraphics();
            var iconWidth = iconDisplay.Width;

            // ------------------------
            // Just a starting Point...

            var final = 100;

            var lines = verbiage.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            foreach(var line in lines)
            {
                var textWidth = Convert.ToInt32(graphics.MeasureString(line, tbDescription.Font).Width);

                if(textWidth > final)
                {
                    final = textWidth;
                }
            }

            Width = final + iconWidth + PADDING;
        }
    }
}
