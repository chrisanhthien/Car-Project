<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CarProject.Presentation.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="UserName:"></asp:Label>
            <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter username" ForeColor="Red" ControlToValidate="txtUser"></asp:RequiredFieldValidator>
         <div>
             <asp:Label ID="Label2" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
             <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Password" ForeColor="Red" ControlToValidate="txtPass"></asp:RequiredFieldValidator>
         </div>
            <div>            
                <asp:Button ID="btnEnter" runat="server" Text="Enter" OnClick="btnEnter_Click" />
           </div>
           <div>
                 <asp:Label ID="StatusLbl" runat="server" Text="Label"></asp:Label>
           </div>
      </div>
    </form>
</body>
</html>
