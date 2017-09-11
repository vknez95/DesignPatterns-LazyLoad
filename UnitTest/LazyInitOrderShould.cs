using System;
using LazyLoad.LazyInit;
using Xunit;

namespace UnitTest
{
    public class LazyInitOrderShould
    {
        [Fact]
        public void PrintLabelWithGoodOrder()
        {
            var order = new OrderGood();

            var result = order.PrintLabel();

            Assert.Equal("Company Name\nDefault Address", result);
        }

        [Fact]
        public void ThrowNullReferenceExceptionWhenPrintLabelWithBadOrder()
        {
            var order = new OrderBad();

            Assert.Throws<NullReferenceException>(() => order.PrintLabel());
        }

        [Fact]
        public void PrintLabelWithLazyOrder()
        {
            var order = new OrderLazy();

            var result = order.PrintLabel();

            Assert.Equal("Company Name\nDefault Address", result);
        }
    }
}
