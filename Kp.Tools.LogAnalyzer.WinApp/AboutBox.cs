using System;
using System.Reflection;
using System.Windows.Forms;

namespace Kp.Tools.LogAnalyzer.WinApp
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            Text = String.Format("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelDescription.Text = AssemblyDescription;
            webBrowser.DocumentText = "Readme.html".ReadEmbeddedResourceFileAsText();
        }



        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                var assemblyTitleAttribute = this.GetExecutingAssemblyAttribute<AssemblyTitleAttribute>();
                var assemblyTitle = assemblyTitleAttribute?.Title;
                if (string.IsNullOrEmpty(assemblyTitle))
                {
                    assemblyTitle = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
                }
                return assemblyTitle;
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                var assemblyDescriptionAttribute = this.GetExecutingAssemblyAttribute<AssemblyDescriptionAttribute>();
                return assemblyDescriptionAttribute?.Description ?? "";
            }
        }

        public string AssemblyProduct
        {
            get
            {
                var assemblyProductAttribute = this.GetExecutingAssemblyAttribute<AssemblyProductAttribute>();
                return assemblyProductAttribute?.Product ?? "";
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                var assemblyCopyrightAttribute = this.GetExecutingAssemblyAttribute<AssemblyCopyrightAttribute>();
                return assemblyCopyrightAttribute?.Copyright ?? "";
            }
        }

        public string AssemblyCompany
        {
            get
            {
                var assemblyCompanyAttribute = this.GetExecutingAssemblyAttribute<AssemblyCompanyAttribute>();
                return assemblyCompanyAttribute?.Company ?? "";
            }
        }

        #endregion



        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}