<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tryit.aspx.cs" Inherits="A3_tryIt.Tryit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 142px;
        }
        .auto-style2 {
            width: 308px;
        }
        .auto-style3 {
            width: 274px;
        }
        .auto-style4 {
            width: 142px;
            height: 23px;
        }
        .auto-style5 {
            width: 308px;
            height: 23px;
        }
        .auto-style6 {
            width: 274px;
            height: 23px;
        }
        .auto-style9 {
            width: 100%;
        }
        .auto-style10 {
            width: 310px;
            height: 23px;
        }
        .auto-style11 {
            width: 310px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h1>
            Service Directory
        </h1>
        <h2>
            This Project is developed by: Sean Berrios 
        </h2>

    </form>
    <table class="auto-style9">
        <tr>lkj
            <td class="auto-style4">Service Name</td>
            <td class="auto-style5">Tryit Link</td>
            <td class="auto-style10">Description</td>
            <td class="auto-style6">APIs/WebService Methods</td>
        </tr>
        <tr>
            <td class="auto-style1">WordFilter</td>
            <td class="auto-style2"><a href="http://webstrar7.fulton.asu.edu/page5/Services/WordFilter.aspx">https://webstrar7.fulton.asu.edu/page5/Services/WordFilter.aspx</a></td>
            <td class="auto-style11">Filters Stop words from the content of a webpage </td>
            <td class="auto-style3">REST</td>
        </tr>
        <tr>
            <td class="auto-style1">GetDates</td>
            <td class="auto-style2"><a href="http://webstrar7.fulton.asu.edu/page5/Services/GetDates.aspx">https://webstrar7.fulton.asu.edu/page5/Services/GetDates.aspx</a></td>
            <td class="auto-style11">Returns a JSON String of dates and info from a wikipedia page</td>
            <td class="auto-style3">REST</td>
        </tr>
        <tr>
            <td class="auto-style1">GetTopics</td>
            <td class="auto-style2"><a href="http://webstrar7.fulton.asu.edu/page5/Services/GetTopics.aspx">https://webstrar7.fulton.asu.edu/page5/Services/GetTopics.aspx</a></td>
            <td class="auto-style11">Returns a JSON String of Topics with Descriptions from a wikipedia page</td>
            <td class="auto-style3">REST</td>
        </tr>
    </table>
</body>
</html>
