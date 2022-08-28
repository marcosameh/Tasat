using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppCore.Managers
{

    public class MetaTagManager
    {
        private readonly AppCoreContext _context;
        private readonly int _LanguageId;

        public MetaTagManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _LanguageId = languageId;
        }


        public MetaTag GetPageTags(int pageId, int? categoryId = null)
        {
            var metaTage = _context.MetaTags.Include(u => u.MetaTagLocalizeds.Where(l => l.LanguageId == _LanguageId))
                           .Where(m => m.PageId == pageId)
                           .AsSingleQuery()
                           .FirstOrDefault();
            metaTage?.Localize(_LanguageId);
            return metaTage;
        }

    }
}
