using System;
using LazyLoad.VirtualProxy;
using Xunit;

namespace UnitTest
{
    public class VirtualProxyOrderShould
    {
        [Fact]
        public void PrintLabelWithOrderProxy()
        {
            int testOrderId = 123;
            var order = new OrderFactory().CreateFromId(testOrderId);

            Assert.Equal(testOrderId, order.Id); // should not have constructed Customer at this point

            string result = order.PrintLabel();

            Assert.Equal("Company Name\nDefault Address", result);
        }
    }
}