using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class WebImage
    {
        //public static byte[] FixImageQuelity(byte[] inputBytes)
        //{
        //    var jpegQuality = 20;// Convert.ToByte(ConfigurationManager.AppSettings["ImageQuality"]);
        //    Image image;
        //    using (var inputStream = new MemoryStream(inputBytes))
        //    {
        //        image = Image.FromStream(inputStream);
        //        var jpegEncoder = ImageCodecInfo.GetImageDecoders()
        //          .First(c => c.FormatID == ImageFormat.Jpeg.Guid);
        //        var encoderParameters = new EncoderParameters(1);
        //        encoderParameters.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, jpegQuality);
        //        Byte[] outputBytes;
        //        using (var outputStream = new MemoryStream())
        //        {
        //            image.Save(outputStream, jpegEncoder, encoderParameters);
        //            outputBytes = outputStream.ToArray();
        //        }

        //        return outputBytes;
        //    }
        //}

        //public static byte[] CreateThumbnail(byte[] PassedImage)
        //{
        //    byte[] ReturnedThumbnail;
        //    int thumbnailSize = 150; 

        //    using (MemoryStream StartMemoryStream = new MemoryStream(),
        //                        NewMemoryStream = new MemoryStream())
        //    {
        //        // write the string to the stream  
        //        StartMemoryStream.Write(PassedImage, 0, PassedImage.Length);

        //        // create the start Bitmap from the MemoryStream that contains the image  
        //        Bitmap startBitmap = new Bitmap(StartMemoryStream);

        //        // set thumbnail height and width proportional to the original image.  
        //        int newHeight;
        //        int newWidth;
        //        double HW_ratio;
        //        if (startBitmap.Height > startBitmap.Width)
        //        {
        //            newHeight = thumbnailSize;
        //            HW_ratio = (double)((double)thumbnailSize / (double)startBitmap.Height);
        //            newWidth = (int)(HW_ratio * (double)startBitmap.Width);
        //        }
        //        else
        //        {
        //            newWidth = thumbnailSize;
        //            HW_ratio = (double)((double)thumbnailSize / (double)startBitmap.Width);
        //            newHeight = (int)(HW_ratio * (double)startBitmap.Height);
        //        }

        //        // create a new Bitmap with dimensions for the thumbnail.  
        //        Bitmap newBitmap = new Bitmap(newWidth, newHeight);

        //        // Copy the image from the START Bitmap into the NEW Bitmap.  
        //        // This will create a thumbnail size of the same image.  
        //        newBitmap = ResizeImage(startBitmap, newWidth, newHeight);

        //        // Save this image to the specified stream in the specified format.  
        //        newBitmap.Save(NewMemoryStream, ImageFormat.Jpeg);

        //        // Fill the byte[] for the thumbnail from the new MemoryStream.  
        //        ReturnedThumbnail = NewMemoryStream.ToArray();
        //    }

        //    // return the resized image as a string of bytes.  
        //    return ReturnedThumbnail;
        //}

        public static byte[] CreateNewsPhotoThumbnai(byte[] PassedImage)
        {
            byte[] ReturnedThumbnail;
            //int thumbnailSize = Convert.ToInt32(ConfigurationManager.AppSettings["ThumbnailSize2"]);

            using (MemoryStream StartMemoryStream = new MemoryStream(),
                                NewMemoryStream = new MemoryStream())
            {
                // write the string to the stream  
                StartMemoryStream.Write(PassedImage, 0, PassedImage.Length);

                // create the start Bitmap from the MemoryStream that contains the image  
                Bitmap startBitmap = new Bitmap(StartMemoryStream);

                // set thumbnail height and width proportional to the original image.  
                int newHeight;
                int newWidth;
                //double HW_ratio;
                //if (startBitmap.Height > startBitmap.Width)
                //{
                newHeight = 240;// thumbnailSize;
                                //HW_ratio = (double)((double)thumbnailSize / (double)startBitmap.Height);
                newWidth = 360;// (int)(HW_ratio * (double)startBitmap.Width);
                //}
                //else
                //{
                //    newWidth = thumbnailSize;
                //    HW_ratio = (double)((double)thumbnailSize / (double)startBitmap.Width);
                //    newHeight = (int)(HW_ratio * (double)startBitmap.Height);
                //}

                // create a new Bitmap with dimensions for the thumbnail.  
                Bitmap newBitmap = new Bitmap(newWidth, newHeight);

                // Copy the image from the START Bitmap into the NEW Bitmap.  
                // This will create a thumbnail size of the same image.  
                newBitmap = ResizeImage(startBitmap, newWidth, newHeight);

                // Save this image to the specified stream in the specified format.  
                newBitmap.Save(NewMemoryStream, ImageFormat.Jpeg);

                // Fill the byte[] for the thumbnail from the new MemoryStream.  
                ReturnedThumbnail = NewMemoryStream.ToArray();
            }

            // return the resized image as a string of bytes.  
            return ReturnedThumbnail;
        }

        //public static byte[] CreatePhotoGalleryThumbnail(byte[] PassedImage)
        //{
        //    byte[] ReturnedThumbnail;
        //    //int thumbnailSize = Convert.ToInt32(ConfigurationManager.AppSettings["ThumbnailSize3"]);

        //    using (MemoryStream StartMemoryStream = new MemoryStream(),
        //                        NewMemoryStream = new MemoryStream())
        //    {
        //        // write the string to the stream  
        //        StartMemoryStream.Write(PassedImage, 0, PassedImage.Length);

        //        // create the start Bitmap from the MemoryStream that contains the image  
        //        Bitmap startBitmap = new Bitmap(StartMemoryStream);

        //        // set thumbnail height and width proportional to the original image.  
        //        int newHeight;
        //        int newWidth;
        //        //double HW_ratio;
        //        //if (startBitmap.Height > startBitmap.Width)
        //        //{
        //        //    newHeight = 165;// thumbnailSize;
        //        //    HW_ratio = (double)((double)thumbnailSize / (double)startBitmap.Height);
        //        //    newWidth = 110;// (int)(HW_ratio * (double)startBitmap.Width);
        //        //}
        //        //else
        //        //{
        //        newWidth = 165;// thumbnailSize;
        //        //HW_ratio = (double)((double)thumbnailSize / (double)startBitmap.Width);
        //        newHeight = 110;// (int)(HW_ratio * (double)startBitmap.Height);
        //        //}

        //        // create a new Bitmap with dimensions for the thumbnail.  
        //        Bitmap newBitmap = new Bitmap(newWidth, newHeight);

        //        // Copy the image from the START Bitmap into the NEW Bitmap.  
        //        // This will create a thumbnail size of the same image.  
        //        newBitmap = ResizeImage(startBitmap, newWidth, newHeight);

        //        // Save this image to the specified stream in the specified format.  
        //        newBitmap.Save(NewMemoryStream, ImageFormat.Jpeg);

        //        // Fill the byte[] for the thumbnail from the new MemoryStream.  
        //        ReturnedThumbnail = NewMemoryStream.ToArray();
        //    }

        //    // return the resized image as a string of bytes.  
        //    return ReturnedThumbnail;
        //}

        // Resize a Bitmap  
        private static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
            }
            return resizedImage;
        }
    }

