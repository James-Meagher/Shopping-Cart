<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderConfirmation.aspx.cs" Inherits="MemberShipSystem.OrderConfirmation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <asp:Label ID="lblOrder" runat="server" Text="Thank you for your Order."></asp:Label>
        <br />
        <br />
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click"  />
    </div>
    </form>
</body>
</html>
