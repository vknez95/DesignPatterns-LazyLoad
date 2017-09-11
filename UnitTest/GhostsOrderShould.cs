using System;
using System.Linq;
using LazyLoad.Ghosts;
using Xunit;

namespace UnitTest
{
    public class GhostsOrderShould
    {
        protected class TestOrderWrapper : Order
        {
            public bool WasLoadCalled = false;
            public int GetDataRowCount = 0;
            public TestOrderWrapper(int id) : base(id)
            {}

            public override void Load()
            {
                WasLoadCalled = true;
                base.Load();
            }

            protected override System.Collections.ArrayList GetDataRow()
            {
                GetDataRowCount++;
                return base.GetDataRow();
            }
        }

        [Fact]
        public void LoadItselfOnlyOnceOnPropertyAccess()
        {
            int orderId = 123;
            var order = new TestOrderWrapper(orderId);

            Assert.Equal(orderId, order.Id);
            Assert.False(order.WasLoadCalled);
            Assert.Equal(0, order.GetDataRowCount);

            // should call Load and GetDataRow once
            var shipMethod = order.ShipMethod;
            Assert.True(order.WasLoadCalled);
            Assert.Equal(1, order.GetDataRowCount);

            // should not increment GetDataRowCount
            var customer = order.Customer;
            Assert.True(order.WasLoadCalled);
            Assert.Equal(1, order.GetDataRowCount);
        }
        
        [Fact]
        public void LoadItemsInSingleCallOnPropertyAccess()
        {
            int orderId = 123;
            var order = new Order(orderId);

            int itemCount = order.Items.Count(); // should call repository here 
            Assert.Equal(3, itemCount); 
        }
    }
}