<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WordFilter.aspx.cs" Inherits="A3_tryIt.Services.WordFilter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">

    <h1>Word Filter Service</h1>
    <p>Enter a topic and press 'Filter' button to get a string for the content of a wikipedia page with stop words removed.</p>
    
        <asp:Label ID="Label1" runat="server" Text="Enter Topic:  "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="126px"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Filter" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Content"></asp:Label>
        </p>
    </form>
    
</body>
</html>
