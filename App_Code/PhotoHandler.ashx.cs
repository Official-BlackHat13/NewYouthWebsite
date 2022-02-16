using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

 /// <summary>
    /// Summary description for UploadHandler
    /// </summary>

    public class PhotoHandler : IHttpHandler
    {
        private bool isRTL = true;
        General gm = new General();
        WebImage WebImage = new WebImage();
        public void ProcessRequest(HttpContext context)
        {
            //System.Threading.Thread.Sleep(60000);

            if (context.Request.QueryString["phptoType"] != null && context.Request.QueryString["id"] != null)
            {
                ImageType phptoType = (ImageType)Convert.ToInt32(context.Request.QueryString["phptoType"]);
                int id = Convert.ToInt32(context.Request.QueryString["id"]);
                bool isActualSize = true;
                if (context.Request.QueryString["ChangeSize"] != null && context.Request.QueryString["ChangeSize"].ToLower() == "1")
                    isActualSize = false;

                GetPhoto(context, phptoType, id, isActualSize);
            }
        }
        public bool IsReusable
        {
            get { return true; }
        }

        private void GetPhoto(HttpContext context, ImageType photoType, int id, bool isActualSize)
        {
            byte[] image = { 0x20 };
            DataTable dt = new DataTable();           

                switch (photoType)
                {
                    case ImageType.News:

                        dt = GetData(1, id);
                      
                        if (dt.Rows.Count>0)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[0]["NewsImage"].ToString()))
                            {
                                image = (Byte[])(dt.Rows[0]["NewsImage"]);
                                if (!isActualSize)
                                    image = WebImage.CreateNewsPhotoThumbnai((Byte[])(dt.Rows[0]["NewsImage"]));
                            }

                        }
                        break;
                    case ImageType.Activity:
                        dt = GetData(6, id);
                        if (dt.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[0]["ActivityImage"].ToString()))
                            {
                                image = (Byte[])(dt.Rows[0]["ActivityImage"]);
                                if (!isActualSize)
                                    image = WebImage.CreateNewsPhotoThumbnai((Byte[])(dt.Rows[0]["ActivityImage"]));
                            }

                        }
                       
                        break;
                    //case ImageType.NewsPhotos:
                    //    BusinessLayer.Data.NewsPhoto newsPhoto = ctx.NewsPhotos.FirstOrDefault(n => n.NewsPhotoID == id);
                    //    if (newsPhoto != null)
                    //    {
                    //        image = newsPhoto.Photo;
                    //        if (!isActualSize)
                    //            image = WebImage.CreatePhotoGalleryThumbnail(newsPhoto.Photo);

                    //    }
                    //    break;
                    //case ImageType.ActivityPhotos:
                    //    BusinessLayer.Data.ActivityPhoto activityPhoto = ctx.ActivityPhotos.FirstOrDefault(n => n.ActivityPhotoID == id);
                    //    if (activityPhoto != null)
                    //    {
                    //        image = activityPhoto.Photo;
                    //        if (!isActualSize)
                    //            image = WebImage.CreatePhotoGalleryThumbnail(activityPhoto.Photo);

                    //    }
                    //    break;
                    case ImageType.PhotoGallery:
                         dt = GetData(4, id);
                        if (dt.Rows.Count > 0)
                        {
                            if (!string.IsNullOrEmpty(dt.Rows[0]["Photo"].ToString()))
                            {
                                image = (Byte[])(dt.Rows[0]["Photo"]);
                                if (!isActualSize)
                                    image = WebImage.CreateNewsPhotoThumbnai((Byte[])(dt.Rows[0]["Photo"]));
                            }

                        }
                       
                        break;
                }
          
            //context.Response.Write(image);

            context.Response.Clear();
            context.Response.ContentType = "image/jpeg";

            context.Response.BinaryWrite(image);

        }
        protected DataTable GetData(int type,int id)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = gm.YPA();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "GetImage";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;           
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@type", type);

            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            con.Open();
            cmd.ExecuteNonQuery();
            sda.Fill(dt);
            con.Close();

            return dt;
        }
    }

    public enum ImageType
    {
        News = 1,
        Summary = 2,
        NewsPhotos = 3,
        PhotoGallery = 4,
        ActivityPhotos = 5,
        Activity = 6,
        ActivitySummary = 7,
    }
