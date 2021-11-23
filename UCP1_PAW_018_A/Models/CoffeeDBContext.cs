using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP1_PAW_018_A.Models
{
    public partial class CoffeeDBContext : DbContext
    {
        public CoffeeDBContext()
        {
        }

        public CoffeeDBContext(DbContextOptions<CoffeeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Kasir> Kasirs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.MejaCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Meja_Customer");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");
            });

            modelBuilder.Entity<Kasir>(entity =>
            {
                entity.HasKey(e => e.IdKasir);

                entity.ToTable("Kasir");

                entity.Property(e => e.IdKasir)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Kasir");

                entity.Property(e => e.PasswordKasir)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Password_Kasir");

                entity.Property(e => e.UsernameKasir)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Username_Kasir");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu);

                entity.ToTable("Menu");

                entity.Property(e => e.IdMenu)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Menu");

                entity.Property(e => e.HargaMenu).HasColumnName("Harga_Menu");

                entity.Property(e => e.JumlahMenu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Jumlah_Menu");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.IdKasir).HasColumnName("ID_Kasir");

                entity.Property(e => e.IdMenu).HasColumnName("ID_Menu");

                entity.Property(e => e.TotalTransaksi).HasColumnName("Total_Transaksi");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Transaksi_Customer1");

                entity.HasOne(d => d.IdKasirNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdKasir)
                    .HasConstraintName("FK_Transaksi_Kasir1");

                entity.HasOne(d => d.IdMenuNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdMenu)
                    .HasConstraintName("FK_Transaksi_Menu1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
