using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MemberShipSystem
{
    public class AdditionalAttributes
    {
    }

    public partial class Product
    {
        public decimal Rating
        {
            get
            {
                if (AmtVoted != 0)
                    return (Score / AmtVoted);
                else
                    return 0;
            }
        }
    }
}
