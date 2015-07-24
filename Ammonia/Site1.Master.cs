using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Ammonia
{
    public partial class Site1 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // ReSharper disable once InconsistentNaming
        protected void loginSubmit(object sender, EventArgs e)
        {
            if(!Page.IsValid)return;
            try
            {
                var conn =
                new SqlConnection(ConfigurationManager.ConnectionStrings["UsersConnectionString"].ConnectionString);
                conn.Open();
                var finduser = "SELECT count(*) FROM [Table] WHERE Username = '" + textLogin.Text + "' AND Password = '" +
                           textPass.Text + "'";
                var comm = new SqlCommand(finduser, conn);
                var temp = Convert.ToInt32(comm.ExecuteScalar().ToString());
                conn.Close();
                if (temp == 1)
                {
                    Session["CurrentUser"] = textLogin.Text;
                    Response.Redirect("index.aspx");
                }
                else
                {
                    Response.Write("Bad Credentials");
                }
            }
            catch (Exception ex)
            {
                Response.Write("Error Occured: " + ex);
            }
        }
    }
}