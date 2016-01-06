using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;


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
            _allPhotos = Load_Images();
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
    }
}