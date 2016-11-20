using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Kp.Tools.LogAnalyzer.Common
{
    public class LogReader
    {
        public static IList<FilterResultItem> Analyze(IStringSource source, LogFilterOptions options)
        {
            var resultItems = new List<FilterResultItem>();

            string currentLine;
            int lineNo = -1;
            FilterResultItem currentResultItem = null;
            bool matched = false;
            int resultCount = 0;
            int topResults = options.TopResults;

            Func<string, bool> itemStartChecker, searchTextChecker;

            var itemStartKeyword = options.ItemStartKeyword;
            itemStartChecker = Helpers.BuildContentMatcher(itemStartKeyword,
                options.ItemStartKeywordIsCaseSensitive, options.ItemStartKeywordIsRegex,
                false, CompareOperation.StartsWith);

            var searchText = options.SearchText;
            searchTextChecker = Helpers.BuildContentMatcher(searchText,
                options.SearchTextIsCaseSensitive, options.SearchTextIsRegex,
                false, CompareOperation.Contains);

            if (options.SearchTextIsExclusive)
            {
                while ((currentLine = source.GetLine()) != null)
                {
                    lineNo++;
                    if (lineNo < options.StartLine) { continue; }

                    if (itemStartChecker(currentLine))
                    {
                        if (!matched && currentResultItem != null)
                        {
                            resultItems.Add(currentResultItem);
                            resultCount++;
                            if (topResults > 0 && resultCount >= topResults) { break; }
                        }

                        currentResultItem = new FilterResultItem() { LineNo = lineNo };
                        currentResultItem.Contents.Add(currentLine);
                        matched = searchTextChecker(currentLine);
                        continue;
                    }

                    if (currentResultItem == null)
                    {
                        currentResultItem = new FilterResultItem() { LineNo = lineNo };
                    }

                    currentResultItem.Contents.Add(currentLine);

                    if (matched)
                    {
                        continue;
                    }

                    matched = searchTextChecker(currentLine);
                }

                // If the last item matches the exclusive filter, then add it
                if (currentLine == null // Last item
                    && !matched && currentResultItem != null
                    && (topResults <= 0 || resultCount < topResults))
                {
                    resultItems.Add(currentResultItem);
                }
            }
            else
            {
                while ((currentLine = source.GetLine()) != null)
                {
                    lineNo++;
                    if (lineNo < options.StartLine) { continue; }

                    if (itemStartChecker(currentLine))
                    {
                        currentResultItem = new FilterResultItem() { LineNo = lineNo };
                        currentResultItem.Contents.Add(currentLine);
                        matched = searchTextChecker(currentLine);
                        if (matched)
                        {
                            resultItems.Add(currentResultItem);
                            resultCount++;
                            if (topResults > 0 && resultCount >= topResults) { break; }
                        }
                        continue;
                    }

                    if (currentResultItem == null)
                    {
                        currentResultItem = new FilterResultItem() { LineNo = lineNo };
                    }

                    currentResultItem.Contents.Add(currentLine);

                    if (matched)
                    {
                        continue;
                    }

                    matched = searchTextChecker(currentLine);
                    if (matched)
                    {
                        resultItems.Add(currentResultItem);
                        resultCount++;
                        if (topResults > 0 && resultCount >= topResults) { break; }
                    }
                }
            }

            return resultItems;
        }
    }
}