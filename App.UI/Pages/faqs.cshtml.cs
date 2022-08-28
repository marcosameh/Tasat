using App.UI.Models;
using App.UI.Enums;
using AppCore.Managers;
using AppCore.Models;
using System.Collections.Generic;

namespace App.UI.Pages
{
    public class faqModel : PageModelBase
    {
        private readonly FaqManager faqManager;
        public IEnumerable<Faq> Faqs { get; set; }
        public faqModel(FaqManager faqManager)
        {
            this.faqManager = faqManager;

            PageName = PageNames.Faqs;
        }
        public void OnGet()
        {
            Faqs = faqManager.GetAllFaqs();
        }
    }
}