using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;


namespace Ammonia.Admin
{
    public partial class Schedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "" ||TextBox2.Text == "") { return; }
            var con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
            con.Open();
            var addEventQuery = "INSERT INTO Events (Date,Name,Description) VALUES (CONVERT(DATETIME,'"+Calendar1.SelectedDate.ToString(CultureInfo.CurrentCulture).Substring(0,10)+"',104), N'"+TextBox1.Text+"', N'"+TextBox2.Text+"')";
            var com = new SqlCommand(addEventQuery,con);
            com.ExecuteNonQuery();
            con.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}