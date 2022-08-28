using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace AppCore.Managers
{
    public class HomeBannerManager
    {
        private readonly AppCoreContext _context;
        private readonly int _languageId;

        public HomeBannerManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _languageId = languageId;
        }

        public List<HomeBanner> GetHomeBanners()
        {
            var homeBanners = _context.HomeBanners.Where(u => u.Active.HasValue)
                                       .Include(x => x.HomeBannerLocalizeds.Where(u => u.LanguageId == _languageId)).AsSingleQuery().ToList();
            homeBanners.ForEach(x => x.Localize(_languageId));
            return homeBanners;
        }
    }
}