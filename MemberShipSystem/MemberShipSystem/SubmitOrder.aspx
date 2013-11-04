<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SubmitOrder.aspx.cs" Inherits="MemberShipSystem.SubmitOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .auto-style1 {
            width: 55%;
        }

        .auto-style2 {
            height: 26px;
        }

        .auto-style3 {
            width: 324px;
        }

        .auto-style4 {
            height: 45px;
        }

        .auto-style5 {
            height: 42px;
        }

        .auto-style6 {
            height: 23px;
        }

        .auto-style7 {
            width: 193px;
        }

        .auto-style8 {
            width: 193px;
            height: 19px;
        }

        .auto-style9 {
            height: 19px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:MultiView ID="ConfirmOrder" runat="server">
                <asp:View ID="ConfirmCart" runat="server">
                    <asp:DataList ID="ShoppingCartDataList" runat="server" OnItemDataBound="DataList1_ItemDataBound">
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblName" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblPrice" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblQuantity" runat="server"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotPrice" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:DataList>
                    <asp:Label ID="lblOrderTotPrice" runat="server"></asp:Label>
                    <asp:Button ID="btnAcceptShoppingCart" runat="server" Text="Confirm Shopping Cart" OnClick="btnAcceptShoppingCart_Click" Style="height: 26px" />
                </asp:View>
                <asp:View ID="CustomerDetails" runat="server">
                    Shipping Address<br />
                    <br />
                    <table class="auto-style1">
                        <tr>
                            <td>
                                <asp:Label ID="lblFistName" runat="server" AssociatedControlID="txtFirstName" Text="First Name"></asp:Label>
                                <asp:TextBox ID="txtFirstName" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName" Text="Last Name"></asp:Label>
                                <asp:TextBox ID="txtLastName" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtFirstName" Text="Address"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtAddres1" runat="server" Width="200px"></asp:TextBox><br />
                                <asp:TextBox ID="txtAddres2" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" AssociatedControlID="txtFirstName" Text="City"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtCity" runat="server" Width="200px"></asp:TextBox><br />
                            </td>
                            <td>
                                <asp:Label ID="lblState" runat="server" AssociatedControlID="txtFirstName" Text="State/Providence"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtState" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtCity0" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblState0" runat="server" AssociatedControlID="txtFirstName" Text="Zip/Postcode"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtPostcode" runat="server" Width="200px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblTelephone" runat="server" AssociatedControlID="txtFirstName" Text="Telephone"></asp:Label>
                                <br />
                                <asp:TextBox ID="txtTelephone" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>Email:<asp:TextBox ID="txtEmail" runat="server" Style="margin-bottom: 0px" Width="200px"></asp:TextBox>
                                <br />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2"></td>
                            <td class="auto-style2"></td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>
                                <asp:Button ID="btnPayment" runat="server" Text="Payment Details" OnClick="btnPayment_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:View>
                <asp:View ID="PaymentDetails" runat="server">
                    Credit Card Type<br />
                    <asp:DropDownList ID="ddlCreditType" runat="server">
                        <asp:ListItem>--Please Select--</asp:ListItem>
                        <asp:ListItem>American Express</asp:ListItem>
                        <asp:ListItem>Visa</asp:ListItem>
                        <asp:ListItem>Master Card</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    Credit Card Number<br />
                    <asp:TextBox ID="txtCreditCard" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCreditCard" ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ControlToValidate="txtCreditCard" ErrorMessage="Inaccurate Credit Card Number"></asp:CustomValidator>
                    <br />
                    <br />
                    Expiration Date<br />
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem>Month</asp:ListItem>
                        <asp:ListItem Value="01">January</asp:ListItem>
                        <asp:ListItem Value="02">Febuary</asp:ListItem>
                        <asp:ListItem Value="03">March</asp:ListItem>
                        <asp:ListItem Value="04">April</asp:ListItem>
                        <asp:ListItem Value="05">May</asp:ListItem>
                        <asp:ListItem Value="06">June</asp:ListItem>
                        <asp:ListItem Value="07">July</asp:ListItem>
                        <asp:ListItem Value="08">August</asp:ListItem>
                        <asp:ListItem Value="09">September</asp:ListItem>
                        <asp:ListItem Value="10">October</asp:ListItem>
                        <asp:ListItem Value="11">November</asp:ListItem>
                        <asp:ListItem Value="12">December</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="Expiring date is wrong"></asp:CustomValidator>
                    <br />
                    <asp:DropDownList ID="DropDownList3" runat="server">
                        <asp:ListItem>Year</asp:ListItem>
                        <asp:ListItem>2013</asp:ListItem>
                        <asp:ListItem>2014</asp:ListItem>
                        <asp:ListItem>2015</asp:ListItem>
                        <asp:ListItem>2016</asp:ListItem>
                        <asp:ListItem>2017</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                    Card Verification Number<br />
                    <asp:TextBox ID="txtCardVer" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCardVer" ErrorMessage="*" ValidationGroup="1"></asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="This will either be a 3 or 4 digit number"></asp:CustomValidator>
                    <br />
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="2" />
                    <br />
                    <asp:Button ID="btnCustomerDetailsBack" runat="server" Text="Customer Details" OnClick="btnCustomerDetailsBack_Click" />
                    <asp:Button ID="Button1" runat="server" Text="Confirm Order" OnClick="Button1_Click" />
                    <br />

                </asp:View>
                <asp:View ID="Final" runat="server">


                    <br />

                    <br />
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style3">
                                <asp:DataList ID="ShoppingCartDataList0" runat="server" OnItemDataBound="ShoppingCartDataList0_ItemDataBound">
                                    <ItemTemplate>
                                        <table class="auto-style1">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblName0" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblPrice0" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblQuantity0" runat="server"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblTotPrice0" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                                <asp:Label ID="lblOrderTotPrice0" runat="server"></asp:Label>
                            </td>
                            <td rowspan="2">
                                <table class="auto-style1">
                                    <tr>
                                        <td class="auto-style4">
                                            <asp:Label ID="lblFistName0" runat="server" AssociatedControlID="txtFirstName" Text="First Name"></asp:Label>
                                            <asp:Label ID="txtFirstName0" runat="server" Width="200px"></asp:Label>
                                        </td>
                                        <td class="auto-style4">
                                            <asp:Label ID="lblLastName0" runat="server" AssociatedControlID="txtLastName" Text="Last Name"></asp:Label>
                                            <asp:Label ID="txtLastName0" runat="server" Width="200px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblAddress0" runat="server" AssociatedControlID="txtFirstName" Text="Address"></asp:Label>
                                            <br />
                                            <asp:Label ID="txtAddres3" runat="server" Width="200px"></asp:Label>
                                            <br />
                                            <asp:Label ID="txtAddres4" runat="server" Width="200px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="auto-style5">
                                            <asp:Label ID="Label2" runat="server" AssociatedControlID="txtFirstName" Text="City"></asp:Label>
                                            <br />
                                            <asp:Label ID="txtCity1" runat="server" Width="200px"></asp:Label>
                                            <br />
                                        </td>
                                        <td class="auto-style5">
                                            <asp:Label ID="lblState1" runat="server" AssociatedControlID="txtFirstName" Text="State/Providence"></asp:Label>
                                            <br />
                                            <asp:Label ID="txtState0" runat="server" Width="200px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="txtCity2" runat="server" Width="200px"></asp:Label>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblState2" runat="server" AssociatedControlID="txtFirstName" Text="Zip/Postcode"></asp:Label>
                                            <br />
                                            <asp:Label ID="txtPostcode0" runat="server" Width="200px"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblTelephone0" runat="server" AssociatedControlID="txtFirstName" Text="Telephone"></asp:Label>
                                            <br />
                                            <asp:Label ID="txtTelephone0" runat="server" Width="200px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                        </tr>
                    </table>
                    <table class="auto-style1">
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style6" colspan="2"><strong>Payment Details</strong></td>
                        </tr>
                        <tr>
                            <td class="auto-style8">Credit Card Type</td>
                            <td class="auto-style9">
                                <asp:Label ID="lblUserCardType" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">Credit Card Number</td>
                            <td>
                                <asp:Label ID="lblUserCardNum" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">Expiration Date</td>
                            <td>
                                <asp:Label ID="lblUserCardExp" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style7">Card Verification Number</td>
                            <td>
                                <asp:Label ID="lblUserCardVerNum" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <br />


                    <asp:Button ID="btnConfirm" runat="server" Text="Confirm " OnClick="btnConfirm_Click" />


                </asp:View>

            </asp:MultiView>
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>
    </form>
</body>
</html>
