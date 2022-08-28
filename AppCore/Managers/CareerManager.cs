using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AppCore.Managers
{
    public class CareerManager
    {
        private readonly int _languageId;
        private readonly AppCoreContext _context;
        public CareerManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _languageId = languageId;
        }

        public IEnumerable<Career> GetAllJobs()
        {
            return _context.Careers.Where(x => x.Active)
                                   .Include(l => l.CareerLocalizeds.Where(l => l.LanguageId == _languageId))
                                   .Include(c => c.City)
                                   .ThenInclude(l => l.CityLocalizeds.Where(l => l.LanguageId == _languageId))
                                   .AsSplitQuery().OrderBy(x => x.DisplayOrder);
        }

    }
}
