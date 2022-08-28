using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppCore.Managers
{
    public class InfoPageManager
    {
        private readonly AppCoreContext _context;
        private readonly int _languageId;

        public InfoPageManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _languageId = languageId;
        }

        public IQueryable<InfoPage> GetInfoPages()
        {
            return _context.InfoPages.Where(u => u.Active.HasValue)
                                     .Include(x => x.InfoPageLocalizeds.Where(u => u.LanguageId == _languageId))
                                     .Include(x => x.Category)
                                     .ThenInclude(l => l.InfoPageCategoryLocalizeds.Where(u => u.LanguageId == _languageId))
                                     .AsSplitQuery()
                                     .OrderBy(x => x.DisplayOrder);
        }

        public InfoPage GetInfoPage(string urlName)
        {
            var infoPage = _context.InfoPages.AsSingleQuery()
                                             .Include(l => l.InfoPageLocalizeds.Where(u => u.LanguageId == _languageId))
                                             .SingleOrDefault(u => u.UrlName.ToLower().Equals(urlName.ToLower()));

            infoPage.Localize(_languageId);
            return infoPage;
        }
    }
}
