using System;
using System.Text.RegularExpressions;

namespace Kp.Tools.LogAnalyzer.Common
{
    public static class Helpers
    {
        /// <summary>
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="caseSensitive"></param>
        /// <param name="isRegex"></param>
        /// <param name="exclusive"></param>
        /// <param name="compareOperation">Effective when <paramref name="isRegex"/> is false.</param>
        /// <returns></returns>
        public static Func<string, bool> BuildContentMatcher(string filter, bool caseSensitive, bool isRegex, bool exclusive,
            CompareOperation compareOperation = CompareOperation.Contains)
        {
            Func<string, bool> contentMatcher;
            if (string.IsNullOrEmpty(filter))
            {
                contentMatcher = (line => true);
            }
            else if (isRegex)
            {
                var regex = new Regex(filter, caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase);
                if (exclusive)
                {
                    contentMatcher = (line => !regex.IsMatch(line));
                }
                else
                {
                    contentMatcher = (line => regex.IsMatch(line));
                }
            }
            else
            {
                var comparisonType = (caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);
                if (exclusive)
                {
                    switch (compareOperation)
                    {
                        case CompareOperation.EndsWith:
                            contentMatcher = (line => !line.EndsWith(filter, comparisonType));
                            break;
                        case CompareOperation.StartsWith:
                            contentMatcher = (line => !line.StartsWith(filter, comparisonType));
                            break;
                        default:
                            contentMatcher = (line => line.IndexOf(filter, comparisonType) == -1);
                            break;
                    }
                }
                else
                {
                    switch (compareOperation)
                    {
                        case CompareOperation.EndsWith:
                            contentMatcher = (line => line.EndsWith(filter, comparisonType));
                            break;
                        case CompareOperation.StartsWith:
                            contentMatcher = (line => line.StartsWith(filter, comparisonType));
                            break;
                        default:
                            contentMatcher = (line => line.IndexOf(filter, comparisonType) > -1);
                            break;
                    }
                }
            }

            return contentMatcher;
        }
    }
}