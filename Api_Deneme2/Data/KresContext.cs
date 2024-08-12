using System;
using System.Collections.Generic;
using Api_Deneme2.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Deneme2.Data;

public partial class KresContext : DbContext
{
    public KresContext()
    {
    }

    public KresContext(DbContextOptions<KresContext> options): base(options)
    {
    }

    public  DbSet<Kresler> Kreslers { get; set; }

    public  DbSet<OgrenciBİlgİ> OgrenciBİlgİs { get; set; }

    public  DbSet<Personel> Personels { get; set; }

    public  DbSet<Sinif> Sinifs { get; set; }

    public DbSet<Yetki> Yetkis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-3H9G77VD\\SQLEXPRESS;Database=Kres;TrustServerCertificate=True;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kresler>(entity =>
        {
            entity.HasKey(e => e.KresId).HasName("PK__KRESLER__42FEDC55487AAC69");

            entity.ToTable("KRESLER");

            entity.Property(e => e.KresId)
                .ValueGeneratedNever()
                .HasColumnName("Kres_Id");
            entity.Property(e => e.Aktif).HasDefaultValue(true);
            entity.Property(e => e.KresAd)
                .IsUnicode(false)
                .HasColumnName("Kres_Ad");
            entity.Property(e => e.KresAdres)
                .IsUnicode(false)
                .HasColumnName("Kres_Adres");
            entity.Property(e => e.KresKontenjan).HasColumnName("Kres_Kontenjan");
            entity.Property(e => e.Kresİletisim)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("Kres_İletisim");
        });

        modelBuilder.Entity<OgrenciBİlgİ>(entity =>
        {
            entity.HasKey(e => e.OgrenciId).HasName("PK__OGRENCI___F671B41BB9AB2453");

            entity.ToTable("OGRENCI_BİLGİ");

            entity.Property(e => e.OgrenciId)
                .ValueGeneratedNever()
                .HasColumnName("Ogrenci_Id");
            entity.Property(e => e.Aktif).HasDefaultValue(true);
            entity.Property(e => e.KresId).HasColumnName("Kres_Id");
            entity.Property(e => e.OgrenciAd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ogrenci_Ad");
            entity.Property(e => e.OgrenciCinsiyet)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ogrenci_Cinsiyet");
            entity.Property(e => e.OgrenciSoyad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ogrenci_Soyad");
            entity.Property(e => e.OgrenciSınıfId).HasColumnName("Ogrenci_Sınıf_Id");
            entity.Property(e => e.OgrenciYas)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Ogrenci_Yas");
            entity.Property(e => e.OrenciAdres)
                .IsUnicode(false)
                .HasColumnName("Orenci_Adres");
            entity.Property(e => e.VeliAdı)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Veli_Adı");
            entity.Property(e => e.VeliIletisim)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Veli_Iletisim");

            entity.HasOne(d => d.Kres).WithMany(p => p.OgrenciBİlgİs)
                .HasForeignKey(d => d.KresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OGRENCI_BİLGİ_KRESLER");

            entity.HasOne(d => d.OgrenciSınıf).WithMany(p => p.OgrenciBİlgİs)
                .HasForeignKey(d => d.OgrenciSınıfId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OGRENCI_BİLGİ_SINIF");
        });

        modelBuilder.Entity<Personel>(entity =>
        {
            entity.HasKey(e => e.PersonelId).HasName("PK__PERSONEL__F7A705CD9329777A");

            entity.ToTable("PERSONEL");

            entity.Property(e => e.PersonelId)
                .ValueGeneratedNever()
                .HasColumnName("Personel_Id");
            entity.Property(e => e.Aktif).HasDefaultValue(true);
            entity.Property(e => e.KresId).HasColumnName("Kres_Id");
            entity.Property(e => e.PersonelAd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Personel_Ad");
            entity.Property(e => e.PersonelAdres)
                .IsUnicode(false)
                .HasColumnName("Personel_Adres");
            entity.Property(e => e.PersonelEMail)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Personel_eMail");
            entity.Property(e => e.PersonelIletisim)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Personel_Iletisim");
            entity.Property(e => e.PersonelSoyad)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Personel_Soyad");
            entity.Property(e => e.PersonelYetki)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Personel_Yetki");

            entity.HasOne(d => d.Kres).WithMany(p => p.Personels)
                .HasForeignKey(d => d.KresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PERSONEL_KRESLER");
        });

        modelBuilder.Entity<Sinif>(entity =>
        {
            entity.HasKey(e => e.SınıfId).HasName("PK__SINIF__EBCE9A72AAE72AAF");

            entity.ToTable("SINIF");

            entity.Property(e => e.SınıfId)
                .ValueGeneratedNever()
                .HasColumnName("Sınıf_Id");
            entity.Property(e => e.Aktif).HasDefaultValue(true);
            entity.Property(e => e.KresId).HasColumnName("Kres_Id");
            entity.Property(e => e.PersonelId).HasColumnName("Personel_Id");
            entity.Property(e => e.SınıfAd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Sınıf_Ad");
            entity.Property(e => e.SınıfKontenjan).HasColumnName("Sınıf_Kontenjan");

            entity.HasOne(d => d.Kres).WithMany(p => p.Sinifs)
                .HasForeignKey(d => d.KresId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SINIF_KRESLER");

            entity.HasOne(d => d.Personel).WithMany(p => p.Sinifs)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SINIF_PERSONEL");
        });

        modelBuilder.Entity<Yetki>(entity =>
        {
            entity.HasKey(e => e.YetkiId).HasName("PK__YETKI__7A18CC147BDD010A");

            entity.ToTable("YETKI");

            entity.Property(e => e.YetkiId)
                .ValueGeneratedNever()
                .HasColumnName("Yetki_Id");
            entity.Property(e => e.Aktif).HasDefaultValue(true);
            entity.Property(e => e.KresId).HasColumnName("Kres_Id");
            entity.Property(e => e.YetkiTuru)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Yetki_turu");
            entity.Property(e => e.YetkiliAd)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Yetkili_ad");
            entity.Property(e => e.YetkiliAdres)
                .IsUnicode(false)
                .HasColumnName("Yetkili_Adres");
            entity.Property(e => e.YetkiliEMail)
                .IsUnicode(false)
                .HasColumnName("Yetkili_eMail");
            entity.Property(e => e.YetkiliIletisim)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Yetkili_Iletisim");
            entity.Property(e => e.YetkiliSifre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Yetkili_Sifre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
