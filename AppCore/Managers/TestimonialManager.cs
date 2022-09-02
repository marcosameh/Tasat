using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Managers
{
    public class TestimonialManager
    {
        private readonly AppCoreContext _context;
        private readonly int _LanguageId;
        public TestimonialManager(AppCoreContext context, int LanguageId)
        {
            _context = context;
            _LanguageId = LanguageId;
        }

        public IEnumerable<Testimonial> GetTestimonials()
        {
            var list = _context.Testimonials.Where(x => x.Active.Value)                  
                   .OrderBy(x => x.DisplayOrder).ToList();

            return list;
        }
    }
}
