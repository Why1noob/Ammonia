using System;


namespace Ammonia
{
    public partial class Admin1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var o = Session["isAdmin"];
            if (o != null && (bool)o) return;
            Response.Redirect("index.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session["isAdmin"] = false;
            Response.Redirect("index.aspx");
        }
    }
}