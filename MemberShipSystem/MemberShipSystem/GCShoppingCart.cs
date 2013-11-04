using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipSystem
{
    public class GCShoppingCart:ShoppingCart
    {
        public override string getShoppingCartType() { return "Gold"; }


        public override void AddItem(OrderItem newOrder)
        {
            //Cuts 15% off cart items for Gold class members
            double x = (double)newOrder.Price;
            double s = x * 0.15;
            newOrder.Price -= (decimal)s;
            base.AddItem(newOrder);
        } 
    }
   
    
}