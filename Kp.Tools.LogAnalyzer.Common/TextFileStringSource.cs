using System.IO;

namespace Kp.Tools.LogAnalyzer.Common
{
    public class TextFileStringSource : IStringSource
    {
        private TextReader m_Reader;

        public TextFileStringSource(string name, TextReader reader)
        {
            m_Reader = reader;
            this.Name = name;
        }

        public string GetLine()
        {
            return m_Reader.ReadLine();
        }

        public string Name { get; set; }
    }
}