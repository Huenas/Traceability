using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Fr.Emmanuel.Tracability.Domain.Model;

#nullable disable

namespace Fr.Emmanuel.Tracability.Entity
{
    public partial class TracabilityDbContext : DbContext
    {
        public TracabilityDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Affaire> Affaires { get; set; }
        public virtual DbSet<AssocEqCont> AssocEqConts { get; set; }
        public virtual DbSet<Controleur> Controleurs { get; set; }
        public virtual DbSet<Equipement> Equipements { get; set; }
        public virtual DbSet<Parametrage> Parametrages { get; set; }
        public virtual DbSet<RetourControleur> RetourControleurs { get; set; }
        public virtual DbSet<RetourEquipement> RetourEquipements { get; set; }
        public virtual DbSet<TypeControleur> TypeControleurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "French_CI_AS");

            modelBuilder.Entity<Affaire>(entity =>
            {
                entity.HasKey(e => e.IdAffaire);

                entity.ToTable("Affaire");

                entity.Property(e => e.NumeroAffaire)
                    .HasMaxLength(10)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<AssocEqCont>(entity =>
            {
                entity.HasKey(e => e.IdAssocEqCont);

                entity.ToTable("AssocEqCont");

                entity.HasOne(d => d.IdControleurNavigation)
                    .WithMany(p => p.AssocEqConts)
                    .HasForeignKey(d => d.IdControleur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssocEqCont_Controleur");

                entity.HasOne(d => d.IdEquipementNavigation)
                    .WithMany(p => p.AssocEqConts)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AssocEqCont_Equipement");
            });

            modelBuilder.Entity<Controleur>(entity =>
            {
                entity.HasKey(e => e.IdControleur);

                entity.ToTable("Controleur");

                entity.Property(e => e.AdresseDansArmoire)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.LotProd)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Serial)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdTypeControleurNavigation)
                    .WithMany(p => p.Controleurs)
                    .HasForeignKey(d => d.IdTypeControleur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Controleur_TypeControleur");
            });

            modelBuilder.Entity<Equipement>(entity =>
            {
                entity.HasKey(e => e.IdEquipement);

                entity.ToTable("Equipement");

                entity.Property(e => e.NomEquipement)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAffaireNavigation)
                    .WithMany(p => p.Equipements)
                    .HasForeignKey(d => d.IdAffaire)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Equipement_Affaire");
            });

            modelBuilder.Entity<Parametrage>(entity =>
            {
                entity.HasKey(e => e.IdParametrage);

                entity.ToTable("Parametrage");

                entity.Property(e => e.Fichier).HasColumnType("xml");

                entity.Property(e => e.Version).HasColumnType("xml");

                entity.HasOne(d => d.IdControleurNavigation)
                    .WithMany(p => p.Parametrages)
                    .HasForeignKey(d => d.IdControleur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Parametrage_Controleur");
            });

            modelBuilder.Entity<RetourControleur>(entity =>
            {
                entity.HasKey(e => e.IdRetourControleur);

                entity.ToTable("RetourControleur");

                entity.Property(e => e.LibelleRetour)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdControleurNavigation)
                    .WithMany(p => p.RetourControleurs)
                    .HasForeignKey(d => d.IdControleur)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RetourControleur_Controleur");
            });

            modelBuilder.Entity<RetourEquipement>(entity =>
            {
                entity.HasKey(e => e.IdRetourEquipement);

                entity.ToTable("RetourEquipement");

                entity.Property(e => e.LibelleRetour)
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdEquipementNavigation)
                    .WithMany(p => p.RetourEquipements)
                    .HasForeignKey(d => d.IdEquipement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RetourEquipement_Equipement");
            });

            modelBuilder.Entity<TypeControleur>(entity =>
            {
                entity.HasKey(e => e.IdTypeControleur);

                entity.ToTable("TypeControleur");

                entity.Property(e => e.LibelleType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
