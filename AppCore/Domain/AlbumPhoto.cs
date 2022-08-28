
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models
{
    public partial class AlbumPhoto 
    {

        [NotMapped]
        public string smallPhotoPath
        {
            get
            {
                return "/photos/gallery/" + Photo.Replace("lg","sm");
            }
        }

        [NotMapped]
        public string PhotoPath
        {
            get
            {
                return "/photos/gallery/" + Photo;
            }
        }

    }
}
