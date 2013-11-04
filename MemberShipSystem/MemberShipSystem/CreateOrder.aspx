<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateOrder.aspx.cs" Inherits="MemberShipSystem.CreateOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .auto-style2 {
            width: 60%;
        }

        .auto-style3 {
            width: 42px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <asp:DataList ID="ItemsList"
                BorderColor="#CC9966"
                CellPadding="4"
                RepeatColumns="1"
                runat="server"
                 BackColor="White" BorderStyle="None" BorderWidth="1px" GridLines="Both" OnItemCommand="ItemsList_ItemCommand" OnItemDataBound="ItemsList_ItemDataBound">

                <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />

                <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>

                <HeaderTemplate>
                    List of items

                </HeaderTemplate>

                <ItemStyle BackColor="White" ForeColor="#330099" />

                <ItemTemplate>


                    <table class="auto-style2">
                        <tr>
                            <td class="auto-style3">ID:#<asp:Label ID="lblProductId" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="lblRating" runat="server"></asp:Label>
                                (<asp:Label ID="lblAmtVoted" runat="server"></asp:Label>
                                &nbsp;votes)</td>
                        </tr>
                        <tr>
                            <td class="auto-style3">&nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="lblDetails" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style3" rowspan="2">&nbsp;</td>
                            <td rowspan="2">&nbsp;</td>
                            <td>
                                <asp:Label ID="lblPrice" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:TextBox ID="txtQuantity" Width="20" runat="server"></asp:TextBox>
                                <asp:Button ID="btnPurchase" CommandName="btnPurchase" runat="server" Text="buy" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>

                <SelectedItemStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />

            </asp:DataList>

            <br />
            <br />
            <asp:Button ID="btnShowCart" runat="server" Text="Show Cart" CausesValidation="False"/>

            <asp:Button ID="btnBack" runat="server"  Text="Back" OnClick="btnBack_Click" />

            <br />

    </div>
    </form>
</body>
</html>
