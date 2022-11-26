using System;
using System.Collections.Generic;

namespace disneyworld.Models;

public partial class SiteType
{
    public int Id { get; set; }

    public int Active { get; set; }


    public string? Name { get; set; }

    public string? ArName { get; set; }

    public string? Description { get; set; }

    public string? ArDescription { get; set; }
}
