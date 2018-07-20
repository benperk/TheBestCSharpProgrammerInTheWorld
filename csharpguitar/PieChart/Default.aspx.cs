using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using System.Web.UI.DataVisualization;

namespace PieChart
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Populate series data
            double[] yValues = { 71.15, 23.19, 5.66 };
            string[] xValues = { "AAA", "BBB", "CCC" };
            Chart1.Series["Default"].Points.DataBindXY(xValues, yValues);

            //Set the colors of the Pie chart
            //Chart1.Series["Default"].Points[0].Color = Color.CornflowerBlue;
            //Chart1.Series["Default"].Points[1].Color = Color.LightSkyBlue;
            //Chart1.Series["Default"].Points[2].Color = Color.OldLace;

            Chart1.Series["Default"].Points[0].Color = Color.MediumSeaGreen;
            Chart1.Series["Default"].Points[1].Color = Color.PaleGreen;
            Chart1.Series["Default"].Points[2].Color = Color.LawnGreen;

            //Set Pie chart type
            Chart1.Series["Default"].ChartType = SeriesChartType.Pie;

            //Set labels style (Inside, Outside, Disabled)
            Chart1.Series["Default"]["PieLabelStyle"] = "Disabled";

            //Set chart title, color and font
            //Chart1.Titles[0].Text = "Pie Chart Title";
            Chart1.Titles[0].ForeColor = Color.DarkBlue;
            Chart1.Titles[0].ShadowColor = Color.LightGray;
            Chart1.Titles[0].Font = new Font("Arial Black", 14, FontStyle.Bold);

            //Enable 3D
            Chart1.ChartAreas["ChartArea1"].Area3DStyle.Enable3D = true;

            //Default, SoftEdge, Concave (not enabled if 3D)
            Chart1.Series[0]["PieDrawingStyle"] = "SoftEdge";

            // Disable/Enable the Legend
            Chart1.Legends[0].Enabled = true;
        }
    }
}