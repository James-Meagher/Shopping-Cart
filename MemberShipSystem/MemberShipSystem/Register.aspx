<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MemberShipSystem.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style type="text/css">
        .auto-style1 {
            width: 35%;
            border-style: solid;
            border-width: 1px;
        }
        .auto-style2 {
            height: 23px;
        }
        .auto-style3 {
            align-items:center;
            height: 49px;
        }
        .auto-style4 {
            height: 23px;
            width: 128px;
        }
        .auto-style5 {
            width: 128px;
        }
    </style>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table align="left" class="auto-style1">
            <tr>
                <td class="auto-style2">User Name:</td>
                <td class="auto-style4">
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password</td>
                <td class="auto-style5"><asp:TextBox ID="txtPassword" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Email</td>
                <td class="auto-style5"><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Security Question</td>
                <td class="auto-style5"><asp:TextBox ID="txtQuestion" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Security Answer</td>
                <td class="auto-style5"><asp:TextBox ID="txtAnswer" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>UserType</td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="UserType" DataValueField="UserType">
                        <asp:ListItem Value="1">Standard</asp:ListItem>
                        <asp:ListItem Value="2">Silver</asp:ListItem>
                        <asp:ListItem Value="3">Gold</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style3" colspan="2">
                    <asp:Button ID="btnRegister" runat="server" Text="Enter" OnClick="btnRegister_Click" />
                    <asp:Button ID="btnBack" runat="server" Text="Cancel" OnClick="btnBack_Click" />
                    <br />
                  <asp:Label ID="lblRegErrors" runat="server" Text="Label"></asp:Label>
                  </td></tr> 
            </table>

    </div>
    </form>
</body>
</html>
