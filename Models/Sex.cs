using System;
using System.Collections.Generic;

namespace disneyworld.Models
{
    public partial class Sex
    {
        public Sex()
        {
            People = new HashSet<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? ArName { get; set; }
        public int Active { get; set; }

        public virtual ICollection<Person> People { get; set; }
    }
}
