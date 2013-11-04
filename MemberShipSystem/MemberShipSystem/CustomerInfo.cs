using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipSystem
{
    public class CustomerInfo
    {

        public List<OrderItem> Items = new List<OrderItem>();
        public string Name;
        public string Address;
        public string City;
        public string State;
        public string Zip;
        public string Telephone;
        public string email;

        public string CCType;
        public long CCNumber;
        public string ExpDate;
        public int CardVerNum;

        public int OrderID;

        public string setProductInfo()
        {
            string returnable = "";
            foreach (OrderItem x in Items)
                returnable += string.Format("{0} {1} {2} {3}æ", x.ProductNum, x.ProductQty, x.Price, x.TotalPrice);
            return returnable;
        }


        public string getEmailContent(int OrderNumber)
        {
            return string.Format("Order#: {0} has been Processed {1}\n and will be delivered to\n {2}\n {3}\n {4}\n {5}\n\n\n\nCredit Details:\n{6}\n{7}\n{8}\n{9}", OrderNumber.ToString(), Name, Address, City, State, Zip, CCType, CCNumber, ExpDate, CardVerNum);
        }

    }
}