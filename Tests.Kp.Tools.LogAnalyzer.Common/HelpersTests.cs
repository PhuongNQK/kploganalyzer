using Microsoft.VisualStudio.TestTools.UnitTesting;

using Kp.Tools.LogAnalyzer.Common;

namespace Tests.Kp.Tools.LogAnalyzer.Common
{
    [TestClass]
    public class HelpersTests
    {
        [TestMethod]
        public void BuildContentMatcher_ForNullOrEmptyFilter()
        {
            const int MaxLength = 1000; // MaxLength can be as big as int.MaxValue. However, I used 1000 for faster test run

            var matcherForNullFilter = Helpers.BuildContentMatcher(null, ValueGenerator.RandomBoolean(), ValueGenerator.RandomBoolean(), ValueGenerator.RandomBoolean());
            Assert.IsTrue(matcherForNullFilter(ValueGenerator.RandomString(maxLength: MaxLength)));

            var matcherForEmptyFilter = Helpers.BuildContentMatcher("", ValueGenerator.RandomBoolean(), ValueGenerator.RandomBoolean(), ValueGenerator.RandomBoolean());
            Assert.IsTrue(matcherForNullFilter(ValueGenerator.RandomString(maxLength: MaxLength)));
        }

        [TestMethod]
        public void BuildContentMatcher_ForIdealFilter_Contains()
        {
            const string Filter = "name";
            const string StringMatchingFilter_CaseSensitively = "my name";
            const string StringMatchingFilter_CaseInsensitively = "my NAME or";
            const string StringNotMatchingFilter = "my NAM or";

            BuildContentMatcherReturnsExpectedMatcherForIdealFilters(
                Filter,
                StringMatchingFilter_CaseSensitively,
                StringMatchingFilter_CaseInsensitively,
                StringNotMatchingFilter,
                CompareOperation.Contains);
        }

        [TestMethod]
        public void BuildContentMatcher_ForIdealFilter_StartsWith()
        {
            const string Filter = "name";
            const string StringMatchingFilter_CaseSensitively = "name my";
            const string StringMatchingFilter_CaseInsensitively = "NAME or";
            const string StringNotMatchingFilter = "my NAM or";

            BuildContentMatcherReturnsExpectedMatcherForIdealFilters(
                Filter,
                StringMatchingFilter_CaseSensitively,
                StringMatchingFilter_CaseInsensitively,
                StringNotMatchingFilter,
                CompareOperation.StartsWith);
        }

        [TestMethod]
        public void BuildContentMatcher_ForIdealFilter_EndsWith()
        {
            const string Filter = "name";
            const string StringMatchingFilter_CaseSensitively = "my name";
            const string StringMatchingFilter_CaseInsensitively = "my NAME";
            const string StringNotMatchingFilter = "my NAM or";

            BuildContentMatcherReturnsExpectedMatcherForIdealFilters(
                Filter, 
                StringMatchingFilter_CaseSensitively, 
                StringMatchingFilter_CaseInsensitively, 
                StringNotMatchingFilter,
                CompareOperation.EndsWith);
        }

        private static void BuildContentMatcherReturnsExpectedMatcherForIdealFilters(
            string Filter, string StringMatchingFilter_CaseSensitively, 
            string StringMatchingFilter_CaseInsensitively, string StringNotMatchingFilter,
            CompareOperation compareOperation)
        {
            var matcher01 = Helpers.BuildContentMatcher(Filter, false, false, false, compareOperation);
            Assert.IsTrue(matcher01(StringMatchingFilter_CaseSensitively));
            Assert.IsTrue(matcher01(StringMatchingFilter_CaseInsensitively));
            Assert.IsFalse(matcher01(StringNotMatchingFilter));

            var matcher02 = Helpers.BuildContentMatcher(Filter, false, false, true, compareOperation);
            Assert.IsFalse(matcher02(StringMatchingFilter_CaseSensitively));
            Assert.IsFalse(matcher02(StringMatchingFilter_CaseInsensitively));
            Assert.IsTrue(matcher02(StringNotMatchingFilter));

            var matcher03 = Helpers.BuildContentMatcher(Filter, false, true, false, compareOperation);
            Assert.IsTrue(matcher03(StringMatchingFilter_CaseSensitively));
            Assert.IsTrue(matcher03(StringMatchingFilter_CaseInsensitively));
            Assert.IsFalse(matcher03(StringNotMatchingFilter));

            var matcher04 = Helpers.BuildContentMatcher(Filter, false, true, true, compareOperation);
            Assert.IsFalse(matcher04(StringMatchingFilter_CaseSensitively));
            Assert.IsFalse(matcher04(StringMatchingFilter_CaseInsensitively));
            Assert.IsTrue(matcher04(StringNotMatchingFilter));

            var matcher05 = Helpers.BuildContentMatcher(Filter, true, false, false, compareOperation);
            Assert.IsTrue(matcher05(StringMatchingFilter_CaseSensitively));
            Assert.IsFalse(matcher05(StringMatchingFilter_CaseInsensitively));
            Assert.IsFalse(matcher05(StringNotMatchingFilter));

            var matcher06 = Helpers.BuildContentMatcher(Filter, true, false, true, compareOperation);
            Assert.IsFalse(matcher06(StringMatchingFilter_CaseSensitively));
            Assert.IsTrue(matcher06(StringMatchingFilter_CaseInsensitively));
            Assert.IsTrue(matcher06(StringNotMatchingFilter));

            var matcher07 = Helpers.BuildContentMatcher(Filter, true, true, false, compareOperation);
            Assert.IsTrue(matcher07(StringMatchingFilter_CaseSensitively));
            Assert.IsFalse(matcher07(StringMatchingFilter_CaseInsensitively));
            Assert.IsFalse(matcher07(StringNotMatchingFilter));

            var matcher08 = Helpers.BuildContentMatcher(Filter, true, true, true, compareOperation);
            Assert.IsFalse(matcher08(StringMatchingFilter_CaseSensitively));
            Assert.IsTrue(matcher08(StringMatchingFilter_CaseInsensitively));
            Assert.IsTrue(matcher08(StringNotMatchingFilter));
        }
    }
}