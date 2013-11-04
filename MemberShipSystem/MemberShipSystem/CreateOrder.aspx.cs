using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemberShipSystem
{
    public partial class CreateOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["PreviousPage"] = Page.Request.UrlReferrer.ToString();
                ItemsList.DataSource = CreateDataSource();
                ItemsList.DataBind();
            }

            btnShowCart.OnClientClick = "javascript:window.open('ShoppingCartPopup.aspx', 'self','height=350,width=550');";
        }

        private object CreateDataSource()
        {
            DataTable dt = new DataTable();
            DataRow dr;


            MembershipSystemContext DBConn = new MembershipSystemContext();
            IEnumerable<Product> Products = DBConn.Products.ToList<Product>();

            // Define the columns of the table.
            dt.Columns.Add(new DataColumn("ProductId", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Name", typeof(String)));
            dt.Columns.Add(new DataColumn("Details", typeof(String)));
            dt.Columns.Add(new DataColumn("AmtVoted", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Price", typeof(decimal)));
            dt.Columns.Add(new DataColumn("Score", typeof(Int32)));
            dt.Columns.Add(new DataColumn("Rating", typeof(decimal)));

            // Populate the table with sample values.
            foreach (Product x in Products)
            {
                dr = dt.NewRow();

                dr[0] = x.ProductId;
                dr[1] = x.Name;
                dr[2] = x.Details;
                dr[3] = x.AmtVoted;
                dr[4] = x.Price;
                dr[5] = x.Score;
                dr[6] = x.Rating;

                dt.Rows.Add(dr);
            }

            DataView dv = new DataView(dt);
            return dv;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect(ViewState["PreviousPage"].ToString());
        }

        protected void ItemsList_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "btnPurchase")
            {
                var ItemsInfo = e.CommandArgument.ToString().Split('^');
                TextBox Qty = (TextBox)e.Item.FindControl("txtQuantity");

                if (HttpContext.Current.Session["ShoppingCart"] == null)
                {
                    var c = (string)HttpContext.Current.Session["Type"];
                    MemberPrivilege m = (c == null) ? MemberPrivilege.Standard : (MemberPrivilege)HttpContext.Current.Session["Type"];
                    ShoppingCart d = ShoppingCart.getShoppingCart(m);
                    HttpContext.Current.Session["ShoppingCart"] = d;
                    d.AddItem(new OrderItem { Name = ItemsInfo[0], ProductNum = int.Parse(ItemsInfo[2]), ProductQty = int.Parse(Qty.Text), Price = decimal.Parse(ItemsInfo[1]) });
                    
                }
                else
                {
                    ShoppingCart d = (ShoppingCart)HttpContext.Current.Session["ShoppingCart"];
                    d.AddItem(new OrderItem { Name = ItemsInfo[0], ProductNum = int.Parse(ItemsInfo[2]), ProductQty = int.Parse(Qty.Text), Price = decimal.Parse(ItemsInfo[1]) });
                }

            }
        }

        protected void ItemsList_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
          e.Item.ItemType == ListItemType.AlternatingItem)
            {

                // Retrieve the Label control in the current DataListItem.
                Label PriceLabel = (Label)e.Item.FindControl("lblPrice");
                Label ProductIdLabel = (Label)e.Item.FindControl("lblProductId");
                Label NameLabel = (Label)e.Item.FindControl("lblName");
                Label RatingLabel = (Label)e.Item.FindControl("lblRating");
                Label AmtVotedLabel = (Label)e.Item.FindControl("lblAmtVoted");
                Label DetailsLabel = (Label)e.Item.FindControl("lblDetails");

                Button PurchaseItem = (Button)e.Item.FindControl("btnPurchase");

                TextBox Quantity = (TextBox)e.Item.FindControl("txtQuantity");
                // Retrieve the text of the CurrencyColumn from the DataListItem
                // and convert the value to a Double.


                Decimal Price = Convert.ToDecimal(((DataRowView)e.Item.DataItem).Row.ItemArray[4].ToString());
                int ID = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString());
                string Name = (((DataRowView)e.Item.DataItem).Row.ItemArray[1].ToString()).Replace('"', ' ');
                int Score = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[5].ToString());
                int AmountVoted = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[3].ToString());
                string Details = (((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString()).Replace('"', ' '); ;
                Decimal Rating = Convert.ToDecimal(((DataRowView)e.Item.DataItem).Row.ItemArray[6].ToString());



                // Format the value as currency and redisplay it in the DataList.              

                PriceLabel.Text = Price.ToString("c");
                ProductIdLabel.Text = ID.ToString();
                NameLabel.Text = Name;
                RatingLabel.Text = Rating.ToString();
                AmtVotedLabel.Text = AmountVoted.ToString();
                DetailsLabel.Text = Details;

                PurchaseItem.CommandArgument = string.Format("{0}^{1}^{2}^{3}", Name, Price, ID, Quantity.ID);
            }
        }

    }
}