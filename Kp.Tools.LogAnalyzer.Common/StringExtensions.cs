using System;

namespace Kp.Tools.LogAnalyzer.Common
{
    public static class StringExtensions
    {
        public static string ExtractRelativePath(this string path, string basePath)
        {
            if (string.IsNullOrEmpty(path) || string.IsNullOrEmpty(basePath)) { return path; }

            basePath = basePath.TrimEnd('\\');
            if (basePath.Length > path.Length || !path.StartsWith(basePath, StringComparison.OrdinalIgnoreCase)) { return path; }

            string relativePath = path.Substring(basePath.Length);
            if (relativePath.Length == 0) { return relativePath; }
            if (relativePath[0] == '\\') { return relativePath.TrimStart('\\'); }
            return path;
        }
    }
}