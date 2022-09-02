using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Managers
{
    public class GalleryManager
    {
        private readonly AppCoreContext appCoreContext;

        public GalleryManager(AppCoreContext appCoreContext)
        {
            this.appCoreContext = appCoreContext;
        }

        public IQueryable<Gallery> GetGallery()
        {
            return appCoreContext.Galleries.OrderBy(x => x.DisplayOrder);
        }
    }
}
