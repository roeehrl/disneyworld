using System;
using System.Collections.Generic;

namespace disneyworld.Models;

public partial class Country
{
    public int Id { get; set; }
    public int Active { get; set; }

    public string Name { get; set; } = null!;

    public string? ArName { get; set; }

    public string? CallCode { get; set; }

    public string? NationCode { get; set; }

    public virtual ICollection<Person> People { get; } = new List<Person>();

    public virtual ICollection<Site> Sites { get; } = new List<Site>();
}

public partial class CountryDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ArName { get; set; }

    public string? CallCode { get; set; }

    public string? NationCode { get; set; }


}


