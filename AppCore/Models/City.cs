﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace AppCore.Models
{
    public partial class City
    {
        public City()
        {
            Careers = new HashSet<Career>();
            CityLocalizeds = new HashSet<CityLocalized>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Career> Careers { get; set; }
        public virtual ICollection<CityLocalized> CityLocalizeds { get; set; }
    }
}