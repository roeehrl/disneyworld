﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace disneyworld.Models;

public partial class GeneralContext : DbContext
{
    public GeneralContext()
    {
    }

    public GeneralContext(DbContextOptions<GeneralContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Site> Sites { get; set; }

    public virtual DbSet<SiteType> SiteTypes { get; set; }

    public virtual DbSet<Triplet> Triplets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=disney_db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("countries");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ArName).HasColumnName("ar_name");
            entity.Property(e => e.CallCode)
                .HasMaxLength(50)
                .HasColumnName("call_code");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.NationCode)
                .HasMaxLength(50)
                .HasColumnName("nation_code");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_People");

            entity.ToTable("people");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdditionalName)
                .HasMaxLength(255)
                .HasColumnName("additional_name");
            entity.Property(e => e.ArAdditionalName).HasColumnName("ar_additional_name");
            entity.Property(e => e.ArDetails).HasColumnName("ar_details");
            entity.Property(e => e.ArFirstName)
                .HasMaxLength(50)
                .HasColumnName("ar_first_name");
            entity.Property(e => e.ArLastName)
                .HasMaxLength(50)
                .HasColumnName("ar_last_name");
            entity.Property(e => e.ArNickname)
                .HasMaxLength(50)
                .HasColumnName("ar_nickname");
            entity.Property(e => e.Details).HasColumnName("details");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("last_name");
            entity.Property(e => e.Nationality).HasColumnName("nationality");
            entity.Property(e => e.Nickname)
                .HasMaxLength(255)
                .HasColumnName("nickname");
            entity.Property(e => e.PersonalNumber)
                .HasMaxLength(50)
                .HasColumnName("personal_number");

            entity.HasOne(d => d.NationalityNavigation).WithMany(p => p.People)
                .HasForeignKey(d => d.Nationality)
                .HasConstraintName("FK_people_countries");
        });

        modelBuilder.Entity<Site>(entity =>
        {
            entity.ToTable("sites");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ArDescription).HasColumnName("ar_description");
            entity.Property(e => e.ArName).HasColumnName("ar_name");
            entity.Property(e => e.CoordinateFormat)
                .HasMaxLength(50)
                .HasColumnName("coordinate_format");
            entity.Property(e => e.Coordinates)
                .HasMaxLength(50)
                .HasColumnName("coordinates");
            entity.Property(e => e.Country).HasColumnName("country");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Type).HasColumnName("type");

            entity.HasOne(d => d.CountryNavigation).WithMany(p => p.Sites)
                .HasForeignKey(d => d.Country)
                .HasConstraintName("FK_sites_country");
        });

        modelBuilder.Entity<SiteType>(entity =>
        {
            entity.ToTable("site_types");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ArDescription).HasColumnName("ar_description");
            entity.Property(e => e.ArName).HasColumnName("ar_name");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Triplet>(entity =>
        {
            entity.ToTable("triplets");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ArDescription).HasColumnName("ar_description");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Imei)
                .HasMaxLength(50)
                .HasColumnName("IMEI");
            entity.Property(e => e.Imsi)
                .HasMaxLength(50)
                .HasColumnName("IMSI");
            entity.Property(e => e.Person).HasColumnName("person");
            entity.Property(e => e.Pstn)
                .HasMaxLength(50)
                .HasColumnName("PSTN");

            entity.HasOne(d => d.PersonNavigation).WithMany(p => p.Triplets)
                .HasForeignKey(d => d.Person)
                .HasConstraintName("FK_triplets_people");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}