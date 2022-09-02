using App.UI.Enums;
using AppCore.Managers;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace App.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly MediaItemManager mediaItemManager;
        private readonly MenuManager menuManager;
        private readonly EventManager eventManager;
        private readonly GalleryManager galleryManager;

        public MediaItem TopRightMedia { get; set; }
        public MediaItem RightImageMedia { get; set; }
        public MediaItem LeftImageMedia { get; set; }
        public IQueryable<MenuSection> Menu { get; set; }  
        public IQueryable<Event> Events { get; set; }  
        public IQueryable<Gallery> Galleries { get; set; }  
        public IndexModel(MediaItemManager mediaItemManager,
            MenuManager menuManager,EventManager eventManager,GalleryManager galleryManager)
        {
            this.mediaItemManager = mediaItemManager;
            this.menuManager = menuManager;
            this.eventManager = eventManager;
            this.galleryManager = galleryManager;
        }


        public void OnGet()
        {
            Initialize();


        }

        private void Initialize()
        {
            TopRightMedia = mediaItemManager.GetMediaItem(MediaItemKeys.TopRight.ToString());
            RightImageMedia = mediaItemManager.GetMediaItem(MediaItemKeys.RightImage.ToString());
            LeftImageMedia = mediaItemManager.GetMediaItem(MediaItemKeys.LeftImage.ToString());
            Menu=menuManager.GetMenu();
            Events = eventManager.GetEvents();
            Galleries=galleryManager.GetGallery();

        }

    }
}
