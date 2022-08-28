using AppCore.Models;
using System.Linq;


namespace AppCore.Managers
{
    public class LanguageManager
    {
        private readonly AppCoreContext _context;
        private readonly int _languageId;

        public LanguageManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _languageId = languageId;
        }

        public IQueryable<Language> GetAciveLanguages()
        {
            return _context.Languages.Where(u => u.Active).OrderBy(x => x.DisplayOrder);
        }
    }
}