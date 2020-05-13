using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    public string EnteredText()
    {
        return TextBoxComment.Text;
    }

    public string SafeText()
    {
        return System.Text.RegularExpressions.Regex.Replace(TextBoxComment.Text, @"[^\w\.@-]", "");
    }

    public string SaveStatus(string text)
    {
        if (IsPostBack && text != "") return "Status: OK";

        return "Status: Pending";
    }
}