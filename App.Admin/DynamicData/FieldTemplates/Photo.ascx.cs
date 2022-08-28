using System;
using System.IO;
using System.Linq;
using System.Web.UI;

namespace DynamicData.Admin
{
    public partial class PhotoField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected override void OnDataBinding(EventArgs e)
        {
            base.OnDataBinding(e);

            if (!String.IsNullOrEmpty(FieldValueString))
            {
                string photoPath, thumbnailsPath;
                GetPhotoAttributeValues(out photoPath, out thumbnailsPath);

                int dbThumbnail, adminThumbnail;
                PhotoThumbnail[] thumbnails;
                GetThumbnailAttributeValues(out dbThumbnail, out adminThumbnail, out thumbnails);

                Image1.ImageUrl = Setting.FrontendVirtualPath + thumbnailsPath +
                    FieldValueString.Replace("_" + thumbnails[dbThumbnail].Postfix + ".", "_" + thumbnails[adminThumbnail].Postfix + ".");

                if (!String.IsNullOrEmpty(photoPath))
                {
                    var imgPartialPath = photoPath + FieldValueString.Replace(thumbnails[dbThumbnail].Postfix, String.Empty);
                    if (File.Exists(Setting.FrontendPhysicalPath + imgPartialPath))
                    {
                        HyperLink1.NavigateUrl = Setting.FrontendVirtualPath + imgPartialPath;
                    }
                    else if (File.Exists(Setting.FrontendPhysicalPath + imgPartialPath.Replace(".jpg", ".png")))
                    {
                        HyperLink1.NavigateUrl = Setting.FrontendVirtualPath + imgPartialPath.Replace(".jpg", ".png");
                    }
                    else
                    {
                        HyperLink1.NavigateUrl = "#.";
                    }
                }
            }
        }

        public override Control DataControl
        {
            get
            {
                return Image1;
            }
        }

        private void GetPhotoAttributeValues(out string photoPath, out string thumbnailsPath)
        {
            var metadata = MetadataAttributes.OfType<PhotoAttribute>().FirstOrDefault();

            if (metadata != null)
            {
                photoPath = metadata.PhotoPath;
                thumbnailsPath = metadata.ThumbnailsPath;
            }
            else
                photoPath = thumbnailsPath = String.Empty;
        }
        private void GetThumbnailAttributeValues(out int dbThumbnails, out int adminThumbnail, out PhotoThumbnail[] thumbnails)
        {
            var metadata = MetadataAttributes.OfType<PhotoThumbnailAttribute>().FirstOrDefault();
            if (metadata != null)
            {
                dbThumbnails = metadata.DbThumbnail;
                adminThumbnail = metadata.AdminThumbnail;
                thumbnails = metadata.Thumbnails.Values.ToArray();
            }
            else
                throw new Exception("No thumbnails attribute found.");
        }
    }
}