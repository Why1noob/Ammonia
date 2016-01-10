using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;
using System.Globalization;
using System.Web.UI.WebControls;


namespace Ammonia
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
            con.Open();
            const string visibleNewsQuery = "SELECT * FROM News WHERE State = 'Visible'";
            var com = new SqlCommand(visibleNewsQuery,con);
            var reader = com.ExecuteReader();
            var c = 0;
            while(reader.Read())
            {
                LoadNews(c,reader);
                c++;
            }
            reader.Close();
            con.Close();
        }

        protected void LoadNews(int counter, SqlDataReader newReader)
        {
            var newsPanel = Global.CreateNewPanel("col-md-12", "newsPanel" + counter, "", "padding", "0");
            Global.AddChild(newsSpace,newsPanel);
            var newsDateNPic = Global.CreateNewPanel("col-md-3 boarderedd full-height", "newsDateNPick" + counter, "",
                "padding", "0");
            Global.AddChild(newsPanel, newsDateNPic);
            var newsPic = new Image { CssClass = "bordered", ID = "newsPic" + counter, ImageUrl = newReader.GetString(3)};
            newsPic.Style.Add("height","150px");
            newsPic.Style.Add("width","100%");
            newsDateNPic.Controls.Add(newsPic);
            var newsDate = Global.CreateNewPanel("bordered", "newsDate" + counter,
                newReader.GetDateTime(5).ToString(CultureInfo.CurrentCulture), null, "");
            Global.AddChild(newsDateNPic, newsDate);
            var newsTitNText = Global.CreateNewPanel("col-md-9", "newsTitText" + counter, "", "padding", "0");
            Global.AddChild(newsPanel,newsTitNText);
            var newsTitle = Global.CreateNewHtmlControl("h3", "bordered", "newsTitle" + counter, newReader.GetString(1),
                null, null);
            newsTitle.Style.Add("margin-top", "0");
            Global.AddChild(newsTitNText,newsTitle);
            var newsText = Global.CreateNewPanel("text-left", "newsText" + counter, newReader.GetString(2),
                "text-indent", "3em");
            Global.AddChild(newsTitNText,newsText);
        }
    }
}