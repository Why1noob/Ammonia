using System;


namespace Ammonia
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((bool)Session["isAdmin"]) return;
            Response.Redirect("Login.aspx");
        }
    }
}