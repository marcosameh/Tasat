﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class MediaItem
    {
        public int Id { get; set; }
        public string Photo { get; set; }
        public string Alt { get; set; }
        public string VedioUrl { get; set; }
        public int? DisplayOrder { get; set; }
        public string ItemKey { get; set; }
        public int PageId { get; set; }
        public int? MediaCollectionId { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual MediaCollection MediaCollection { get; set; }
        public virtual SitePage Page { get; set; }
    }
}