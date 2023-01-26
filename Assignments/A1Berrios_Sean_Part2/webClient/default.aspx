<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="webClient._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="1. String Analyzer"></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Enter String"></asp:Label>
&nbsp;<br />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Analyze" />
            <br />
            <asp:Label ID="Label3" runat="server" Text="Word Count "></asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            Upper Case Count<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            Lower Case Count<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            Digit Count<br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            Vowel Count
            <br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <br />
            2. Encryption/Decryption<br />
            <br />
            Enter String<br />
            <asp:TextBox ID="textToEncrypt" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="encryptButton" runat="server" OnClick="encryptButton_Click" Text="Encrypt" />
            <br />
            <br />
            <asp:Label ID="encryptedMessage" runat="server" Text="Encrypted Message"></asp:Label>
&nbsp;<br />
            <br />
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Send to to Receiver " Width="138px" />
            <br />
            <br />
            This Message was Received<br />
            <br />
            <asp:Label ID="receivedMessage" runat="server" Text="receivedMessage"></asp:Label>
            <br />
            <br />
            <asp:Button ID="decryptButton" runat="server" Text="Decrypt" />
            <br />
            <br />
            <asp:Label ID="decryptedMessage" runat="server" Text="Decrypted Message"></asp:Label>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
