﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class SitePage
    {
        public SitePage()
        {
            Banners = new HashSet<Banner>();
            MediaCollections = new HashSet<MediaCollection>();
            MediaItems = new HashSet<MediaItem>();
            MetaTags = new HashSet<MetaTag>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Banner> Banners { get; set; }
        public virtual ICollection<MediaCollection> MediaCollections { get; set; }
        public virtual ICollection<MediaItem> MediaItems { get; set; }
        public virtual ICollection<MetaTag> MetaTags { get; set; }
    }
}