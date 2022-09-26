<%@ Page Title="WSDL ASMX" language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lab4_WebForm._Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body runat="server">
    <div style="margin: 20px;">
        <form runat="server">
            <asp:TextBox ID="x" runat="server" />
            <asp:TextBox ID="y" runat="server" />
            <asp:TextBox ID="output" Enabled="False" runat="server" />
            <asp:Button ID="button" runat="server" Text="Request" />
        </form>
    </div>
</body>
</html>
