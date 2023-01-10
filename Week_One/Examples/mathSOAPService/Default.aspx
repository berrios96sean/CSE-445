<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="mathSOAPService.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="X:"></asp:Label><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Y:"></asp:Label><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="X*Y:"></asp:Label><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Multiply" OnClick="Button1_Click" />
        </div>
    </form>
</body>
</html>
