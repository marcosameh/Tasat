using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Script.Serialization;
using DynamicData.Admin.Infrastructure;
using DynamicData.Admin.Infrastructure.MultiUploadEntities;
using System.Drawing;

namespace DynamicData.Admin.API
{
    public class UploadController : ApiController
    {

        [HttpPost()]
        [ActionName("UploadPhoto")]
        public object UploadPhoto()
        {
            var uploadProp = HttpContext.Current.Request.Form["propertiesJson"];
            MultiUpload uploadProperties = new JavaScriptSerializer().Deserialize<MultiUpload>(uploadProp);

            string prefix = String.Empty;
            string postfix = "_" + Utility.GetRand() + "_";

            string photoPath, thumbnailsPath;
            photoPath = string.Format("Photos/{0}/Originals/", uploadProperties.TargetFolder);
            thumbnailsPath = string.Format("Photos/{0}/", uploadProperties.TargetFolder);

            bool isSavedSuccessfully = true;
            List<UploadedPhoto> photos = new List<UploadedPhoto>();
            try
            {
                if (Directory.Exists(Utility.FrontendPhysicalPath + photoPath) == false)
                    Directory.CreateDirectory(Utility.FrontendPhysicalPath + photoPath);
                foreach (string fileName in HttpContext.Current.Request.Files)
                {
                    HttpPostedFile file = HttpContext.Current.Request.Files[fileName];
                    if (file != null && file.ContentLength > 0)
                    {
                        #region save photo
                        string strPath = Utility.FrontendPhysicalPath + photoPath + prefix
                                + Path.GetFileNameWithoutExtension(file.FileName) + postfix + Path.GetExtension(file.FileName);
                        strPath = strPath.Replace('/', '\\');
                        file.SaveAs(strPath);
                        photos.Add(new UploadedPhoto()
                        {
                            LargePhotoName = Path.GetFileNameWithoutExtension(file.FileName) + postfix + "lg" + Path.GetExtension(file.FileName),
                            Name = file.FileName
                        });

                        #endregion

                        #region save thumbnails
                        SaveThumbnails(file, thumbnailsPath, prefix, postfix, uploadProperties.PhotoThumbnails);
                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
                return new { Message = ex.Message };
            }
            if (isSavedSuccessfully)
            {
                return photos;
            }
            else
            {
                return new { Message = "Error in saving file" };
            }
        }

        private void SaveThumbnails(HttpPostedFile photo, string thumbnailsPath, string prefix, string postfix, PhotoThumbnail[] thumbnails)
        {
            for (int i = 0; i < thumbnails.Length; i++)
            {
                SaveThumbnail(photo, thumbnailsPath, thumbnails[i].Width, thumbnails[i].Height, thumbnails[i].FixedSizeBackground, prefix, postfix + thumbnails[i].Postfix, thumbnails[i].Format, thumbnails[i].WaterMarkPath, thumbnails[i].WaterMarkPosition);
            }
        }
        private string SaveThumbnail(HttpPostedFile photo, string thumbnailsPath, int width, int height, bool fixedSizeBackground,
            string prefix, string postfix, string photoNameExtension, string waterMarkPath, Point waterMarkPosition)
        {
            string photoName = Path.GetFileNameWithoutExtension(photo.FileName);

            byte[] photoContents = new byte[photo.ContentLength];
            photo.InputStream.Position = 0;
            photo.InputStream.Read(photoContents, 0, photo.ContentLength);

            PhotosUtility photosUtility = new PhotosUtility
            {
                BrushBrush = System.Drawing.Color.White,
                MaxThumbnailWidth = width,
                MaxThumbnailHeight = height,
                ThumbnailPath = Utility.FrontendPhysicalPath + thumbnailsPath,
                ThumbnailExtension = photoNameExtension,
                WaterMarkPath = waterMarkPath,
                WaterMarkPosition = waterMarkPosition
            };

            //Save PhotoThumbnail
            byte[] thumbnailContents = photosUtility.GetThumbnail(photoContents, width, height, fixedSizeBackground, photoNameExtension);
            if (!string.IsNullOrEmpty(waterMarkPath))
                thumbnailContents = photosUtility.AddWatermark(thumbnailContents);
            return photosUtility.CreateThumbnailFile(photoName, prefix, postfix, thumbnailContents);
        }
    }
}