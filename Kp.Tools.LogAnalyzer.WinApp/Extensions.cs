using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Kp.Tools.LogAnalyzer.WinApp
{
    public static class Extensions
    {
        public static void ShowInfo(this IWin32Window target, string message, params object[] args)
        {
            MessageBox.Show(target, string.Format(message, args), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(this IWin32Window target, string message, params object[] args)
        {
            MessageBox.Show(target, string.Format(message, args), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void ShowError(this IWin32Window target, string message, params object[] args)
        {
            MessageBox.Show(target, string.Format(message, args), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(this IWin32Window target, Exception exception)
        {
            MessageBox.Show(target, exception.Message + Environment.NewLine + exception.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(this IWin32Window target, Exception exception, string message, params object[] args)
        {
            string fullMessage = string.Format(message, args) + Environment.NewLine + exception.Message + Environment.NewLine + exception.StackTrace;
            MessageBox.Show(target, fullMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult Confirm(this IWin32Window target, string message, params object[] args)
        {
            string fullMessage = string.Format(message, args);
            return MessageBox.Show(target, fullMessage, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
        }

        /// <summary>
        /// </summary>
        /// <param name="form"></param>
        /// <param name="title">Contains up to 4 placeholders: {0} to {3}, correspondingly for these version parts:
        /// Major / MajorRevision / Minor / MinorRevision</param>
        public static void SetTitle(this Form form, string title)
        {
            var version = Assembly.GetEntryAssembly().GetName().Version;
            form.Text = string.Format(title, version.Major, version.MajorRevision, version.Minor, version.MinorRevision);
        }

        public static void SetFormTitleUsingAssemblyProduct(this Form form)
        {
            var productAttribute = form.GetExecutingAssemblyAttribute<AssemblyProductAttribute>();
            form.SetTitle(productAttribute.Product + " - v.{0}.{1}");
        }

        /// <summary>
        /// Get the first custom attribute of the executing assembly that has the specified type. 
        /// If no such attribute exists, return null.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static T GetExecutingAssemblyAttribute<T>(this IWin32Window target, bool inherit = false)
            where T : Attribute
        {
            object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(T), inherit);
            return (attributes.Length == 0 ? null : (T)attributes[0]);
        }

        public static bool ContainsDropDownItemWithTag(this ToolStripMenuItem menuItem, object tag)
        {
            if (tag == null) { return menuItem.HasDropDownItems; }

            foreach (var dropDownItem in menuItem.DropDownItems)
            {
                var item = dropDownItem as ToolStripMenuItem;
                if (item != null && tag.Equals(item.Tag)) { return true; }
            }

            return false;
        }

        public static string ReadEmbeddedResourceFileAsText(this string fileName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(n => n.EndsWith(fileName, StringComparison.OrdinalIgnoreCase));
            if (resourceName == null) { return null; }

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
        }
    }
}
