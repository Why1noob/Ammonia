using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ammonia
{
    public partial class Calendar : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if(e.Day.IsOtherMonth) return;
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
            con.Open();
            var checkForTodayEventQuery = "SELECT COUNT(Date) FROM Events WHERE Date = '" + e.Day.Date.ToString(CultureInfo.CurrentCulture).Substring(6, 4) + e.Day.Date.ToString(CultureInfo.CurrentCulture).Substring(3, 2) + e.Day.Date.ToString(CultureInfo.CurrentCulture).Substring(0, 2) + "'";
            var com = new SqlCommand(checkForTodayEventQuery,con);
            var todayEventsCount = Convert.ToInt32(com.ExecuteScalar());
            if (todayEventsCount != 0)
            {
                e.Cell.BackColor = Color.LawnGreen;
            }
            con.Close();
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
            con.Open();
            var selectEventHeaderQuery = "SELECT Name FROM Events WHERE Date = '" + Calendar1.SelectedDate.Year +
                                         Calendar1.SelectedDate.Month + Calendar1.SelectedDate.Day +
                                         "'";
            var com = new SqlCommand(selectEventHeaderQuery, con);
            try
            {
                var eventHeader = com.ExecuteScalar().ToString().Trim();
                if (!string.IsNullOrEmpty(eventHeader))
                {
                    EventDescriptionFull.Visible = true;
                    var selectEventDiscriptionQuery = "SELECT Description FROM Events Where Date = '" +
                                                      Calendar1.SelectedDate.Year + Calendar1.SelectedDate.Month +
                                                      Calendar1.SelectedDate.Day +
                                                      "'";
                    com = new SqlCommand(selectEventDiscriptionQuery, con);
                    var eventDescription = com.ExecuteScalar().ToString().Trim();
                    EventHeader.Controls.Add(new LiteralControl(eventHeader));
                    EventDiscription.Controls.Add(new LiteralControl(eventDescription));
                    con.Close();
                }
                else
                {
                    EventDescriptionFull.Visible = false;
                }
            }
            catch (Exception b)
            {
                // ignored
            }
        }
    }
}