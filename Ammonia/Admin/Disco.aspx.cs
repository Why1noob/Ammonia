using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace Ammonia.Admin
{
    public partial class Disco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var albumsListGroup = Global.CreateNewHtmlControl("ul", "list-group", "albumListGroup", "",null,null);
            Global.AddChild(collapseAlbums,albumsListGroup);
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
                con.Open();
                const string getAlbumsQuery = "SELECT DISTINCT Album,Year FROM Songs";
                var com = new SqlCommand(getAlbumsQuery,con);
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var albumName = reader.GetString(0).Trim();
                    var year = reader.GetInt32(1).ToString().Trim();
                    var albumListItem = Global.CreateNewHtmlControl("li", "list-group-item", albumName,"", null, null);
                    Global.AddChild(albumsListGroup,albumListItem);
                    var albumNameButton = Global.CreateNewLButton("btn btn-link btn-xs", "alb" + albumName,
                        albumName + "(" + year + ")",new []{"style"},new[]{"width:94%;"});
                    Global.AddChild(albumListItem, albumNameButton);
                    albumNameButton.Click += albumButton_Click;
                    var albumDeleteButton = Global.CreateNewLButton("btn btn-danger btn-xs", "del" + albumName, "x");
                    Global.AddChild(albumListItem,albumDeleteButton);

                }
                reader.Close();
                con.Close();
            }
            catch (SqlException ex)
            {
                DebugLabel.Text = ex.ToString();
            }
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton) sender;
            var albumName = btn.ID.Substring(3);
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
            con.Open();
            var deleteAlbumQuery = "DELETE FROM Songs WHERE Album = '" + albumName + "'";
            var com = new SqlCommand(deleteAlbumQuery,con);
            com.ExecuteNonQuery();
            con.Close();
        }

        protected void albumButton_Click(object sender, EventArgs e)
        {
            var btn = (LinkButton) sender;
            var senderAlbumName = btn.ID.Substring(3);
            var songsListGroup = Global.CreateNewHtmlControl("ul", "list-group", "albumListGroup", "", null, null);
            Global.AddChild(collapseSongs, songsListGroup);
            try
            {
                var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
                con.Open();
                var getAlbumsQuery = "SELECT Song FROM Songs WHERE Album = '"+senderAlbumName+"'";
                var com = new SqlCommand(getAlbumsQuery, con);
                var reader = com.ExecuteReader();
                while (reader.Read())
                {
                    var songName = reader.GetString(0).Trim();
                    var songListItem = Global.CreateNewHtmlControl("li", "list-group-item", songName, "", null, null);
                    Global.AddChild(songsListGroup, songListItem);
                    var songNameTextBox = Global.CreateNewHtmlControl("input","","txt"+songName,songName,"type","text");
                    songNameTextBox.Attributes.Add("name",songName);
                    Global.AddChild(songListItem, songNameTextBox);
                    var songAcceptButton = Global.CreateNewLButton("btn btn-success btn-xs", "del" + songName, "v");
                    Global.AddChild(songListItem, songAcceptButton);
                    songAcceptButton.Click += albumButton_Click;
                    var songDeleteButton = Global.CreateNewLButton("btn btn-danger btn-xs", "del" + songName, "x");
                    Global.AddChild(songListItem, songDeleteButton);
                    songDeleteButton.Click += albumButton_Click;

                }
                reader.Close();
                con.Close();
            }
            catch (SqlException ex)
            {
                DebugLabel.Text = ex.ToString();
            }
        }

        protected void acceptButton_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (LinkButton) sender;
                var senderSongName = btn.ID.Substring(3);
                var con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
                con.Open();
                var getAlbumsQuery = "UPDATE Songs SET Song=N'"+Request.Form[senderSongName]+"' WHERE Song='"+senderSongName+"'";
                var com = new SqlCommand(getAlbumsQuery, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                DebugLabel.Text = ex.ToString();
            }
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                var btn = (LinkButton)sender;
                var senderSongName = btn.ID.Substring(3);
                var con =
                    new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
                con.Open();
                var getAlbumsQuery = "DELETE FROM Songs WHERE Song='" + senderSongName + "'";
                var com = new SqlCommand(getAlbumsQuery, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (SqlException ex)
            {
                DebugLabel.Text = ex.ToString();
            }
        }
    }
}