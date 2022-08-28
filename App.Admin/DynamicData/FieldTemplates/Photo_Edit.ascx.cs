using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using Image = SixLabors.ImageSharp.Image;

namespace DynamicData.Admin.DynamicData.FieldTemplates
{
    public partial class Photo_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        public string CurrentPhoto
        {
            get
            {
                return "CurrentPhoto-" + Column.Name;
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            SetupHintAttribute();
            PassMaxPhotosSize();
        }

        private void PassMaxPhotosSize()
        {

            double maxRequestLength = 0;
            HttpRuntimeSection section =
            ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
            if (section != null)
                maxRequestLength = section.MaxRequestLength * 0.9;
            hfMaxPhotosSize.Value = maxRequestLength.ToString();
        }

        protected override void OnDataBinding(EventArgs e)
        {

            base.OnDataBinding(e);

            if (!String.IsNullOrEmpty(FieldValueString))
            {
                GetPhotoAttributeValues(out var photoPath, out var thumbnailsPath);

                int dbThumbnail, adminThumbnail;
                PhotoThumbnail[] thumbnails;
                GetThumbnailAttributeValues(out dbThumbnail, out adminThumbnail, out thumbnails);

                Image1.ImageUrl = Setting.FrontendVirtualPath + thumbnailsPath + FieldValueString.Replace(thumbnails[dbThumbnail].Postfix, thumbnails[adminThumbnail].Postfix);

                if (!String.IsNullOrEmpty(photoPath))
                    HyperLink1.NavigateUrl = Setting.FrontendVirtualPath + photoPath + FieldValueString.Replace(thumbnails[dbThumbnail].Postfix, String.Empty);
            }
            else
            {
                SetUpValidator(RequiredFieldValidator1);
                imageContainer.Visible = false;
            }

            //Session.Add(CurrentPhoto, FieldValueString);

            SetUpValidator(RegularExpressionValidator1);
            SetUpValidator(DynamicValidator1);
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            if (FileUpload1.HasFile)
            {
                string prefix = string.Empty;
                string postfix = "_";
                int counter = 0;
                GetPhotoAttributeValues(out var photoPath, out var thumbnailsPath);

                //Save Photo
                if (!string.IsNullOrEmpty(photoPath))
                {
                    string commonPath = Setting.FrontendPhysicalPath + photoPath + prefix
                        + Path.GetFileNameWithoutExtension(FileUpload1.FileName);

                    GetThumbnailAttributeValues(out var dbThumbnail, out var adminThumbnail, out var thumbnails);
                    var requestedExtension = thumbnails.FirstOrDefault().Format;
                    ;
                    string strPath = commonPath + postfix + requestedExtension;
                    strPath = strPath.Replace('/', '\\');

                    while (File.Exists(strPath))
                    {
                        counter++;
                        strPath = commonPath + postfix + counter + postfix + requestedExtension;
                    }

                    if (Directory.Exists(Setting.FrontendPhysicalPath + photoPath) == false)
                        Directory.CreateDirectory(Setting.FrontendPhysicalPath + photoPath);
                    FileUpload1.SaveAs(strPath);
                }
                if (counter != 0)
                {
                    postfix = postfix + counter + postfix;
                }

                //Save thumbnails
                string dbThumbnailFileName = SaveThumbnails(FileUpload1.PostedFile, thumbnailsPath, prefix, postfix);
                dictionary[Column.Name] = dbThumbnailFileName;
            }
        }

        public override Control DataControl
        {
            get
            {
                return FileUpload1;
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

        private string SaveThumbnails(HttpPostedFile photo, string thumbnailsPath, string prefix, string postfix)
        {
            int dbThumbnail, adminThumbnail;
            PhotoThumbnail[] thumbnails;
            GetThumbnailAttributeValues(out dbThumbnail, out adminThumbnail, out thumbnails);

            string dbThumbnailFileName = string.Empty;
            for (int i = 0; i < thumbnails.Length; i++)
            {
                string thumbnailFileName = SaveThumbnail(photo, thumbnailsPath, thumbnails[i].Width, thumbnails[i].Height,
                    thumbnails[i].FixedSizeBackground, prefix, postfix, thumbnails[i].Postfix,
                    thumbnails[i].Format, thumbnails[i].WaterMarkPath, thumbnails[i].WaterMarkPosition);

                if (i == dbThumbnail)
                    dbThumbnailFileName = thumbnailFileName;
            }

            return dbThumbnailFileName;
        }
        private string SaveThumbnail(HttpPostedFile photo, string thumbnailsPath, int width, int height, bool fixedSizeBackground,
            string prefix, string postfix, string thumbnailPostfix, string photoNameExtension, string waterMarkPath, System.Drawing.Point waterMarkPosition)
        {
            string photoName = Path.GetFileNameWithoutExtension(photo.FileName);
            string filePath = Setting.FrontendPhysicalPath + thumbnailsPath + photoName + postfix + thumbnailPostfix + photoNameExtension;
            string originalFilePath = Setting.FrontendPhysicalPath + thumbnailsPath + "\\originals\\" + photoName + postfix + photoNameExtension;

            using (var image = Image.Load(originalFilePath))
            {
                int thumbWidth;
                int thumbHeight;

                if (width < 1)
                    width = image.Width;
                if (height < 1)
                    height = image.Height;

                if (image.Width >= width || image.Height >= height)
                {
                    double widthRatio = (double)image.Width / width;
                    double heightRatio = (double)image.Height / height;
                    double ratio = Math.Max(widthRatio, heightRatio);
                    thumbWidth = (int)(image.Width / ratio);
                    thumbHeight = (int)(image.Height / ratio);
                    image.Mutate(x => x
                     .Resize(thumbWidth, thumbHeight));
                    image.Save(filePath);
                }
                else
                {
                    image.Save(filePath);
                }

            }
            return photoName + postfix + thumbnailPostfix + photoNameExtension;
        }

        private void SetupHintAttribute()
        {
            var metadata = MetadataAttributes.OfType<HintAttribute>().FirstOrDefault();
            lblHintIcon.Visible = false;
            if (metadata != null)
            {
                if (metadata.Hint.Length > 0)
                {
                    lblHintIcon.Visible = lblHint.Visible = true;
                    lblHint.Text = metadata.Hint;
                }
            }
        }
    }
}