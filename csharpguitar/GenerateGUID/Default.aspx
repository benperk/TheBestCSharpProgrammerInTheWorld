<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

    <asp:ScriptManager ID="ScriptManager" runat="server" />
    
    <asp:Table ID="tableSeqGUID" runat="server" Width="400">
        <asp:TableRow>
            <asp:TableCell>
                    <asp:UpdatePanel ID="UpdatePanelGUID" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                           <fieldset>
                           <legend>Generate random GUID</legend>
                            <br />
                            <%=GenerateGuid()%>
                            <br /><br />
                            <asp:Button ID="buttonGUID" Text="Go" runat="server" />
                            </fieldset>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                    <asp:UpdatePanel ID="UpdatePanelSeqGUID" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                           <fieldset>
                           <legend>Generate sequential GUID</legend>
                            <br />
                            <%=GenerateSequentialGuidPanel()%>
                            <br /><br />
                            <asp:Button ID="buttonSequentialGUID" Text="Go" runat="server" />
                            </fieldset>
                        </ContentTemplate>
                    </asp:UpdatePanel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>


    </form>
</body>
</html>
