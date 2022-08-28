using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DynamicData.Admin.Infrastructure.MultiUploadEntities
{
    public class MultiUpload
    {
        public string TargetFolder { get; set; }

        public bool Resize { get; set; }

        public string PhotoThumbnail { get; set; }

        public PhotoThumbnail[] PhotoThumbnails
        {
            get
            {
                if (!Resize || string.IsNullOrEmpty(PhotoThumbnail))
                    return null;

                string[] photoThumbs = PhotoThumbnail.Split('|');
                if (photoThumbs.Length <= 0)
                    return null;

                List<PhotoThumbnail> result = new List<PhotoThumbnail>();
                foreach (string photoThumb in photoThumbs)
                {
                    result.Add(new PhotoThumbnail(photoThumb));
                }

                return result.ToArray();
            }
        }
    }
}