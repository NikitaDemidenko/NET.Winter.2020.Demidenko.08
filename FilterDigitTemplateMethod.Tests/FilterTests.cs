using System.Linq;
using NUnit.Framework;
using Moq;
using Moq.Protected;
using FilterTemplateMethod;

namespace FilterTemplateMethod.Tests
{
    public class FilterTests
    {
        [Test]
        public void FilterStateTest()
        {
            var mockFilter = new Mock<Filter>();

            mockFilter.Protected()
                .Setup<bool>("IsMatch", ItExpr.Is<int>(i => i.ToString().Contains("0")))
                .Returns(true);

            Filter filter = mockFilter.Object;

            int[] source = { 102, 3212, 0, 111, 1230, 100, int.MinValue, 801 };

            int[] expected = { 102, 0, 1230, 100, 801 };

            int[] actual = filter.FilterArrayByKey(source);

            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void FilterBehaviourTest()
        {
            var mockFilter = new Mock<Filter>();

            mockFilter.Protected()
                .Setup<bool>("IsMatch", ItExpr.IsAny<int>())
                .Returns(true);

            Filter filter = mockFilter.Object;

            int count = 10000;

            int[] source = Enumerable.Range(0, count).ToArray();

            filter.FilterArrayByKey(source);

            mockFilter.Protected().Verify("IsMatch", Times.Exactly(count), ItExpr.IsAny<int>());
        }
    }
}