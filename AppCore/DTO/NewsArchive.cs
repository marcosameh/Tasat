using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCore.DTO
{
    public class NewsArchive
    {
        public string TargetYear;
        public int Year { get; set; }
        public IEnumerable<News> NewsDates { get; set; }
        public IEnumerable<NewsGroupedMonth> Months { get; set; }
    }
}
