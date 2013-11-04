<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateProduct.aspx.cs" Inherits="MemberShipSystem.CreateProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lblName" runat="server" Text="Name"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblDetails" runat="server" Text="Details"></asp:Label>
            <asp:TextBox ID="txtDetails" runat="server"></asp:TextBox><br />
            <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox><br />

            <asp:Button ID="btnAddProduct" runat="server" Text="Insert" OnClick="btnAddProduct_Click" style="width: 48px" />
        <asp:Button ID="btnBack" runat="server" OnClick="btnBack_Click" Text="Back" />
    </div>
    </form>
</body>
</html>
