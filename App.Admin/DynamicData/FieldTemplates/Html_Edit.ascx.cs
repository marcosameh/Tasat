using System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.Configuration;
using System.Web.DynamicData;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DynamicData.Admin
{
    public partial class Html_EditField : System.Web.DynamicData.FieldTemplateUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Setup validators
            SetUpValidator(rfvHtmlField);
        }

        protected override void ExtractValues(IOrderedDictionary dictionary)
        {
            dictionary[Column.Name] = GetHtml(txtHtmlField.Text, hfImages.Value);
        }

        public override Control DataControl
        {
            get
            {
                return txtHtmlField;
            }
        }

        private string GetHtml(string html, string images)
        {
            if (!String.IsNullOrEmpty(html) && !String.IsNullOrEmpty(images))
            {
                PhotosUtility photosUtility = new PhotosUtility();
                photosUtility.ThumbnailPath = WebConfigurationManager.AppSettings["FrontendPhysicalPath"] + @"UserFiles\Image\Thumbnail\";

                string[] imagesArray = images.Split(new string[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                string[] imageProperties;

                string path;
                int width, height;
                string photoName, photoNameWithoutExtension, thumbnailPostfix, photoExtension;
                for (int count = 0; count < imagesArray.Length; count++)
                {
                    imageProperties = imagesArray[count].Split('|');
                    path = imageProperties[0];
                    width = Convert.ToInt32(imageProperties[1]);
                    height = Convert.ToInt32(imageProperties[2]);

                    photoName = Path.GetFileName(path);
                    photoNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                    photoExtension = Path.GetExtension(path);
                    thumbnailPostfix = String.Format("-thumb({0}x{1})", width, height);

                    //Generate only first time, not every update
                    if (!path.Contains(thumbnailPostfix))
                    {
                        //Read Photo
                        byte[] photoContents = File.ReadAllBytes(Server.MapPath(path.Replace(WebConfigurationManager.AppSettings["FrontendVirtualPath"], "~/")));
                        System.Drawing.Image photo = System.Drawing.Image.FromStream(new MemoryStream(photoContents));

                        if (photo.Width != width && photo.Height != height)
                        {
                            //Save Thumbnail
                            byte[] thumbnailContents = photosUtility.GetThumbnail(photoContents, width, height, false, photoExtension);
                            string thumbnailName = photosUtility.CreateThumbnailFile(photoNameWithoutExtension, String.Empty, thumbnailPostfix, thumbnailContents);
                            //Replace (img src)
                            html = ReplaceImageSrc(html, count, path, photoName, thumbnailName);
                        }
                    }
                }
            }

            return html;
        }

        //Replaces at the specified <img tag count index only
        private string ReplaceImageSrc(string html, int count, string path, string photoName, string thumbnailName)
        {
            if (!path.Contains("/thumbnail/"))
                thumbnailName = "thumbnail/" + thumbnailName;

            int startIndex = 0;
            for (int i = 0; i <= count; i++)
            {
                startIndex = html.IndexOf("<img", startIndex);
            }

            int photoNameIndex = html.IndexOf(photoName, startIndex), photoNameLength = photoName.Length;
            html = html.Remove(photoNameIndex, photoNameLength);
            html = html.Insert(photoNameIndex, thumbnailName);

            return html;
        }
    }
}