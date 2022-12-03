using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using disneyworld.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace disneyworld.Models
{
    public partial class GeneralContext : IdentityUserContext<IdentityUser>
    {
        public GeneralContext()
        {
        }

        public GeneralContext(DbContextOptions<GeneralContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Geoformat> Geoformats { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Sex> Sexes { get; set; } = null!;
        public virtual DbSet<Site> Sites { get; set; } = null!;
        public virtual DbSet<SiteType> SiteTypes { get; set; } = null!;
        public virtual DbSet<Triplet> Triplets { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:jointdb.database.windows.net,1433;Initial Catalog=general;Persist Security Info=False;User ID=manager;Password=dinsey123!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("countries");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

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

            modelBuilder.Entity<Geoformat>(entity =>
            {
                entity.ToTable("geoformat");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("people");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

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

                entity.Property(e => e.Sex)
                    .HasColumnName("sex")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Updater).HasColumnName("updater");

                entity.Property(e => e.Uploader).HasColumnName("uploader");

                entity.HasOne(d => d.NationalityNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.Nationality)
                    .HasConstraintName("FK_people_countries");

                entity.HasOne(d => d.SexNavigation)
                    .WithMany(p => p.People)
                    .HasForeignKey(d => d.Sex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_people_sexes");
            });

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.ToTable("sexes");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ArName)
                    .HasMaxLength(50)
                    .HasColumnName("ar_name");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Site>(entity =>
            {
                entity.ToTable("sites");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ArDescription).HasColumnName("ar_description");

                entity.Property(e => e.ArName).HasColumnName("ar_name");

                entity.Property(e => e.CoordinateFormat).HasColumnName("coordinate_format");

                entity.Property(e => e.Coordinates)
                    .HasMaxLength(50)
                    .HasColumnName("coordinates");

                entity.Property(e => e.Country).HasColumnName("country");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Updater).HasColumnName("updater");

                entity.Property(e => e.Uploader).HasColumnName("uploader");

                entity.HasOne(d => d.CoordinateFormatNavigation)
                    .WithMany(p => p.Sites)
                    .HasForeignKey(d => d.CoordinateFormat)
                    .HasConstraintName("FK_sites_geoformat");

                entity.HasOne(d => d.CountryNavigation)
                    .WithMany(p => p.Sites)
                    .HasForeignKey(d => d.Country)
                    .HasConstraintName("FK_sites_country");
            });

            modelBuilder.Entity<SiteType>(entity =>
            {
                entity.ToTable("site_types");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

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

                entity.Property(e => e.Active)
                    .HasColumnName("active")
                    .HasDefaultValueSql("((1))");

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

                entity.Property(e => e.Updater).HasColumnName("updater");

                entity.Property(e => e.Uploader).HasColumnName("uploader");

                entity.HasOne(d => d.PersonNavigation)
                    .WithMany(p => p.Triplets)
                    .HasForeignKey(d => d.Person)
                    .HasConstraintName("FK_triplets_people");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
