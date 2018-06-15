<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LocalizeASP.aspx.cs" Inherits="_Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br /><br /><br />
        <asp:Table ID="Table1" runat="server" >
            <asp:TableRow >
                <asp:TableCell >
                    <asp:Label ID="Label1" runat="server" Text="First Name:" meta:resourcekey="Label1Resource1" />
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="textBox1" runat="server"/>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label2" runat="server" Text="Last Name:" meta:resourcekey="Label2Resource1" />
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="textBox2" runat="server"/>
                </asp:TableCell></asp:TableRow><asp:TableRow>
                <asp:TableCell>
                    <asp:Label ID="Label3" runat="server" Text="Address:" meta:resourcekey="Label3Resource1" />
                </asp:TableCell><asp:TableCell>
                    <asp:TextBox ID="textBox3" runat="server"/>
                </asp:TableCell></asp:TableRow><asp:TableRow HorizontalAlign="Right">
                <asp:TableCell ColumnSpan="2">
                    <asp:Button ID="Button1" runat="server" Text="Submit" meta:resourcekey="Button1Resource1" />
                </asp:TableCell></asp:TableRow></asp:Table></div></form></body></html>