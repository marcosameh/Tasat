using App.UI.Models;
using AppCore.DTO;
using App.UI.Enums;
using AppCore.Managers;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.UI.Pages
{
    public class blogModel : PageModelBase
    {
        private readonly NewsManager newsManager;

        public IEnumerable<News> News { get; set; }

        [BindProperty(SupportsGet =true)]
        public NewsFilter NewsFilter { get; set; }


        public blogModel(NewsManager newsManager)
        {
            this.newsManager = newsManager;
            PageName = PageNames.News;
        }
        public void OnGet()
        {
            News = newsManager.GetNews(NewsFilter);
        }
    }
}