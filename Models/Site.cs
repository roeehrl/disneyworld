using System;
using System.Collections.Generic;

namespace disneyworld.Models
{
    public partial class Site
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ArName { get; set; }
        public int? CoordinateFormat { get; set; }
        public string? Coordinates { get; set; }
        public string? ArDescription { get; set; }
        public string? Description { get; set; }
        public int? Type { get; set; }
        public int? Country { get; set; }
        public int? Active { get; set; }
        public int? Updater { get; set; }
        public int? Uploader { get; set; }

        public virtual Geoformat? CoordinateFormatNavigation { get; set; }
        public virtual Country? CountryNavigation { get; set; }
    }
}
