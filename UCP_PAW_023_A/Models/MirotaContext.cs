using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCP_PAW_023_A.Models
{
    public partial class MirotaContext : DbContext
    {
        public MirotaContext()
        {
        }

        public MirotaContext(DbContextOptions<MirotaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TableBarang> TableBarangs { get; set; }
        public virtual DbSet<TablePelanggan> TablePelanggans { get; set; }
        public virtual DbSet<TablePenjual> TablePenjuals { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TableBarang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Table_Barang");

                entity.Property(e => e.IdBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Barang");

                entity.Property(e => e.HargaBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Harga_Barang");

                entity.Property(e => e.NamaBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Barang");
            });

            modelBuilder.Entity<TablePelanggan>(entity =>
            {
                entity.HasKey(e => e.IdPelanggan);

                entity.ToTable("Table_Pelanggan");

                entity.Property(e => e.IdPelanggan)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pelanggan");

                entity.Property(e => e.NamaPelanggan)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Pelanggan");

                entity.Property(e => e.NoTelpon)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("No_Telpon");
            });

            modelBuilder.Entity<TablePenjual>(entity =>
            {
                entity.HasKey(e => e.IdPenjual);

                entity.ToTable("Table_Penjual");

                entity.Property(e => e.IdPenjual)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Penjual");

                entity.Property(e => e.NamaPenjual)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Penjual");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
