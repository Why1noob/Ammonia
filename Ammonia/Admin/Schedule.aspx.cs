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
            if (TextBox1.Text == "" ||TextBox2.Text == "") { CreateEventError(); return; }
            try
            {
                var con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
                con.Open();
                var addEventQuery = "INSERT INTO Events (Date,Name,Description) VALUES (CONVERT(DATETIME,'" +
                                    Calendar1.SelectedDate.ToString(CultureInfo.CurrentCulture).Substring(0, 10) +
                                    "',104), N'" + TextBox1.Text + "', N'" + TextBox2.Text + "')";
                var com = new SqlCommand(addEventQuery, con);
                com.ExecuteNonQuery();
                con.Close();
                TextBox1.Text = "";
                TextBox2.Text = "";
                Label1.Text = "Новость успешно добавлена!";
                Timer1.Enabled = true;
            }
            catch (Exception)
            {
                CreateEventError();
            }
        }
        private void CreateEventError()
        {
            Label1.Text = "Ошибка при создании новости!";
            Timer1.Enabled = true;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "";
            Timer1.Enabled = false;
        }
    }
}