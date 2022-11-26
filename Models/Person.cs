using System;
using System.Collections.Generic;

namespace disneyworld.Models;

public partial class Person
{
    public int Id { get; set; }

    public int Active { get; set; }

    public int Sex { get; set; }


    public string FirstName { get; set; } = null!;

    public string? LastName { get; set; }

    public string? Nickname { get; set; }

    public string? AdditionalName { get; set; }

    public string? ArFirstName { get; set; }

    public string? ArLastName { get; set; }

    public string? ArNickname { get; set; }

    public string? ArAdditionalName { get; set; }

    public int? Nationality { get; set; }

    public string? Details { get; set; }

    public string? ArDetails { get; set; }

    public string? PersonalNumber { get; set; }

    public virtual Country? NationalityNavigation { get; set; }

    public virtual Sex? SexNavigation { get; set; }


    public virtual ICollection<Triplet> Triplets { get; } = new List<Triplet>();
}
