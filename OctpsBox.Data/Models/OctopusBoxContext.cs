using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OctpsBox.Data.Models
{
    public partial class OctopusBoxContext : DbContext
    {
        public  string connectionString;
        public OctopusBoxContext(string _connectionString)
        {
            connectionString = _connectionString;
        }

        public OctopusBoxContext(DbContextOptions<OctopusBoxContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Fonksiyon> Fonksiyon { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<KurumGrubu> KurumGrubu { get; set; }
        public virtual DbSet<Modul> Modul { get; set; }
        public virtual DbSet<OdemeKurumu> OdemeKurumu { get; set; }
        public virtual DbSet<OdemekurumuBaglanti> OdemekurumuBaglanti { get; set; }
        public virtual DbSet<OdemekurumuFonksiyon> OdemekurumuFonksiyon { get; set; }
        public virtual DbSet<Ortam> Ortam { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<SaglikKurumu> SaglikKurumu { get; set; }
        public virtual DbSet<SaglikkurumuOdemekurumuFonks> SaglikkurumuOdemekurumuFonks { get; set; }
        public virtual DbSet<SaglikkurumuOdemekurumuOzelBaglanti> SaglikkurumuOdemekurumuOzelBaglanti { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fonksiyon>(entity =>
            {
                entity.ToTable("fonksiyon", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .HasColumnName("adi")
                    .HasColumnType("character varying");

                entity.Property(e => e.ModulId).HasColumnName("modul_id");

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.Fonksiyon)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("fonksiyon_fk");
            });

            modelBuilder.Entity<Kullanici>(entity =>
            {
                entity.HasKey(e => e.KullaniciAdi)
                    .HasName("kullanici_pk");

                entity.ToTable("kullanici", "OctopusBox_v1");

                entity.Property(e => e.KullaniciAdi)
                    .HasColumnName("kullanici_adi")
                    .HasColumnType("character varying");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RolId).HasColumnName("rol_id");

                entity.Property(e => e.Sifre)
                    .HasColumnName("sifre")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Kullanici)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("kullanici_fk");
            });

            modelBuilder.Entity<KurumGrubu>(entity =>
            {
                entity.ToTable("kurum_grubu", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasColumnName("adi")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Modul>(entity =>
            {
                entity.ToTable("modul", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .HasColumnName("adi")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<OdemeKurumu>(entity =>
            {
                entity.ToTable("odeme_kurumu", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .HasColumnName("adi")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<OdemekurumuBaglanti>(entity =>
            {
                entity.ToTable("odemekurumu_baglanti", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaglantiAdresi)
                    .HasColumnName("baglanti_adresi")
                    .HasColumnType("character varying");

                entity.Property(e => e.ModulId).HasColumnName("modul_id");

                entity.Property(e => e.OdemeKurumuId).HasColumnName("odeme_kurumu_id");

                entity.Property(e => e.OrtamId).HasColumnName("ortam_id");

                entity.HasOne(d => d.Modul)
                    .WithMany(p => p.OdemekurumuBaglanti)
                    .HasForeignKey(d => d.ModulId)
                    .HasConstraintName("baglanti_fk");

                entity.HasOne(d => d.Ortam)
                    .WithMany(p => p.OdemekurumuBaglanti)
                    .HasForeignKey(d => d.OrtamId)
                    .HasConstraintName("ortam_fk");
            });

            modelBuilder.Entity<OdemekurumuFonksiyon>(entity =>
            {
                entity.ToTable("odemekurumu_fonksiyon", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FonksiyonId).HasColumnName("fonksiyon_id");

                entity.Property(e => e.OdemeKurumuId).HasColumnName("odeme_kurumu_id");

                entity.HasOne(d => d.Fonksiyon)
                    .WithMany(p => p.OdemekurumuFonksiyon)
                    .HasForeignKey(d => d.FonksiyonId)
                    .HasConstraintName("fonksiyon_fk");

                entity.HasOne(d => d.OdemeKurumu)
                    .WithMany(p => p.OdemekurumuFonksiyon)
                    .HasForeignKey(d => d.OdemeKurumuId)
                    .HasConstraintName("odemekurumu_fk");
            });

            modelBuilder.Entity<Ortam>(entity =>
            {
                entity.ToTable("ortam", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .HasColumnName("adi")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.ToTable("rol", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .HasColumnName("adi")
                    .HasColumnType("character varying");
            });

            modelBuilder.Entity<SaglikKurumu>(entity =>
            {
                entity.ToTable("saglik_kurumu", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Adi)
                    .HasColumnName("adi")
                    .HasColumnType("character varying");

                entity.Property(e => e.CgmSifre)
                    .HasColumnName("cgm_sifre")
                    .HasColumnType("character varying");

                entity.Property(e => e.KurumGrubuId).HasColumnName("kurum_grubu_id");

                entity.HasOne(d => d.KurumGrubu)
                    .WithMany(p => p.SaglikKurumu)
                    .HasForeignKey(d => d.KurumGrubuId)
                    .HasConstraintName("kurum_grubu_fk");
            });

            modelBuilder.Entity<SaglikkurumuOdemekurumuFonks>(entity =>
            {
                entity.ToTable("saglikkurumu_odemekurumu_fonks", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FonksiyonId).HasColumnName("fonksiyon_id");

                entity.Property(e => e.OdemeKurumuId).HasColumnName("odeme_kurumu_id");

                entity.Property(e => e.SaglikKurumuId).HasColumnName("saglik_kurumu_id");

                entity.HasOne(d => d.Fonksiyon)
                    .WithMany(p => p.SaglikkurumuOdemekurumuFonks)
                    .HasForeignKey(d => d.FonksiyonId)
                    .HasConstraintName("fonks_fk");

                entity.HasOne(d => d.OdemeKurumu)
                    .WithMany(p => p.SaglikkurumuOdemekurumuFonks)
                    .HasForeignKey(d => d.OdemeKurumuId)
                    .HasConstraintName("odemekurumu_fk");

                entity.HasOne(d => d.SaglikKurumu)
                    .WithMany(p => p.SaglikkurumuOdemekurumuFonks)
                    .HasForeignKey(d => d.SaglikKurumuId)
                    .HasConstraintName("saglikkurumu_fk");
            });

            modelBuilder.Entity<SaglikkurumuOdemekurumuOzelBaglanti>(entity =>
            {
                entity.ToTable("saglikkurumu_odemekurumu_ozel_baglanti", "OctopusBox_v1");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.OdemekurumuBaglantiId).HasColumnName("odemekurumu_baglanti_id");

                entity.Property(e => e.SaglikKurumuId).HasColumnName("saglik_kurumu_id");

                entity.Property(e => e.SaglikKurumuKodu)
                    .HasColumnName("saglik_kurumu_kodu")
                    .HasColumnType("character varying");

                entity.Property(e => e.SaglikKurumuSifre)
                    .HasColumnName("saglik_kurumu_sifre")
                    .HasColumnType("character varying");

                entity.HasOne(d => d.OdemekurumuBaglanti)
                    .WithMany(p => p.SaglikkurumuOdemekurumuOzelBaglanti)
                    .HasForeignKey(d => d.OdemekurumuBaglantiId)
                    .HasConstraintName("odemekurumu_baglanti_fk");

                entity.HasOne(d => d.SaglikKurumu)
                    .WithMany(p => p.SaglikkurumuOdemekurumuOzelBaglanti)
                    .HasForeignKey(d => d.SaglikKurumuId)
                    .HasConstraintName("saglikkurumu_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
