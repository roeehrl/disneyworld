using System;
using System.Collections.Generic;

namespace disneyworld.Models;

public partial class Sex
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? ArName { get; set; }

    public virtual ICollection<Person> People { get; } = new List<Person>();


}
