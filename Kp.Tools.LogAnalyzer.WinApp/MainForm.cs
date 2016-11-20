using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Kp.Tools.LogAnalyzer.WinApp
{
    public partial class MainForm : Form
    {
        private const string AnalyzerMenuItemTag = "Dyna";

        private int m_Counter = 1;

        public MainForm()
        {
            InitializeComponent();

            this.SetFormTitleUsingAssemblyProduct();
        }

        private void addAnalyzerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var analyzer = new LogAnalyzerForm();
            analyzer.MdiParent = this;
            analyzer.Visible = true;
            analyzer.Text = "Analyzer " + m_Counter++;

            var newToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem.Name = "addAnalyzerToolStripMenuItem";
            newToolStripMenuItem.Text = analyzer.Text;
            newToolStripMenuItem.Tag = AnalyzerMenuItemTag;
            newToolStripMenuItem.Click += (s, args) =>
            {
                analyzer.Activate();
                CheckAnalyzerMenuItem(newToolStripMenuItem);
            };

            analyzerListToolStripMenuItem.DropDownItems.Add(newToolStripMenuItem);
            analyzerListToolStripMenuItem.Enabled = analyzerListToolStripMenuItem.ContainsDropDownItemWithTag(AnalyzerMenuItemTag);

            analyzer.Activated += (s, args) =>
            {
                CheckAnalyzerMenuItem(newToolStripMenuItem);
            };

            analyzer.FormClosed += (s, args) =>
            {
                analyzerListToolStripMenuItem.DropDownItems.Remove(newToolStripMenuItem);
                analyzerListToolStripMenuItem.Enabled = analyzerListToolStripMenuItem.ContainsDropDownItemWithTag(AnalyzerMenuItemTag);
            };

            // Calling analyzer.Activate() here does not work, as when the form is added, it is activated by default.
            CheckAnalyzerMenuItem(newToolStripMenuItem);
        }

        private void CheckAnalyzerMenuItem(ToolStripMenuItem itemToCheck)
        {
            foreach (var item in analyzerListToolStripMenuItem.DropDownItems)
            {
                var menuItem = (item as ToolStripMenuItem);
                if (menuItem != null && AnalyzerMenuItemTag.Equals(menuItem.Tag)) { menuItem.Checked = false; }
            }

            itemToCheck.Checked = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Confirm("All opened analyzers will be closed. Are you sure you want to continue?") != DialogResult.Yes) { return; }

            foreach (var child in MdiChildren)
            {
                child.Close();
            }
        }
    }
}