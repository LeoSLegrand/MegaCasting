using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MegaCasting.DBLib.Class;

public partial class MegaCastingContext : DbContext
{
    public MegaCastingContext()
    {
    }

    public MegaCastingContext(DbContextOptions<MegaCastingContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adresse> Adresses { get; set; }

    public virtual DbSet<Artiste> Artistes { get; set; }

    public virtual DbSet<Casting> Castings { get; set; }

    public virtual DbSet<Contrat> Contrats { get; set; }

    public virtual DbSet<Diffuseur> Diffuseurs { get; set; }

    public virtual DbSet<Metier> Metiers { get; set; }

    public virtual DbSet<Partenaire> Partenaires { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=MegaCasting;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adresse>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Adresse__3213E83FD39BDA30");

            entity.ToTable("Adresse");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CodePostal)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("code_postal");
            entity.Property(e => e.Rue)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("rue");
            entity.Property(e => e.Ville)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("ville");
        });

        modelBuilder.Entity<Artiste>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Artiste__3213E83FB64C43B9");

            entity.ToTable("Artiste");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.MetierId).HasColumnName("metier_id");
            entity.Property(e => e.Nom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("prenom");

            entity.HasOne(d => d.Metier).WithMany(p => p.Artistes)
                .HasForeignKey(d => d.MetierId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Artiste__metier___440B1D61");
        });

        modelBuilder.Entity<Casting>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Casting__3213E83F2519C28F");

            entity.ToTable("Casting");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.AdresseId).HasColumnName("adresse_id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.DiffuseurId).HasColumnName("diffuseur_id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("libelle");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.Adresse).WithMany(p => p.Castings)
                .HasForeignKey(d => d.AdresseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Casting__adresse__4AB81AF0");

            entity.HasOne(d => d.Diffuseur).WithMany(p => p.Castings)
                .HasForeignKey(d => d.DiffuseurId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Casting__diffuse__4BAC3F29");
        });

        modelBuilder.Entity<Contrat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contrat__3213E83FAF720625");

            entity.ToTable("Contrat");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DateDebut)
                .HasColumnType("date")
                .HasColumnName("date_debut");
            entity.Property(e => e.DateFin)
                .HasColumnType("date")
                .HasColumnName("date_fin");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Diffuseur>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Diffuseu__3213E83F9C2FE2CA");

            entity.ToTable("Diffuseur");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Metier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Metier__3213E83FA251D1C8");

            entity.ToTable("Metier");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("libelle");
        });

        modelBuilder.Entity<Partenaire>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partenai__3213E83F607DDF63");

            entity.ToTable("Partenaire");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Libelle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("libelle");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
