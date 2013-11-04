<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCartPopup.aspx.cs" Inherits="MemberShipSystem.ShoppingCartPopup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            height: 23px;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>


            <br />
            <br />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" ChildrenAsTriggers="true" UpdateMode="Always">

                <ContentTemplate>
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style2">
                                <asp:DataList ID="DataList1" runat="server" OnItemDataBound="DataList1_ItemDataBound">
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
                                                </td>
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
                                                    <asp:TextBox ID="txtQuantity" Width="20" runat="server" AutoPostBack="True"></asp:TextBox>
                                                    <asp:Label ID="lblAmtVoted" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:DataList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DataList1" EventName="UpdateCommand" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
