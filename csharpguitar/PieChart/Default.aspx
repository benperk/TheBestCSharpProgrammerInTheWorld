<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PieChart.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Table ID="table1" runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <asp:chart id="Chart1" runat="server" Height="300px" Width="400px">
					<titles>
						<asp:Title ShadowOffset="3" Name="Title1" />
					</titles>
					<legends>
						<asp:Legend Alignment="Center" Docking="Bottom" IsTextAutoFit="False" Name="Default" LegendStyle="Row" />
					</legends>
					<series>
						<asp:Series Name="Default" />
					</series>
					<chartareas>
						<asp:ChartArea Name="ChartArea1" BorderWidth="0" />
					</chartareas>
				</asp:chart> 
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </div>
    </form>
</body>
</html>
