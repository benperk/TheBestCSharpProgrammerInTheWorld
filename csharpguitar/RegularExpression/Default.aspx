<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager" runat="server" />
    <asp:Table ID="table1" runat="server" Width="300">
        <asp:TableRow>
            <asp:TableCell>
                Comment (server side validation):<br />
                <asp:TextBox id="TextBoxComment" runat="server" TextMode="MultiLine"></asp:TextBox>&nbsp;
                <br />
                <br />
                <asp:Button ID="buttonSubmit" runat="server" Text="Validate" />
                <br />
                <br />
    
                <asp:UpdatePanel ID="InitialText" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <fieldset>
                        <legend>Entered Text</legend>
                        <br />
                        <%=EnteredText()%>
                        <br />
                        </fieldset>
                        </ContentTemplate>
                </asp:UpdatePanel>

                <asp:UpdatePanel ID="ModifiedText" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <fieldset>
                        <legend>System Safe Text</legend>
                        <br />
                        <%=SafeText()%>
                        <br />
                        </fieldset>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <br />
    <asp:Table ID="table2" runat="server" Width="300">
        <asp:TableRow>
            <asp:TableCell>
                Comment (client side validation):<br />
                <asp:TextBox id="TextBoxCommentCSV" runat="server" TextMode="MultiLine"></asp:TextBox>&nbsp;
                <br />
                <br />
                <asp:Button ID="buttonValidate" runat="server" Text="Save" />
                <br />
                <br />
                <asp:RegularExpressionValidator runat="server" id="regexpSpecChara" ForeColor="Red"
                ControlToValidate="TextBoxCommentCSV" ErrorMessage="Special characters are not allowed."  
                ValidationExpression="^[a-zA-Z'.\s]{1,40}$" />
                <br /> <br />
                <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                    <ContentTemplate>
                        <fieldset>
                        <legend>Save Status:</legend>
                        <br />
                        <%=SaveStatus(TextBoxCommentCSV.Text)%>
                        <br />
                        </fieldset>
                        </ContentTemplate>
                </asp:UpdatePanel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    </form>
</body>
</html>
