<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Table ID="SQL" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="textBoxSQLInput" TextMode="MultiLine" Width="400" Height="200"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:Button runat="server" ID="buttonFormatSQL" Text="Format SQL" OnClick="buttonFormatSQL_Click" />
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
                    <asp:TextBox runat="server" ID="textBoxSQLOutput" TextMode="MultiLine" Width="400" Height="200"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </form>
</body>
</html>
