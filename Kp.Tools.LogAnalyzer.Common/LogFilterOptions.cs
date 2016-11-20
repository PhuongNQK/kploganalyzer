using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kp.Tools.LogAnalyzer.Common
{
    public class LogFilterOptions
    {
        /// <summary>
        /// The number of top results to return. 0 means 'get all'.
        /// </summary>
        public int TopResults;

        /// <summary>
        /// The line to start the filter. The 1st line is 0.
        /// </summary>
        public int StartLine;


        /// <summary>
        /// If a line starts with this keyword, it is considered to be the first line of a log item.
        /// Typically, its value will be '['.
        /// For complex patterns, enable <see cref="ItemStartKeywordIsRegex"/>.
        /// </summary>
        public string ItemStartKeyword;

        public bool ItemStartKeywordIsCaseSensitive;

        public bool ItemStartKeywordIsRegex;



        /// <summary>
        /// The keywords that one of the line in a log item must contain to be included in the result list.
        /// For complex patterns, enable <see cref="SearchTextIsRegex"/>.
        /// </summary>
        public string SearchText;

        public bool SearchTextIsCaseSensitive;

        public bool SearchTextIsRegex;

        /// <summary>
        /// If true, search results are those that do not match the search text. If false, 
        /// search results are those that match the search text. Default value is false.
        /// </summary>
        public bool SearchTextIsExclusive;
    }
}
