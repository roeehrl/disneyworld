using System;
using System.Collections.Generic;

namespace disneyworld.Models;

public partial class Site
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ArName { get; set; }

    public string? CoordinateFormat { get; set; }

    public string? Coordinates { get; set; }

    public int? ArDescription { get; set; }

    public string? Description { get; set; }

    public int? Type { get; set; }

    public int? Country { get; set; }

    public virtual Country? CountryNavigation { get; set; }
}

public partial class SiteDTO
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ArName { get; set; }

    public string? CoordinateFormat { get; set; }

    public string? Coordinates { get; set; }

    public int? ArDescription { get; set; }

    public string? Description { get; set; }

    public string? TypeName { get; set; }

    public string? CountryName { get; set; }

}

