using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kp.Tools.LogAnalyzer.Common
{
    /// <summary>
    /// Properties can be bound while fields can not.
    /// </summary>
    public class FilterResultItem
    {
        public int LineNo { get; set; }

        public IList<string> Contents { get; private set; }

        public string FirstLine
        {
            get
            {
                return (Contents.Count > 0 ? Contents[0] : null);
            }
        }

        public FilterResultItem()
        {
            Contents = new List<string>();
        }
    }
}