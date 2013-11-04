using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemberShipSystem
{
    public partial class ShoppingCartPopup : System.Web.UI.Page
    {
        ShoppingCart d;
        protected void Page_Load(object sender, EventArgs e)
        {
            d = (ShoppingCart)HttpContext.Current.Session["ShoppingCart"];
            if (d != null && d.Items.Count != 0)
            {
                if (!IsPostBack)
                {
                    DataList1.DataSource = d.CreateDataSource();
                    DataList1.DataBind();
                    Label1.Text = d.ShoppingCartTotal.ToString("c");
                }
                else
                {
                    foreach (DataListItem cartItems in DataList1.Items)
                    {
                        Label PriceLabel = (Label)cartItems.FindControl("lblPrice");
                        Label ProductIdLabel = (Label)cartItems.FindControl("lblProductId");
                        Label NameLabel = (Label)cartItems.FindControl("lblName");
                        Label RatingLabel = (Label)cartItems.FindControl("lblRating");
                        Label totalPrice = (Label)cartItems.FindControl("lblAmtVoted");
                        Label DetailsLabel = (Label)cartItems.FindControl("lblDetails");
                        TextBox Quantity = (TextBox)cartItems.FindControl("txtQuantity");

                        int c = int.Parse(ProductIdLabel.Text);
                        d = (ShoppingCart)HttpContext.Current.Session["ShoppingCart"];
                        d.AddItem(new OrderItem { Name = NameLabel.Text, ProductNum = c, Price = decimal.Parse(PriceLabel.Text.Substring(1)), ProductQty = int.Parse(Quantity.Text) });

                    }
                    DataList1.DataSource = d.CreateDataSource();
                    DataList1.DataBind();
                    ShoppingCart ds = (ShoppingCart)HttpContext.Current.Session["ShoppingCart"];
                    Label1.Text = ds.ShoppingCartTotal.ToString("c");
                }
            }
            else
                Label1.Text = "Their are no items in the cart.";
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
            {


                // Retrieve the Label control in the current DataListItem.
                Label PriceLabel = (Label)e.Item.FindControl("lblPrice");
                Label ProductIdLabel = (Label)e.Item.FindControl("lblProductId");
                Label NameLabel = (Label)e.Item.FindControl("lblName");
                Label RatingLabel = (Label)e.Item.FindControl("lblRating");
                Label totalPrice = (Label)e.Item.FindControl("lblAmtVoted");
                Label DetailsLabel = (Label)e.Item.FindControl("lblDetails");

                TextBox Quantity = (TextBox)e.Item.FindControl("txtQuantity");

                Decimal Price = Convert.ToDecimal(((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString());
                int ID = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString());
                string Name = (((DataRowView)e.Item.DataItem).Row.ItemArray[1].ToString()).Replace('"', ' ');
                int Qty = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[3].ToString());
                Decimal Total = Convert.ToDecimal(((DataRowView)e.Item.DataItem).Row.ItemArray[4].ToString());

                PriceLabel.Text = Price.ToString("c");
                ProductIdLabel.Text = ID.ToString();
                NameLabel.Text = Name;
                totalPrice.Text = Total.ToString("c");
                Quantity.Text = Qty.ToString();
            }
        }

    }
}
