using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Ammonia.Admin
{
    public partial class News : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
               
        }

        protected void addRow_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text == "" || txtText.Text == "") {CreateNewsError(); return; }
            try
            {
                var con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
                con.Open();
                var updateQuery = "INSERT INTO News (Title,Text,Picture,Date) VALUES (N'"+ txtTitle.Text + "',N'" +
                                  txtText.Text +
                                  "','" + txtPicture.Text + "',GETDATE())";
                var com = new SqlCommand(updateQuery, con);
                com.ExecuteNonQuery();
                con.Close();
                txtTitle.Text = "";
                txtText.Text = "";
                txtPicture.Text = "";
                Image1.Visible = false;
                Label1.Text = "Новость успешно добавлена!";
                Timer1.Enabled = true;
            }
            catch (SqlException)
            {
                CreateNewsError();
            }
        }

        private void CreateNewsError()
        {
            Label1.Text = "Ошибка при создании новости!";
            Timer1.Enabled = true;
        }

        protected void txtPicture_TextChanged(object sender, EventArgs e)
        {
            Image1.ImageUrl = txtPicture.Text;
            Image1.Visible = true;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "";
            Timer1.Enabled = false;
        }


    }
}