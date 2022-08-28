using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppCore.Managers
{
    public class FaqManager
    {
        private readonly int _languageId;
        private readonly AppCoreContext _context;
        public FaqManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _languageId = languageId;
        }

        public List<FaqCategory> GetCategories()
        {
            List<FaqCategory> faqCategories = _context.FaqCategories
                                        .Include(u => u.FaqCategoryLocalizeds.Where(u => u.LanguageId == _languageId))
                                        .Include(f => f.Faqs).ThenInclude(l => l.FaqLocalizeds.Where(e => e.LanguageId == _languageId)).
                                        OrderBy(u => u.UrlName).AsSplitQuery().ToList();
            faqCategories.ForEach(e => e.Localize(_languageId));
            return faqCategories;
        }


        public List<Faq> GetAllFaqs()
        {
            List<Faq> faqs =  _context.Faqs
                           .Include(l => l.FaqLocalizeds.Where(e => e.LanguageId == _languageId))
                           .OrderBy(u => u.DisplayOrder).AsSingleQuery().ToList();

            faqs.ForEach(e => e.Localize(_languageId));
            return faqs;
        }
    }
}