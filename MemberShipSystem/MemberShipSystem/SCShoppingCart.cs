using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipSystem
{
    public class SCShoppingCart : ShoppingCart
    {
        public override string getShoppingCartType() { return "Silver"; }

        public override void AddItem(OrderItem newOrder)
        {
            double x = (double)newOrder.Price;
            double s = x * 0.1;
            newOrder.Price -= (decimal)s;
            base.AddItem(newOrder);
        }
    }
}