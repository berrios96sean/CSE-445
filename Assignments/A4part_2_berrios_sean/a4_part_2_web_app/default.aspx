<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="a4_part_2_web_app._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Test Verification Service "></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label9" runat="server" Text="Path to XML:  http://www.public.asu.edu/~sfberrio/Restaurants.xml"></asp:Label>
            <br />
            <asp:Label ID="Label11" runat="server" Text="Path to XSD:  http://www.public.asu.edu/~sfberrio/Restaurants.xsd"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Enter XML URL:   "></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" Width="202px"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Enter XSD URL:  "></asp:Label>
&nbsp;
            <asp:TextBox ID="TextBox3" runat="server" Width="203px"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Verify " />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="36px" Width="184px"></asp:TextBox>
            <br />
            <br />
            <br />
        </div>
        <asp:Label ID="Label2" runat="server" Text="Test XPathSearch Service "></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label12" runat="server" Text="Path to XML:  http://www.public.asu.edu/~sfberrio/Restaurants.xml"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Enter XML Url:  "></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Width="196px"></asp:TextBox>
        <br />
        <asp:Label ID="Label6" runat="server" Text="Enter Path:   "></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="TextBox5" runat="server" Width="172px"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Example Path: /Restaurants/restaurant/name"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Get Path" />
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Text="Output"></asp:Label>
        <br />
        <br />
        <br />
        <br />
    </form>
</body>
</html>
