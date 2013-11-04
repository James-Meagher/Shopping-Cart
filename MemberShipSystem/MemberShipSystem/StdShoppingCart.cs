using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipSystem
{
    public class StdShoppingCart:ShoppingCart
    {
        public override string getShoppingCartType()
        {
            return "Standard";
        }
    }
}