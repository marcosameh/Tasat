using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class Gallery
    {
        [NotMapped]
        public string SmallPhotoPath
        {
            get
            {
                return "/photos/gallery/" + Photo.Replace("lg", "sm");
            }
        }
        [NotMapped]
        public string LargePhotoPath
        {
            get
            {
                return "/photos/gallery/" + Photo;
            }
        }
    }
}
