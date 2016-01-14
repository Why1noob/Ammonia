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
                        albumName + "(" + year + ")");
                    Global.AddChild(albumListItem, albumNameButton);
                    var albumDeleteButton = Global.CreateNewLButton("btn btn-danger btn-xs", "del" + albumName, "x", new[] { "style" }, new[] { "margin-left:70%;" });
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
    }
}