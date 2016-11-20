using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

using Kp.Tools.LogAnalyzer.Common;

namespace Tests.Kp.Tools.LogAnalyzer.Common
{
    /// <summary>
    /// In this class, these terms are used:
    /// - Ideal ItemStartKeyword: a ItemStartKeyword which is neither null nor empty
    /// - Ideal Search Text: a search text which is neither null nor empty
    /// </summary>
    [TestClass]
    public class LogReaderTests
    {
        private static readonly IList<string> s_TestSourceLines = new List<string>()
        {
            "[2016.10.05 1] This is an error", // Line 0
            "Stack trace: ",
            "NullReferenceException at...",

            "[2016.10.05 2] INFO DEmo Customer logged on", // Line 3

            "[2016.10.05 3] WARN DEMO Customer logged on again", // Line 4
            "Sub info: Line",

            "[2016.10.05 4] ERR Something", // Line 6
            "Stack trace: ",
            "ProviderException at...",
        };



        #region This region tests how items are identified by ItemStartKeyword

        [TestMethod]
        public void Analyze_Returns_EachLineAsAnItem_For_EmptyItemStartKeyword()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "",
                ItemStartKeywordIsRegex = ValueGenerator.RandomBoolean(),
                SearchText = ""
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(s_TestSourceLines.Count, resultItems.Count);
            for (var i = 0; i < s_TestSourceLines.Count; i++)
            {
                var resultItem = resultItems[i];
                Assert.AreEqual(s_TestSourceLines[i], resultItem.FirstLine);
                Assert.AreEqual(i, resultItem.LineNo);
                Assert.AreEqual(1, resultItem.Contents.Count);
            }
        }

        [TestMethod]
        public void Analyze_SplitsItems_BasedOnItemStartKeyword()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "["
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(4, resultItems.Count);
            AssertProperLogItem(resultItems[0], 0, 3);
            AssertProperLogItem(resultItems[1], 3, 1);
            AssertProperLogItem(resultItems[2], 4, 2);
            AssertProperLogItem(resultItems[3], 6, 3);
        }

        [TestMethod]
        public void Analyze_SplitsItems_BasedOnItemStartKeyword_Regex()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = @"\[",
                ItemStartKeywordIsRegex = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(4, resultItems.Count);
            AssertProperLogItem(resultItems[0], 0, 3);
            AssertProperLogItem(resultItems[1], 3, 1);
            AssertProperLogItem(resultItems[2], 4, 2);
            AssertProperLogItem(resultItems[3], 6, 3);
        }

        #endregion



        #region This region tests how items are INCLUSIVELY filtered by SearchText. All tests in this region will use an ideal ItemStartKeyword and an ideal SearchText.

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseInsensitiveSearchText()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo"
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(2, resultItems.Count);
            AssertProperLogItem(resultItems[0], 3, 1);
            AssertProperLogItem(resultItems[1], 4, 2);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseSensitiveSearchText()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                SearchTextIsCaseSensitive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(0, resultItems.Count);
        }


        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseInsensitiveSearchText_WithStartLineBeginningAnItem()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                StartLine = 4
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(1, resultItems.Count);
            AssertProperLogItem(resultItems[0], 4, 2);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseSensitiveSearchText_WithStartLineBeginningAnItem()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                StartLine = 4,
                SearchTextIsCaseSensitive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(0, resultItems.Count);
        }


        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseInsensitiveSearchText_WithStartLineInMiddleOfAnItem()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                StartLine = 1
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(2, resultItems.Count);
            AssertProperLogItem(resultItems[0], 3, 1);
            AssertProperLogItem(resultItems[1], 4, 2);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseSensitiveSearchText_WithStartLineInMiddleOfAnItem()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                StartLine = 1,
                SearchTextIsCaseSensitive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(0, resultItems.Count);
        }


        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseInsensitiveSearchText_WithTopResults()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                TopResults = 1
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(1, resultItems.Count);
            AssertProperLogItem(resultItems[0], 3, 1);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseSensitiveSearchText_WithTopResults()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                TopResults = 1,
                SearchTextIsCaseSensitive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(0, resultItems.Count);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseInsensitiveSearchText_MatchingNotByFirstLine()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Stack"
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(2, resultItems.Count);
            AssertProperLogItem(resultItems[0], 0, 3);
            AssertProperLogItem(resultItems[1], 6, 3);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseSensitiveSearchText_MatchingNotByFirstLine()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Stack",
                SearchTextIsCaseSensitive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(2, resultItems.Count);
            AssertProperLogItem(resultItems[0], 0, 3);
            AssertProperLogItem(resultItems[1], 6, 3);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseInsensitiveSearchTextRegex()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "(StaCK)",
                SearchTextIsCaseSensitive = false,
                SearchTextIsRegex = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(2, resultItems.Count);
            AssertProperLogItem(resultItems[0], 0, 3);
            AssertProperLogItem(resultItems[1], 6, 3);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_InclusiveAndCaseSensitiveSearchTextRegex()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "(StaCK)",
                SearchTextIsCaseSensitive = true,
                SearchTextIsRegex = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(0, resultItems.Count);
        }

        #endregion



        #region This region tests how items are EXCLUSIVELY filtered by SearchText. All tests in this region will use an ideal ItemStartKeyword and an ideal SearchText.


        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_ExclusiveAndCaseInsensitiveSearchText()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                SearchTextIsExclusive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(2, resultItems.Count);
            AssertProperLogItem(resultItems[0], 0, 3);
            AssertProperLogItem(resultItems[1], 6, 3);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_ExclusiveAndCaseSensitiveSearchText()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                SearchTextIsCaseSensitive = true,
                SearchTextIsExclusive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(4, resultItems.Count);
            AssertProperLogItem(resultItems[0], 0, 3);
            AssertProperLogItem(resultItems[1], 3, 1);
            AssertProperLogItem(resultItems[2], 4, 2);
            AssertProperLogItem(resultItems[3], 6, 3);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_ExclusiveAndCaseInsensitiveSearchText_WithStartLineBeginningAnItem()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                StartLine = 4,
                SearchTextIsExclusive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(1, resultItems.Count);
            AssertProperLogItem(resultItems[0], 6, 3);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_ExclusiveAndCaseSensitiveSearchText_WithStartLineBeginningAnItem()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                StartLine = 4,
                SearchTextIsCaseSensitive = true,
                SearchTextIsExclusive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(2, resultItems.Count);
            AssertProperLogItem(resultItems[0], 4, 2);
            AssertProperLogItem(resultItems[1], 6, 3);

        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_ExclusiveAndCaseInsensitiveSearchText_WithStartLineInMiddleOfAnItem()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                StartLine = 1,
                SearchTextIsExclusive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(2, resultItems.Count);
            AssertProperLogItem(resultItems[0], 1, 2);
            AssertProperLogItem(resultItems[1], 6, 3);
        }

        [TestMethod]
        public void Analyze_Returns_MatchingItems_For_ExclusiveAndCaseSensitiveSearchText_WithStartLineInMiddleOfAnItem()
        {
            // Arrange
            var stringSource = SetUpTestStringSource();

            var options = new LogFilterOptions()
            {
                ItemStartKeyword = "[",
                SearchText = "Demo",
                StartLine = 1,
                SearchTextIsCaseSensitive = true,
                SearchTextIsExclusive = true
            };

            // Act
            var resultItems = LogReader.Analyze(stringSource, options);

            // Assert
            Assert.AreEqual(4, resultItems.Count);
            AssertProperLogItem(resultItems[0], 1, 2);
            AssertProperLogItem(resultItems[1], 3, 1);
            AssertProperLogItem(resultItems[2], 4, 2);
            AssertProperLogItem(resultItems[3], 6, 3);
        }

        #endregion



        private static void AssertProperLogItem(FilterResultItem item, int lineNo, int lineCount)
        {
            Assert.AreEqual(lineNo, item.LineNo);
            Assert.AreEqual(lineCount, item.Contents.Count);
            for (var i = 0; i < lineCount; i++)
            {
                Assert.AreEqual(s_TestSourceLines[lineNo + i], item.Contents[i]);
            }
        }

        private static IStringSource SetUpTestStringSource()
        {
            var stringSource = Substitute.For<IStringSource>();

            stringSource.Name.Returns("S1");

            int counter = 0;
            stringSource.GetLine().Returns(callInfo => counter >= s_TestSourceLines.Count ? null : s_TestSourceLines[counter++]);

            return stringSource;
        }
    }
}