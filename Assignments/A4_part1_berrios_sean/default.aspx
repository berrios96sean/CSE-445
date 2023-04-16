<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="A4_part1_berrios_sean._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label9" runat="server" Text="<span style='font-weight:bold;'>xml url:</span> http://localhost:57279/Restaurants.xml"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Enter Xml URL:  "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Width="221px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Load" />
            <br />
            <br />
            <asp:Label ID="Label7" runat="server" Text="Select a Restaurant to View Info  then click 'info' button"></asp:Label>
            <p>
                <strong>
                <asp:DropDownList ID="DropDownList1" runat="server">
                </asp:DropDownList>
                </strong>
            </p>
            <p>
                <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Info" />
            </p>
        </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Restaurant Name:  "></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Width="211px"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Text="Phone:  "></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Width="157px"></asp:TextBox>
        <p>
            <asp:Label ID="Label4" runat="server" Text="Email:  "></asp:Label>
            <asp:TextBox ID="TextBox4" runat="server" Width="159px"></asp:TextBox>
        </p>
        <asp:Label ID="Label5" runat="server" Text="Website:  "></asp:Label>
        <asp:TextBox ID="TextBox5" runat="server" Width="249px"></asp:TextBox>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Facebook URL:  "></asp:Label>
            <asp:TextBox ID="TextBox6" runat="server" Width="224px"></asp:TextBox>
        </p>
        <asp:Label ID="Label8" runat="server" Text="Delivers:  "></asp:Label>
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
    </form>
</body>
</html>
