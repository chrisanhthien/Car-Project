<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchPage.aspx.cs" Inherits="CarProject.Presentation.SearchPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
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
                    <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" /></td>
                </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="StatusLbl" runat="server" Text="Label"></asp:Label>
               </td>
            </tr>
                </table>
        <asp:GridView ID="grdResultSearch" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
