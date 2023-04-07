<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetDates.aspx.cs" Inherits="A3_tryIt.Services.GetDates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1>Get Dates Service</h1>
        <p>Enter a topic and press 'Get Dates' to return a json string of dates. </p>

        <asp:Label ID="Label1" runat="server" Text="Enter Topic:   "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Dates" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="content"></asp:Label>
        </p>

    </form>
</body>
</html>
