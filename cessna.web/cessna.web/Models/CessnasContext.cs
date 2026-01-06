using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cessna.web.Models;

public partial class CessnasContext : DbContext
{
    public CessnasContext()
    {
    }

    public CessnasContext(DbContextOptions<CessnasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Havalimani> Havalimanis { get; set; }

    public virtual DbSet<HazirlikKontrol> HazirlikKontrols { get; set; }

    public virtual DbSet<Hoste> Hostes { get; set; }

    public virtual DbSet<Koltuk> Koltuks { get; set; }

    public virtual DbSet<Pilot> Pilots { get; set; }

    public virtual DbSet<Rezervasyon> Rezervasyons { get; set; }

    public virtual DbSet<Teknisyen> Teknisyens { get; set; }

    public virtual DbSet<Ucak> Ucaks { get; set; }

    public virtual DbSet<Ucu> Ucus { get; set; }

    public virtual DbSet<VW_EkipAtamalari> VW_EkipAtamalaris { get; set; }

    public virtual DbSet<VW_KoltukHaritasi> VW_KoltukHaritasis { get; set; }

    public virtual DbSet<VW_UcusGenelBaki> VW_UcusGenelBakis { get; set; }

    public virtual DbSet<VW_YakitRaporu> VW_YakitRaporus { get; set; }

    public virtual DbSet<VW_YolcuRezervasyonlari> VW_YolcuRezervasyonlaris { get; set; }

    public virtual DbSet<Yakit> Yakits { get; set; }

    public virtual DbSet<Yolcu> Yolcus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Havalimani>(entity =>
        {
            entity.HasKey(e => e.HavalimaniKod).HasName("PK__Havalima__9C335252ACA2F4D8");

            entity.ToTable("Havalimani");

            entity.HasIndex(e => e.IATAKodu, "UQ__Havalima__791A0D38105A2AF4").IsUnique();

            entity.Property(e => e.Ad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.IATAKodu)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Sehir)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Ulke)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HazirlikKontrol>(entity =>
        {
            entity.HasKey(e => new { e.TeknisyenKod, e.UcakKod, e.UcusKod });

            entity.ToTable("HazirlikKontrol");

            entity.Property(e => e.Notlar)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.TeknisyenKodNavigation).WithMany(p => p.HazirlikKontrols)
                .HasForeignKey(d => d.TeknisyenKod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HK_Teknisyen");

            entity.HasOne(d => d.UcakKodNavigation).WithMany(p => p.HazirlikKontrols)
                .HasForeignKey(d => d.UcakKod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HK_Ucak");

            entity.HasOne(d => d.UcusKodNavigation).WithMany(p => p.HazirlikKontrols)
                .HasForeignKey(d => d.UcusKod)
                .HasConstraintName("FK_HK_Ucus");
        });

        modelBuilder.Entity<Hoste>(entity =>
        {
            entity.HasKey(e => e.HostesKod).HasName("PK__Hostes__3B7F1B76DBD52AA5");

            entity.Property(e => e.AdSoyad)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Vardiya)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Koltuk>(entity =>
        {
            entity.HasKey(e => new { e.UcakKod, e.KoltukNo });

            entity.ToTable("Koltuk");

            entity.HasIndex(e => e.KoltukTipi, "IX_Koltuk_KoltukTipi");

            entity.Property(e => e.KoltukNo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.KoltukTipi)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.UcakKodNavigation).WithMany(p => p.Koltuks)
                .HasForeignKey(d => d.UcakKod)
                .HasConstraintName("FK_Koltuk_Ucak");
        });

        modelBuilder.Entity<Pilot>(entity =>
        {
            entity.HasKey(e => e.PilotKod).HasName("PK__Pilot__05697484B42897A2");

            entity.ToTable("Pilot");

            entity.HasIndex(e => e.LisansNo, "UQ__Pilot__8143902EFB7C07DE").IsUnique();

            entity.Property(e => e.AdSoyad)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.LisansNo)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Rezervasyon>(entity =>
        {
            entity.HasKey(e => e.RezervasyonKod).HasName("PK__Rezervas__F3664116CF5AE313");

            entity.ToTable("Rezervasyon");

            entity.HasIndex(e => e.UcusKod, "IX_Rezervasyon_UcusKod");

            entity.HasIndex(e => e.YolcuKod, "IX_Rezervasyon_YolcuKod");

            entity.Property(e => e.KoltukNo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.OdemeDurumu)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Sinif)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.UcusKodNavigation).WithMany(p => p.Rezervasyons)
                .HasForeignKey(d => d.UcusKod)
                .HasConstraintName("FK_Rezervasyon_Ucus");

            entity.HasOne(d => d.YolcuKodNavigation).WithMany(p => p.Rezervasyons)
                .HasForeignKey(d => d.YolcuKod)
                .HasConstraintName("FK_Rezervasyon_Yolcu");
        });

        modelBuilder.Entity<Teknisyen>(entity =>
        {
            entity.HasKey(e => e.TeknisyenKod).HasName("PK__Teknisye__D793761282097717");

            entity.ToTable("Teknisyen");

            entity.HasIndex(e => e.Eposta, "UQ__Teknisye__03ABA391FAFCD62B").IsUnique();

            entity.Property(e => e.AdSoyad)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Eposta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gorev)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Vardiya)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ucak>(entity =>
        {
            entity.HasKey(e => e.UcakKod).HasName("PK__Ucak__A5F5137E90BAEFF2");

            entity.ToTable("Ucak");

            entity.HasIndex(e => e.KuyrukNo, "UQ__Ucak__B197A57280302B8E").IsUnique();

            entity.Property(e => e.KuyrukNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Uretici)
                .HasMaxLength(30)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ucu>(entity =>
        {
            entity.HasKey(e => e.UcusKod).HasName("PK__Ucus__D597C83DA7DB6030");

            entity.HasIndex(e => e.UcusNo, "IX_Ucus_UcusNo");

            entity.HasIndex(e => e.UcusNo, "UQ__Ucus__A048EFE928BA63B5").IsUnique();

            entity.Property(e => e.Durum)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.UcusNo)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.KalkisHavalimaniKodNavigation).WithMany(p => p.UcuKalkisHavalimaniKodNavigations)
                .HasForeignKey(d => d.KalkisHavalimaniKod)
                .HasConstraintName("FK_Ucus_KalkisHavalimani");

            entity.HasOne(d => d.PilotKodNavigation).WithMany(p => p.Ucus)
                .HasForeignKey(d => d.PilotKod)
                .HasConstraintName("FK_Ucus_Pilot");

            entity.HasOne(d => d.UcakKodNavigation).WithMany(p => p.Ucus)
                .HasForeignKey(d => d.UcakKod)
                .HasConstraintName("FK_Ucus_Ucak");

            entity.HasOne(d => d.VarisHavalimaniKodNavigation).WithMany(p => p.UcuVarisHavalimaniKodNavigations)
                .HasForeignKey(d => d.VarisHavalimaniKod)
                .HasConstraintName("FK_Ucus_VarisHavalimani");

            entity.HasMany(d => d.HostesKods).WithMany(p => p.UcusKods)
                .UsingEntity<Dictionary<string, object>>(
                    "UcusHoste",
                    r => r.HasOne<Hoste>().WithMany()
                        .HasForeignKey("HostesKod")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UcusHostes_Hostes"),
                    l => l.HasOne<Ucu>().WithMany()
                        .HasForeignKey("UcusKod")
                        .HasConstraintName("FK_UcusHostes_Ucus"),
                    j =>
                    {
                        j.HasKey("UcusKod", "HostesKod");
                        j.ToTable("UcusHostes");
                    });
        });

        modelBuilder.Entity<VW_EkipAtamalari>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_EkipAtamalari");

            entity.Property(e => e.HostesAdi)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.PilotAdi)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.UcusNo)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_KoltukHaritasi>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_KoltukHaritasi");

            entity.Property(e => e.KoltukNo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.KoltukTipi)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.KuyrukNo)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_UcusGenelBaki>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_UcusGenelBakis");

            entity.Property(e => e.Durum)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.KalkisHavalimani)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.PilotAdi)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.UcakKuyrukNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UcakModel)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.UcusNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.VarisHavalimani)
                .HasMaxLength(3)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_YakitRaporu>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_YakitRaporu");

            entity.Property(e => e.UcusNo)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VW_YolcuRezervasyonlari>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("VW_YolcuRezervasyonlari");

            entity.Property(e => e.KoltukNo)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.OdemeDurumu)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Sinif)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.UcusNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.YolcuAdi)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Yakit>(entity =>
        {
            entity.HasKey(e => e.YakitKod).HasName("PK__Yakit__8908E012087196FA");

            entity.ToTable("Yakit");

            entity.HasIndex(e => e.UcusKod, "IX_Yakit_UcusKod");

            entity.Property(e => e.ToplamTutar).HasComputedColumnSql("(isnull([MiktarLitre],(0))*isnull([BirimFiyat],(0)))", true);

            entity.HasOne(d => d.TeknisyenKodNavigation).WithMany(p => p.Yakits)
                .HasForeignKey(d => d.TeknisyenKod)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Yakit_Teknisyen");

            entity.HasOne(d => d.UcusKodNavigation).WithMany(p => p.Yakits)
                .HasForeignKey(d => d.UcusKod)
                .HasConstraintName("FK_Yakit_Ucus");
        });

        modelBuilder.Entity<Yolcu>(entity =>
        {
            entity.HasKey(e => e.YolcuKod).HasName("PK__Yolcu__819F961E3B5ABD2B");

            entity.ToTable("Yolcu");

            entity.HasIndex(e => e.PasaportNo, "IX_Yolcu_PasaportNo");

            entity.HasIndex(e => e.PasaportNo, "UQ__Yolcu__61A898A8BDC4E271").IsUnique();

            entity.Property(e => e.AdSoyad)
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Cinsiyet)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Eposta)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PasaportNo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Telefon)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
