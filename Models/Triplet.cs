using System;
using System.Collections.Generic;

namespace disneyworld.Models;

public partial class Triplet
{
    public int Id { get; set; }

    public int? Person { get; set; }

    public string? Pstn { get; set; }

    public string? Imei { get; set; }

    public string? Imsi { get; set; }

    public string? Description { get; set; }

    public string? ArDescription { get; set; }

    public virtual Person? PersonNavigation { get; set; }
}
