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
            var con2 = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
            con2.Open();
            var con3 = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
            con3.Open();
            const string distinctyears = "SELECT DISTINCT Year FROM Songs";
            var com = new SqlCommand(distinctyears, con);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                var yearStr = reader.GetInt32(0).ToString().Trim();
                var yearPanel = Global.CreateNewPanel("col-md-12 bordred", "yearPanel" + yearStr, "", null, "");
                Global.AddChild(discoSpace,yearPanel);
                var yearHeader = Global.CreateNewHtmlControl("h3", "col-md-12 text-left", "yearHeader" + yearStr, yearStr, "style",
                    "margin:0; padding:0;");
                Global.AddChild(yearPanel,yearHeader);
                var selectAlbums = "SELECT DISTINCT Album,Cover FROM Songs WHERE Year = '" + yearStr + "'";
                var selectAlbumsCom = new SqlCommand(selectAlbums,con2);
                var selectAlbumsReader = selectAlbumsCom.ExecuteReader();
                while (selectAlbumsReader.Read())
                {
                    var albumName = selectAlbumsReader.GetString(0).Trim();
                    var albumCOverStr = selectAlbumsReader.GetString(1).Trim();
                    var albomCoverNPanel = Global.CreateNewPanel("row bordered", albumName + "CoverNPanel", "", null, "");
                    Global.AddChild(yearPanel,albomCoverNPanel);
                    var albumCover = Global.CreateNewHtmlControl("img", "col-md-4 bordered", albumName + "Cover", "", "src",
                        albumCOverStr);
                    Global.AddChild(albomCoverNPanel,albumCover);
                    var albumPanelGroup = Global.CreateNewHtmlControl("div", "panel-group col-md-8", albumName + "PanelGroup",
                        "", "style", "padding:0;");
                    Global.AddChild(albomCoverNPanel,albumPanelGroup);
                    var albumPanel = Global.CreateNewHtmlControl("div", "panel panel-default", albumName + "Panel", "",
                        null, "");
                    Global.AddChild(albumPanelGroup,albumPanel);
                    var albumPanelHeader = Global.CreateNewHtmlControl("div", "panel-heading", albumName + "heading", "",
                        null, "");
                    Global.AddChild(albumPanel,albumPanelHeader);
                    var albumPanelTitle = Global.CreateNewHtmlControl("h4", "paneltitle", albumName + "title", "", null,
                        "");
                    Global.AddChild(albumPanelHeader,albumPanelTitle);
                    var albumExpand = Global.CreateNewHtmlControl("a", "text-left", albumName + "expand", albumName,null,"");
                    albumExpand.Attributes.Add("data-toggle","collapse");
                    albumExpand.Attributes.Add("href=", "#ContentPlaceHolder1_" + albumName + "Collapse");
                    Global.AddChild(albumPanelTitle,albumExpand);
                    var albumCollapse = Global.CreateNewHtmlControl("div", "panel-collapse collapse",
                        albumName + "Collapse", "", null, "");
                    Global.AddChild(albumPanel,albumCollapse);
                    var selectSongs = "SELECT Song From Songs WHERE Album = '" + albumName + "'";
                    var selectSongsCom = new SqlCommand(selectSongs,con3);
                    var selectSongsReader = selectSongsCom.ExecuteReader();
                    while (selectSongsReader.Read())
                    {
                        var songName = selectSongsReader.GetString(0).Trim();
                        var songsPanel = Global.CreateNewHtmlControl("div", "panel-body", songName + "Panel", songName,
                            null, "");
                        Global.AddChild(albumCollapse,songsPanel);
                    }
                }
            }
            con.Close();
            con2.Close();
            con3.Close();
        }
    }
}