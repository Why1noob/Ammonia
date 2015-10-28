using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Configuration;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Ammonia
{
    public partial class Index : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            var newsPanel = new Panel { CssClass = "col-md-12", ID = "newsPanel" + counter };
            newsPanel.Style.Add("padding","0");
            newsSpace.Controls.Add(newsPanel);
            var newsDateNPic = new Panel { CssClass = "col-md-3 bordered full-height", ID = "newsDateNPick" + counter };
            newsDateNPic.Style.Add("padding", "0");
            newsDateNPic.Style.Add("height", "100%");
            newsPanel.Controls.Add(newsDateNPic);
            var newsPic = new Image { CssClass = "bordered", ID = "newsPic" + counter, ImageUrl = newReader.GetString(3)};
            newsPic.Style.Add("height","150px");
            newsPic.Style.Add("width","100%");
            newsDateNPic.Controls.Add(newsPic);
            var newsDate = new Panel { CssClass = "bordered", ID = "newsDate" + counter };
            newsDate.Controls.Add(new LiteralControl(newReader.GetDateTime(5).ToString(CultureInfo.CurrentCulture)));
            newsDateNPic.Controls.Add(newsDate);
            var newsTitNText = new Panel { CssClass = "col-md-9", ID = "newsTitNText" + counter };
            newsTitNText.Style.Add("padding", "0");
            newsPanel.Controls.Add(newsTitNText);
            var newsTitle = new HtmlGenericControl("h3")
            {
                InnerHtml = newReader.GetString(1),
            };
            newsTitle.Attributes.Add("class", "bordered");
            newsTitle.Style.Add("margin", "0");
            newsTitle.Attributes.Add("id", "newsTitle" + counter);
            newsTitNText.Controls.Add(newsTitle);
            var newsText = new Panel { CssClass = "text-left", ID = "newsText" + counter };
            newsText.Controls.Add(new LiteralControl(newReader.GetString(2)));
            newsText.Style.Add("text-indent","3em");
            newsTitNText.Controls.Add(newsText);
        }
    }
}