using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kp.Tools.LogAnalyzer.Common;

namespace Tests.Kp.Tools.LogAnalyzer.Common
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void ExtractRelativePath_ReturnsPath_If_EitherPathOrBasePathIsNullOrEmpty()
        {
            string path = null;
            string basePath = null;
            Assert.IsNull(path.ExtractRelativePath(basePath));

            path = null;
            basePath = string.Empty;
            Assert.IsNull(path.ExtractRelativePath(basePath));

            path = string.Empty;
            basePath = null;
            Assert.AreEqual(string.Empty, path.ExtractRelativePath(basePath));

            path = string.Empty;
            basePath = string.Empty;
            Assert.AreEqual(string.Empty, path.ExtractRelativePath(basePath));
        }

        [TestMethod]
        public void ExtractRelativePath_ReturnsPath_If_PathDoesNotStartWithBasePath()
        {
            string path = @"C:\logs\abc";
            string basePath = @"D:\logs";
            
            Assert.AreEqual(path, path.ExtractRelativePath(basePath));
        }

        [TestMethod]
        public void ExtractRelativePath_ReturnsPath_If_BasePathIsNotLogicalPartOfPath()
        {
            string path = @"D:\logs\abc";
            string basePath = @"D:\log";

            Assert.AreEqual(path, path.ExtractRelativePath(basePath));
        }

        [TestMethod]
        public void ExtractRelativePath_ReturnsRelativePath()
        {
            string path = @"D:\logs\abc";
            string basePath = @"D:\logs";
            Assert.AreEqual("abc", path.ExtractRelativePath(basePath));
        }
    }
}