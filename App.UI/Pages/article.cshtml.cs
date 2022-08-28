using App.UI.Models;
using AppCore.DTO;
using App.UI.Enums;
using AppCore.Managers;
using AppCore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace App.UI.Pages
{
    public class articleModel : PageModelBase
    {
        private readonly NewsManager newsManager;

        public News NewsArticle { get; set; }
        public IEnumerable<NewsArchive> ArchiveModel { get; set; }
        public IEnumerable<News> AllNews { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ArticleUrlName { get; set; }

        public articleModel(NewsManager newsManager)
        {
            this.newsManager = newsManager;
            PageName = PageNames.News;
        }
        public void OnGet()
        {
            NewsArticle = newsManager.GetNewsDetails(ArticleUrlName);
            AllNews = newsManager.GetNews();
            ArchiveModel = newsManager.GetNewsArchive(AllNews);

        }
    }
}