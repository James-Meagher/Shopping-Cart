using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipSystem
{
    public class OrderItem
    {
        public int ProductNum { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get { return Price * ProductQty; } }
        public int ProductQty { get; set; }
        public string Name { get; set; }

        public OrderItem()
        {

        }
        
    }
}