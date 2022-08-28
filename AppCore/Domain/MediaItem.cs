namespace AppCore.Models
{
    public partial class MediaItem
    {
        public string PhotoPath
        {
            get
            {
                return "/photos/media-items/" + Photo;
            }
        }

    }
}
