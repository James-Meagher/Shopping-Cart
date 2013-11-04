using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MemberShipSystem
{
    public class ShoppingCart
    {
        public List<OrderItem> Items = new List<OrderItem>();

        public decimal ShoppingCartTotal
        {
            get
            {
                decimal x = 0;
                Items.ForEach(delegate(OrderItem d)
                {
                    x += d.TotalPrice;
                }
                );
                return x;
            }
        }


        public virtual void AddItem(OrderItem newOrder)
        {
            if (Items.Any<OrderItem>(x => x.ProductNum == newOrder.ProductNum))
            {
                OrderItem newValues = Items.Find(x => x.ProductNum == newOrder.ProductNum);
                newValues.ProductQty = newOrder.ProductQty;
                Items.RemoveAll(x => x.ProductNum == newOrder.ProductNum);
                if (newValues.ProductQty > 0)
                    Items.Add(newValues);
            }
            else
            {
                if (newOrder.ProductQty > 0)
                    Items.Add(newOrder);
            }
        }


        public virtual string getShoppingCartType() { return "Standard"; }

        public ICollection CreateDataSource()
        {
            // Create sample data for the DataList control.
            DataTable dt = new DataTable();
            DataRow dr;

            ShoppingCart d = (ShoppingCart)HttpContext.Current.Session["ShoppingCart"];
            IEnumerable<OrderItem> ItemsToBuy = d.Items;
            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("ProductNum", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
            dt.Columns.Add(new DataColumn("ProductQty", typeof(Int32)));
            dt.Columns.Add(new DataColumn("TotalPrice", typeof(decimal)));


            // Populate the table with sample values.
            foreach (OrderItem x in ItemsToBuy)
            {
                dr = dt.NewRow();

                dr[0] = x.ProductNum;
                dr[1] = x.Name;
                dr[2] = x.Price;
                dr[3] = x.ProductQty;
                dr[4] = x.TotalPrice;

                dt.Rows.Add(dr);
            }


            DataView dv = new DataView(dt);
            return dv;
        }


        public static ShoppingCart getShoppingCart(MemberPrivilege? memberType)
        {
            int? s = (int)memberType;
            switch (s)
            {
                case 1:
                    return new StdShoppingCart();
                case 2:
                    return new SCShoppingCart();
                case 3:
                    return new GCShoppingCart();
                default:
                    return new StdShoppingCart();
            }
        }
    }
}