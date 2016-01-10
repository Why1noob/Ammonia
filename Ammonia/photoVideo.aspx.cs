using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Ammonia
{
    public partial class PhotoVideo : Page
    {
        protected struct Photo
        {
            int _innerId;
            public string ImgLink { get; private set; }
            public string ImgAlt { get; private set; }

            public Photo(int innerId, string imgLink, string imgAlt) : this()
            {
                _innerId = innerId;
                ImgLink = imgLink;
                ImgAlt = imgAlt;
            }
        }

        public static int CurrentImgId;
        private List<Photo> _allPhotos; 

        protected void Page_Load(object sender, EventArgs e)
        {
            ClientScript.GetPostBackEventReference(this, string.Empty);
            _allPhotos = Load_Images();
            ParseCollection();
            if (Page.IsPostBack) return;
            SetViewedImage(CurrentImgId); 
        }

        protected void SetViewedImage(int imgId)
        {
            ViewedImage.ImageUrl = _allPhotos[imgId].ImgLink;
            ViewedImage.AlternateText = _allPhotos[imgId].ImgAlt;
        }

        protected List<Photo> Load_Images()
        {
            var result = new List<Photo>();
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings["AmmConnectionString"].ConnectionString);
            con.Open();
            const string photosQuery = "SELECT * FROM Photos";
            var com = new SqlCommand(photosQuery, con);
            var reader = com.ExecuteReader();
            while (reader.Read())
            {
                result.Add(new Photo(reader.GetInt32(0),reader.GetString(1).Trim(),reader.GetString(2).Trim()));
            }
            reader.Close();
            con.Close();
            return result;
        }

        protected void PrevButton_Click(object sender, EventArgs e)
        {
            if (CurrentImgId == 0)
            {
                SetViewedImage(CurrentImgId = _allPhotos.Count - 1);
            }
            else
            {
                SetViewedImage(--CurrentImgId);
            }
        }

        protected void NextButton_Click(object sender, EventArgs e)
        {
            if (CurrentImgId == _allPhotos.Count - 1)
            {
                SetViewedImage(CurrentImgId = 0);
            }
            else
            {
                SetViewedImage(++CurrentImgId);
            }
        }
        protected void ParseCollection()
        {
            var counter = 1;
            var currentRow = CurrentRow(counter);
            foreach (var photo in _allPhotos)
            {
                if (counter%4 == 0)
                {
                    CurrentRow(counter);
                }
                var currentImg = Global.CreateNewHtmlControl("img", "col-md-3 bordered", "photo" + counter, "", "src", photo.ImgLink);
                currentImg.Attributes.Add("alt",photo.ImgAlt);
                currentImg.Attributes.Add("height","10%");
                currentImg.Style.Add("padding","0");
                currentImg.Attributes.Add("onclick", "clickFromFrontEnd(this)");
                Global.AddChild(currentRow,currentImg);
                counter++;
            }
        }

        private Panel CurrentRow(int counter)
        {
            var currentRow = Global.CreateNewPanel("col-md-12", "collectionRow" + counter/4, "","padding","0");
            Global.AddChild(CollectionPanel, currentRow);
            return currentRow;
        }



        protected void Unnamed5_Click(object sender, EventArgs e)
        {
            var argument = Request.Form["__EVENTARGUMENT"];
            SetViewedImage(CurrentImgId = Convert.ToInt32(argument.Substring(0, 5)));
        }
    }
}