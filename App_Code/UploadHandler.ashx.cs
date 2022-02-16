using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.SessionState;
//using YPA.BusinessLayer.Data;
//using YPA.BusinessLayer.Types;

namespace YPA.Web.Handlers
{
    /// <summary>
    /// Summary description for UploadHandler
    /// </summary>

    public class UploadHandler : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //System.Threading.Thread.Sleep(60000);
                if (context.Request.Files.Count > 0)
                {
                    if (context.Request.QueryString["uploadType"] != null)
                    {
                        ImageType uploadType = (ImageType)Convert.ToInt32(context.Request.QueryString["uploadType"]);
                        UploadUserProfile(context, uploadType);
                    }

                }
            }
            catch (Exception ex)
            {


            }
            }


        
        public bool IsReusable
        {
            get { return false; }
        }

        private void UploadUserProfile(HttpContext context, ImageType uploadType)
        {
            HttpFileCollection selectedFiles = context.Request.Files;
            for (int i = 0; i < selectedFiles.Count; i++)
            {
                HttpPostedFile PostedFile = selectedFiles[i];

                int nFileLen = PostedFile.ContentLength;
                byte[] baFileData = new byte[nFileLen];
                if (nFileLen > 0)
                {
                    PostedFile.InputStream.Read(baFileData, 0, nFileLen);
                    switch (uploadType)
                    {
                        case ImageType.News:
                            HttpContext.Current.Session["NewsImage"] = baFileData;
                            break;
                        case ImageType.Activity:
                            HttpContext.Current.Session["ActivityImage"] = baFileData;
                            break;
                        case ImageType.Summary:
                            HttpContext.Current.Session["NewsSummaryImage"] = baFileData;
                            break;
                        case ImageType.ActivitySummary:
                            HttpContext.Current.Session["ActivitySummaryImage"] = baFileData;
                            break;
                        case ImageType.NewsPhotos:
                            HttpContext.Current.Session["NewsPhotoGallery"] = baFileData;

                            break;
                        case ImageType.PhotoGallery:
                            HttpContext.Current.Session["PhotoGallery"] = baFileData;
                            break;
                        case ImageType.ActivityPhotos:
                            HttpContext.Current.Session["ActivitiesPhotoGallery"] = baFileData;
                            break;
                    }
                }
            }
        }
    }
}