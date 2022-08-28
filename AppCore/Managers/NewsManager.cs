using AppCore.DTO;
using AppCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AppCore.Managers
{
    public class NewsManager
    {
        private readonly AppCoreContext _context;
        private readonly int _languageId;

        public NewsManager(AppCoreContext context, int languageId)
        {
            _context = context;
            _languageId = languageId;
        }
        public News GetNewsDetails(string UrlName)
        {
            var newsDetail = _context.News.Where(x => x.UrlName == UrlName)
                           .Include(u => u.NewsLocalizeds.Where(l => l.LanguageId == _languageId)).AsSingleQuery().FirstOrDefault();
            newsDetail.Localize(_languageId);
            return newsDetail;
        }
        public List<News> GetNews()
        {
            var newsList = _context.News.Where(x => x.Active.Value)
                   .Include(u => u.NewsLocalizeds.Where(l => l.LanguageId == _languageId))
                   .AsSingleQuery()
                   .OrderByDescending(x => x.NewsDate).ToList();

            newsList.ForEach(x => x.Localize(_languageId));
            return newsList;
        }

        //public IQueryable<News> GetNews(NewsFilter newsFilter)
        //{
        //    return repo.GetMany(x => x.Active.Value &&
        //    (newsFilter.Year.HasValue == false
        //    || x.NewsDate.Year == newsFilter.Year) &&
        //                (newsFilter.Month.HasValue == false || x.NewsDate.Month == newsFilter.Month))
        //        .OrderByDescending(x => x.NewsDate);
        //}


        public IQueryable<News> GetNews(NewsFilter newsFilter)
        {
            if (newsFilter.Month == null && newsFilter.Year == null)
            {
                return GetNews().AsQueryable();
            }

            var month = newsFilter.Month ?? 1;
            var year = newsFilter.Year ?? DateTime.Today.Year;

            return _context.News
                            .Where(x => x.Active.Value && x.NewsDate.Month == month && x.NewsDate.Year == year)
                            .Include(u => u.NewsLocalizeds.Where(l => l.LanguageId == _languageId))
                            .AsSingleQuery()
                            .OrderByDescending(x => x.NewsDate);
        }

        public List<News> GetRecentNews(int count, int? currentNewsId)
        {
            List<News> newsList = _context.News.Where(x => x.Active.Value)
                .Include(u => u.NewsLocalizeds.Where(l => l.LanguageId == _languageId)).AsSingleQuery()
                .OrderByDescending(x => x.NewsDate).ToList();
            newsList.ForEach(x => x.Localize(_languageId));

            if (currentNewsId != null)
            {
                return newsList.Where(u => u.Id != currentNewsId.Value).ToList();
            }
            return newsList;
        }

        //public News GetNextNews(int newsId)
        //{
        //    return _context.News.LastOrDefault(x => x.Id > newsId);

        //}

        //public News GetPreviousNews(int newsId)
        //{
        //    return repo.GetAll().LastOrDefault(x => x.Id < newsId);
        //}

        public IEnumerable<NewsArchive> GetNewsArchive(IEnumerable<News> news)
        {
            if (news != null && news.Any())
            {
                return news.GroupBy(x => x.NewsDate.Year).Select(c => new NewsArchive
                {
                    Year = c.Key,
                    Months = c.GroupBy(x => x.NewsDate.Month).Select(m => new NewsGroupedMonth { Month = m.Key, NewsList = m, Year = c.Key })
                });
            }

            return default;
        }


    }
}




