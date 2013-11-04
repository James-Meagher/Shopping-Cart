using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MemberShipSystem
{
    public partial class SubmitOrder : System.Web.UI.Page
    {
        ShoppingCart d;
        protected void Page_Load(object sender, EventArgs e)
        {
            ConfirmOrder.SetActiveView(ConfirmCart);
            d = (ShoppingCart)HttpContext.Current.Session["ShoppingCart"];
            if (d != null)
            {
                ShoppingCartDataList.DataSource = d.CreateDataSource();
                ShoppingCartDataList0.DataSource = d.CreateDataSource();
                ShoppingCartDataList.DataBind();
                ShoppingCartDataList0.DataBind();
                lblOrderTotPrice.Text = string.Format("{0} you are a {1} member", d.ShoppingCartTotal.ToString("C"), d.getShoppingCartType());
            }
            else
            {
                lblOrderTotPrice.Text = "Thier are no products in your Cart.";
                btnAcceptShoppingCart.Visible = false;
            }


            if (!IsPostBack)
            {
                ViewState["PreviousPage"] = Request.UrlReferrer.ToString();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect((string)ViewState["PreviousPage"]);
        }

        protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
           e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label PriceLabel = (Label)e.Item.FindControl("lblPrice");
                Label NameLabel = (Label)e.Item.FindControl("lblName");
                Label Quantity = (Label)e.Item.FindControl("lblQuantity");
                Label totalPrice = (Label)e.Item.FindControl("lblTotPrice");

                // Retrieve the text of the CurrencyColumn from the DataListItem
                // and convert the value to a Double.

                Decimal Price = Convert.ToDecimal(((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString());
                int ID = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString());
                string Name = (((DataRowView)e.Item.DataItem).Row.ItemArray[1].ToString()).Replace('"', ' ');
                int Qty = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[3].ToString());
                Decimal Total = Convert.ToDecimal(((DataRowView)e.Item.DataItem).Row.ItemArray[4].ToString());


                // Format the value as currency and redisplay it in the DataList.   
                PriceLabel.Text = Price.ToString("c");
                NameLabel.Text = Name;
                totalPrice.Text = Total.ToString("c");
                Quantity.Text = Qty.ToString();
            }
        }

        protected void btnAcceptShoppingCart_Click(object sender, EventArgs e)
        {
            ConfirmOrder.SetActiveView(CustomerDetails);
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            ConfirmOrder.SetActiveView(PaymentDetails);
        }

        protected void btnCustomerDetailsBack_Click(object sender, EventArgs e)
        {
            ConfirmOrder.SetActiveView(CustomerDetails);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (isValidCreditCardNumber() && isValidDate() && isCardVerValid())
            {
                long CCNumber = long.Parse(txtCreditCard.Text);
                string CCType = ddlCreditType.SelectedValue;
                string ExpDate = string.Format("{0}/{1}", DropDownList2.SelectedValue, DropDownList3.SelectedValue);
                int CardVerNum = int.Parse(txtCardVer.Text);

                txtFirstName0.Text = txtFirstName.Text;
                txtLastName0.Text = txtLastName.Text;
                txtCity1.Text = txtCity.Text;
                txtCity2.Text = txtCity0.Text;
                txtPostcode0.Text = txtPostcode.Text;
                txtTelephone0.Text = txtTelephone.Text;
                txtAddres3.Text = txtAddres1.Text;
                txtAddres4.Text = txtAddres2.Text;
                txtState0.Text = txtState.Text;


                lblUserCardType.Text = CCType;
                lblUserCardNum.Text = CCNumber.ToString();
                lblUserCardExp.Text = ExpDate;
                lblUserCardVerNum.Text = CardVerNum.ToString();


                ConfirmOrder.SetActiveView(Final);
            }
            else
            {
                CustomValidator1.IsValid = isValidCreditCardNumber();
                CustomValidator2.IsValid = isValidDate();
                CustomValidator3.IsValid = isCardVerValid();
                ConfirmOrder.SetActiveView(PaymentDetails);
            }
        }

        private bool isCardVerValid()
        {
            int x;
            return ((txtCardVer.Text.Length == 3 || txtCardVer.Text.Length == 4) && int.TryParse(txtCardVer.Text, out x)) ? true : false;
        }

        private bool isValidDate()
        {
            return (DropDownList2.Text != "Month" && DropDownList3.Text != "Year") ? true : false;
        }

        private bool isValidCreditCardNumber()
        {
            switch (ddlCreditType.Text)
            {
                case "--Please Select--":
                    return false;
                case "American Express":
                    long number;
                    bool isNumber = long.TryParse(txtCreditCard.Text.ToString(), out number);
                    return (txtCreditCard.Text.ToCharArray().ElementAt<char>(0).ToString() == "3" && txtCreditCard.Text.Length == 15 && isNumber);

                case "Visa":
                    long number1;
                    bool isNumber1 = long.TryParse(txtCreditCard.Text, out number1);
                    char[] numdddd = { '2', '3', '4', '5', '6' };
                    return (numdddd.Any<char>(z => z == txtCreditCard.Text.ToCharArray().ElementAt<char>(0)) && txtCreditCard.Text.Length == 16 && isNumber1);

                case "Master Card":
                    long number2;
                    bool isNumber2 = long.TryParse(txtCreditCard.Text, out number2);
                    return (txtCreditCard.Text.ToCharArray().ElementAt<char>(0).ToString() == "5" && txtCreditCard.Text.Length == 16 && isNumber2);
                default:
                    return false;
            }
        }

        protected void ShoppingCartDataList0_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
        e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label PriceLabel = (Label)e.Item.FindControl("lblPrice0");
                Label NameLabel = (Label)e.Item.FindControl("lblName0");
                Label Quantity = (Label)e.Item.FindControl("lblQuantity0");
                Label totalPrice = (Label)e.Item.FindControl("lblTotPrice0");


                // Retrieve the text of the CurrencyColumn from the DataListItem
                // and convert the value to a Double.

                Decimal Price = Convert.ToDecimal(((DataRowView)e.Item.DataItem).Row.ItemArray[2].ToString());
                int ID = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[0].ToString());
                string Name = (((DataRowView)e.Item.DataItem).Row.ItemArray[1].ToString()).Replace('"', ' ');
                int Qty = Convert.ToInt32(((DataRowView)e.Item.DataItem).Row.ItemArray[3].ToString());
                Decimal Total = Convert.ToDecimal(((DataRowView)e.Item.DataItem).Row.ItemArray[4].ToString());


                // Format the value as currency and redisplay it in the DataList.   
                PriceLabel.Text = Price.ToString("c");
                NameLabel.Text = Name;
                totalPrice.Text = Total.ToString("c");
                Quantity.Text = Qty.ToString();
            }

        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            var info = new CustomerInfo();
            info.Items = d.Items;
            info.City = string.Format("{0} {1}", txtCity.Text, txtCity0.Text);
            info.Address = string.Format("{0} {1}", txtAddres1.Text, txtAddres2.Text);
            info.Name = string.Format("{0} {1}", txtFirstName.Text, txtLastName.Text);
            info.State = txtState.Text;
            info.Telephone = txtTelephone.Text;
            info.Zip = txtPostcode.Text;
            info.email = txtEmail.Text;
            info.CCNumber = long.Parse(txtCreditCard.Text);
            info.CCType = ddlCreditType.SelectedValue;
            info.ExpDate = string.Format("{0}/{1}", DropDownList2.SelectedValue, DropDownList3.SelectedValue);
            info.CardVerNum = int.Parse(txtCardVer.Text);


            MembershipSystemContext cont = new MembershipSystemContext();
            Order newOrder = new Order { Date = DateTime.Now, ProductInfo = info.setProductInfo(), Prices = d.ShoppingCartTotal.ToString(), UserId = (int?)HttpContext.Current.Session["UserId"] };
            cont.Orders.Add(newOrder);
            cont.SaveChanges();

            var id = newOrder.OrderId;


            MailMessage message = new MailMessage();
            message.To.Add(info.email);
            message.From = new MailAddress("stallholder@TheShop.com");
            message.Subject = "Your order has been processed";
            message.Body = info.getEmailContent(id);
            SmtpClient smtp = new SmtpClient("localhost");
            smtp.Send(message);

            message.Body = info.getEmailContent(id);

            Response.Redirect(@"/OrderConfirmation.aspx");
        }
    }
}