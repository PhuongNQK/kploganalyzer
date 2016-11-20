using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Kp.Tools.LogAnalyzer.Common
{
    public class LogWriter
    {
        /// <summary>
        /// </summary>
        /// <param name="data"></param>
        /// <param name="folderPath"></param>
        /// <param name="fileNameInferrer"></param>
        /// <param name="itemSeparator"></param>
        /// <param name="itemHeaderPattern">Accept these placeholders: {LineNo}</param>
        public static void WriteToFiles(Dictionary<string, IList<FilterResultItem>> data, string folderPath,
            Func<string, string> fileNameInferrer, string itemSeparator, string itemHeaderPattern = null)
        {
            MakeSureFolderExists(folderPath);

            if (fileNameInferrer == null)
            {
                fileNameInferrer = (name => name);
            }

            string fullPath;
            foreach (var name in data.Keys)
            {
                fullPath = Path.Combine(folderPath, fileNameInferrer(name));
                MakeSureFolderExists(Path.GetDirectoryName(fullPath));
                WriteToFile(data[name], fullPath, itemSeparator, itemHeaderPattern);
            }
        }

        public static void WriteToFile(IList<FilterResultItem> data, string fullPath, string itemSeparator,
            string itemHeaderPattern)
        {
            using (var writer = File.CreateText(fullPath))
            {
                foreach (var item in data)
                {
                    writer.Write(itemHeaderPattern.InjectSingleValue("LineNo", item.LineNo));
                    foreach (var line in item.Contents)
                    {
                        writer.WriteLine(line);
                    }
                    if (itemSeparator != null) { writer.Write(itemSeparator); }
                }
            }
        }

        private static void MakeSureFolderExists(string folderPath)
        {
            if (Directory.Exists(folderPath)) { return; }

            Directory.CreateDirectory(folderPath);
        }
    }
}
