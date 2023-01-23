<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="webAppClient.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Enter String"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Analyze" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Word Count"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Upper Case Count"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Lower Case Count "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Digit Count"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label6" runat="server" Text="Vowel Count"></asp:Label>
            <br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
        </div>
    </form>
</body>
</html>
