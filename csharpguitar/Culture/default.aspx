<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="cultureX._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ListBox ID="ListBox1" runat="server" Width="100px" Height="150px">
            <asp:ListItem Value="en-US" 
                Selected="True">English</asp:ListItem>
            <asp:ListItem Value="es-MX">Español</asp:ListItem>
            <asp:ListItem Value="de-DE">Deutsch</asp:ListItem>
            <asp:ListItem Value="fa-FA">فارسی</asp:ListItem>
            <asp:ListItem Value="ar-AR">العربية</asp:ListItem>
            <asp:ListItem Value="pt-PT">Portuguese</asp:ListItem>
            <asp:ListItem Value="zh-ZH">中文</asp:ListItem>
            <asp:ListItem Value="ro-RO">Romanian</asp:ListItem>
        </asp:ListBox><br /><br />
        <asp:Button ID="Button1" runat="server" 
            Text="Set Language" 
            meta:resourcekey="Button1" />
        <br /><br />
        <asp:Label ID="Label1" runat="server" 
            Text="" 
            meta:resourcekey="Label1" />
        </div>
        <br />
            Date Time: <asp:Label ID="labelDateTime" runat="server" />
            <br /><br />
            Money: <asp:Label ID="labelMoney" runat="server" />
            <br /><br />
            <asp:GridView ID="Grid1D" runat="server" AutoGenerateColumns = "true" 
                Font-Names = "Arial" Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B" 
                HeaderStyle-BackColor = "green">
            </asp:GridView>
    </form>
</body>

</html>
