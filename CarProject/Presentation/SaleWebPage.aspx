<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SaleWebPage.aspx.cs" Inherits="CarProject.Presentation.SaleWebPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sale Web Page</title>
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
    </style>
</head>
<body>
    <h2>Sale Web Page</h2>
    <p><asp:Label ID="lblUserId" runat="server" Text="Label"></asp:Label></p>
    <form id="form1" runat="server">
        <table border="1">
            <tr>
                <td> 
                    <asp:DropDownList ID="drpBrand" runat="server" OnSelectedIndexChanged="drpBrand_SelectedIndexChanged1" AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="drpModel" runat="server">
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Price"></asp:Label></td>
                <td>
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>

                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Price!" ForeColor="Red" ControlToValidate="txtPrice"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="5" class="auto-style1">
                    <asp:Label ID="StatusLbl" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>
       
        <asp:GridView ID="grdSaleUserInfo" runat="server">
        </asp:GridView>
       
    </form>
</body>
</html>
