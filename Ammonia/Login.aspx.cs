using System;
using System.Configuration;
using System.Web.UI;


namespace Ammonia
{
    public partial class Login : Page
    {
        private const int Firp = 33;
        private const string Foup = "L";
        private const string Thip = "pq!";

        protected void Page_Load(object sender, EventArgs e)
        {
           if(!(bool)Session["isAdmin"]) return;
           Response.Redirect("Admin.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text != Firp +11.ToString()+ConfigurationManager.AppSettings["Secp"]+Thip+Foup+((3+3+3)*3)+ConfigurationManager.AppSettings["Fifp"])return;
            Session["isAdmin"] = true;
            Response.Redirect("Admin.aspx");
        }
    }
}