<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tryIt.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 226px;
            width: 633px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            This service takes a topic and returns a formatted string that removes all stop words from the page content
        </div>

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Topic:  "></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Get Result" OnClick="Button1_Click" />
        <p style="font-weight: 700">
            <asp:Label ID="Label3" runat="server" Text="content"></asp:Label>
        </p>
    </form>
</body>
</html>
