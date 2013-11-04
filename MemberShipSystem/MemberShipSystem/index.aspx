<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="MemberShipSystem.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="btnShopFront" runat="server" Text="Add items to Order" OnClick="btnShopFront_Click"   />
        <asp:Button ID="btnAddProduct" runat="server" Text="Create Item" OnClick="btnAddProduct_Click" /> 
     <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click"  /> 
        <asp:Button ID="btnFinaliseOrder" runat="server" Text="Cart" OnClick="btnFinaliseOrder_Click" />
    </div>
    </form>
</body>
</html>
