<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetTopics.aspx.cs" Inherits="A3_tryIt.Services.GetTopics" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <h1>Get Topics Service</h1>
        <p>Enter a topic then press 'Get topics' to return a json string of topics 
            So far the only working topics have to have less than 10 sections and none 
            of the sections in the wikipedia article can appear out of order. 
        </p>
        <h4>Known working topics: Gum, Puppy, Soda, wyrmwood, driftwood</h4>
        <asp:Label ID="Label1" runat="server" Text="Enter Topic:   "></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Get Topics " />
        </p>
        <asp:Label ID="Label2" runat="server" Text="content"></asp:Label>
    </form>
</body>
</html>
