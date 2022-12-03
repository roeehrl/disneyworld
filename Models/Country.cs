using System;
using System.Collections.Generic;

namespace disneyworld.Models
{
    public partial class Country
    {
        public Country()
        {
            People = new HashSet<Person>();
            Sites = new HashSet<Site>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ArName { get; set; }
        public string? CallCode { get; set; }
        public string? NationCode { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Person> People { get; set; }
        public virtual ICollection<Site> Sites { get; set; }
    }
}
