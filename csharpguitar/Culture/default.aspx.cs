using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Threading;
using System.Globalization;

namespace cultureX
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            labelDateTime.Text = System.DateTime.Now.ToString();
            var price = 1234567.32m;
            labelMoney.Text = price.ToString("C", CultureInfo.CurrentCulture);

            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures)
                          .Except(CultureInfo.GetCultures(CultureTypes.SpecificCultures));

            Grid1D.DataSource = cultures;
            Grid1D.DataBind();
        }

        protected override void InitializeCulture()
        {
            if (Request.Form["ListBox1"] != null)
            {
                var selectedLanguage = Request.Form["ListBox1"];
                UICulture = selectedLanguage;
                Culture = selectedLanguage;

                Thread.CurrentThread.CurrentCulture =
                    CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new
                    CultureInfo(selectedLanguage);
            }
            base.InitializeCulture();
        }

    }
}