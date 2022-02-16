<%@ WebHandler Language="C#" Class="PhotoHandler" %>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Data;
using System.Data.SqlClient;

public class PhotoHandler : IHttpHandler, IRequiresSessionState
{
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


    private DataTable GetImage(string tableName, int id ,string column)
    {
        DataTable dt = new DataTable();
        General gm = new General();

        string SQLstring = "select * from " + tableName + " where "+column+"='"+id+"'";

        using (SqlConnection cnn = new SqlConnection())
        {
            cnn.ConnectionString = gm.YPA();
            cnn.Open();

            var SDA = new SqlDataAdapter(SQLstring, cnn);
           

            SDA.Fill(dt);
            SDA.Dispose();
            return dt;

        }
        
    }

    private void GetPhoto(HttpContext context, ImageType photoType, int id, bool isActualSize)
    {
        byte[] image = { 0x20 };
        DataTable dt = new DataTable();
        //using (YPADBContext ctx = new YPADBContext())
        {

            switch (photoType)
            {
                case ImageType.News:
                    dt = GetImage("News", id, "NewsID");
                    if (dt.Rows.Count > 0)
                    {
                        image = (byte[])dt.Rows[0]["NewsImage"];
                        if (!isActualSize)
                            image = WebImage.CreateNewsPhotoThumbnai(image);
                    }                
                    break;
                case ImageType.Activity:

                    dt = GetImage("Activities", id, "ActivityID");
                    if (dt.Rows.Count > 0)
                    {
                        image = (byte[])dt.Rows[0]["ActivityImage"];
                        if (!isActualSize)
                            image = WebImage.CreateNewsPhotoThumbnai(image);
                    }                   
                    break;
                case ImageType.NewsPhotos:

                    dt = GetImage("NewsPhotos", id, "NewsPhotoID");
                    if (dt.Rows.Count > 0)
                    {
                        image = (byte[])dt.Rows[0]["Photo"];
                        if (!isActualSize)
                            image = WebImage.CreateNewsPhotoThumbnai(image);
                    }                   
                    break;                    
                    
                case ImageType.ActivityPhotos:

                    dt = GetImage("ActivityPhotos", id, "ActivityPhotoID");
                    if (dt.Rows.Count > 0)
                    {
                        image = (byte[])dt.Rows[0]["Photo"];
                        if (!isActualSize)
                            image = WebImage.CreateNewsPhotoThumbnai(image);
                    }                   
                    break;
                    
                case ImageType.PhotoGallery:
                    dt = GetImage("PhotoGallery", id, "PhotoID");
                    if (dt.Rows.Count > 0)
                    {
                        image = (byte[])dt.Rows[0]["Photo"];
                        if (!isActualSize)
                            image = WebImage.CreateNewsPhotoThumbnai(image);
                    }  
                   
                    break;
            }
        }
        //context.Response.Write(image);

        context.Response.Clear();
        context.Response.ContentType = "image/jpeg";

        context.Response.BinaryWrite(image);

    }
}



//public class PhotoHandler : IHttpHandler {
    
//    public void ProcessRequest (HttpContext context) {
//        context.Response.ContentType = "text/plain";
//        context.Response.Write("Hello World");
//    }
 
//    public bool IsReusable {
//        get {
//            return false;
//        }
//    }

//}