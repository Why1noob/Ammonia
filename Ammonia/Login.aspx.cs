using System;
using System.Configuration;
using System.Web;
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
            if (HttpContext.Current.Request.UserHostAddress != null)
            {
                var ip = HttpContext.Current.Request.UserHostAddress;
            }
            //there will be check for ip
            if(Session["isAdmin"]==null)return;
            if(!(bool)Session["isAdmin"]) return;
           Response.Redirect("AdminNews.aspx");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            if(TextBox1.Text != "1") return;
           // if(TextBox1.Text != (Firp +22)*10+ConfigurationManager.AppSettings["Secp"]+Thip+Foup+((3+3+3)*3)+ConfigurationManager.AppSettings["Fifp"])
           // {TextBox1.Text = ""; return;}
            Session["isAdmin"] = true;
            Response.Redirect("AdminNews.aspx");
        }
    }
}