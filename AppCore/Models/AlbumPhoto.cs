﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class AlbumPhoto
    {
        public int Id { get; set; }
        public int AlbumId { get; set; }
        public string Photo { get; set; }
        public int DisplayOrder { get; set; }

        public virtual Album Album { get; set; }
    }
}