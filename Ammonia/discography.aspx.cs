using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;

namespace Ammonia
{
    public partial class Discography : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
            con.Open();
            const string distinctyears = "SELECT DISTICT * FROM Songs";
            var com = new SqlCommand(distinctyears, con);
            var reader = com.ExecuteReader();
        }
    }
}