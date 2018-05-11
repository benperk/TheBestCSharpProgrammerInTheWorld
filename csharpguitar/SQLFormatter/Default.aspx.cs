using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e) {}

    protected void buttonFormatSQL_Click(object sender, EventArgs e)
    {
        textBoxSQLOutput.Text = FormatSQL(textBoxSQLInput.Text.ToString());
    }

    public static string FormatSQL(string unformattedSQL)
    {
        string SQL = unformattedSQL.ToUpper();

        string newSQL = SQL.Replace("SELECT", "SELECT\n\t");
        newSQL = newSQL.Replace("FROM", "\nFROM\n\t");
        newSQL = newSQL.Replace("WHERE", "\nWHERE\n\t");
        newSQL = newSQL.Replace("=", " = ");
        newSQL = newSQL.Replace(",", ",\n\t");
        newSQL = newSQL.Replace(" AND", " AND\n\t");
        newSQL = newSQL.Replace(" ON", "\n\t\tON");
        newSQL = newSQL.Replace("INNER JOIN", "\n\tINNER JOIN");
        newSQL = newSQL.Replace("ORDER BY", "\nORDER\t BY");
        newSQL = newSQL.Replace("GROUP BY", "\nGROUP\t BY");
        newSQL = newSQL.Replace(" AS", " \tAS");

        return newSQL;
    }
}