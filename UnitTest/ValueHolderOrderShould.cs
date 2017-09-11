using System;
using LazyLoad.ValueHolder;
using Xunit;

namespace UnitTest
{
    public class ValueHolderOrderShould
    {
        [Fact]
        public void NotLoadItemsUntilReferenced()
        {
            int orderId = 123;
            var order = new OrderFactory().CreateFromId(orderId);

            Assert.Equal(orderId, order.Id);

            // should trigger DB call
            var items = order.Items;

            Assert.Equal(0, items.Count);
        }
    }
}