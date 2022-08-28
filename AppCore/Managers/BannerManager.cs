using AppCore.Enums;
using AppCore.Models;
using System.Collections.Generic;
using System.Linq;


namespace AppCore.Managers
{
    public class BannerManager
    {
        private readonly AppCoreContext _context;
        private readonly int _languageId;
        public BannerManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _languageId = languageId;
        }

      
       
        public Banner GetBanner(int PageId)
        {
            
            return _context.Banners.SingleOrDefault(u => u.PageId == PageId && u.Active == true);
        }

        public IEnumerable<Banner> GetBanners()
        {
            return _context.Banners.Where(u =>  u.Active.HasValue).OrderBy(x => x.DisplayOrder);
        }

      

    }
}