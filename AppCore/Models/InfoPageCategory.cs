﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class InfoPageCategory
    {
        public InfoPageCategory()
        {
            InfoPageCategoryLocalizeds = new HashSet<InfoPageCategoryLocalized>();
            InfoPages = new HashSet<InfoPage>();
        }

        public int Id { get; set; }
        public string UrlName { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<InfoPageCategoryLocalized> InfoPageCategoryLocalizeds { get; set; }
        public virtual ICollection<InfoPage> InfoPages { get; set; }
    }
}