using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Perpustakaan.Models
{
    public partial class db_perpusContext : DbContext
    {
        public db_perpusContext()
        {
        }

        public db_perpusContext(DbContextOptions<db_perpusContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Buku> Bukus { get; set; }
        public virtual DbSet<Kategori> Kategoris { get; set; }
        public virtual DbSet<Notum> Nota { get; set; }
        public virtual DbSet<Peminjam> Peminjams { get; set; }
        public virtual DbSet<Pinjaman> Pinjamen { get; set; }

       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__admin__89472E95BB66941C");

                entity.ToTable("admin");

                entity.HasIndex(e => e.Username, "UQ__admin__F3DBC572C2646A35")
                    .IsUnique();

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.Jabatan)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("jabatan");

                entity.Property(e => e.NamaAdmin)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nama_admin");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Buku>(entity =>
            {
                entity.HasKey(e => e.IdBuku)
                    .HasName("PK__buku__C0585A56E47D5F57");

                entity.ToTable("buku");

                entity.Property(e => e.IdBuku).HasColumnName("id_buku");

                entity.Property(e => e.Deskripsi)
                    .HasColumnType("text")
                    .HasColumnName("deskripsi");

                entity.Property(e => e.GambarBuku)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("gambar_buku");

                entity.Property(e => e.Harga)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("harga");

                entity.Property(e => e.IdKategori).HasColumnName("id_kategori");

                entity.Property(e => e.JudulBuku)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("judul_buku");

                entity.HasOne(d => d.IdKategoriNavigation)
                    .WithMany(p => p.Bukus)
                    .HasForeignKey(d => d.IdKategori)
                    .HasConstraintName("FK__buku__id_kategor__2C3393D0");
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.HasKey(e => e.IdKategori)
                    .HasName("PK__kategori__749DC5C87A61CE0A");

                entity.ToTable("kategori");

                entity.Property(e => e.IdKategori).HasColumnName("id_kategori");

                entity.Property(e => e.NamaKategori)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nama_kategori");
            });

            modelBuilder.Entity<Notum>(entity =>
            {
                entity.HasKey(e => e.IdNota)
                    .HasName("PK__nota__26991D8CE3372885");

                entity.ToTable("nota");

                entity.Property(e => e.IdNota).HasColumnName("id_nota");

                entity.Property(e => e.Denda).HasColumnName("denda");

                entity.Property(e => e.IdAdmin).HasColumnName("id_admin");

                entity.Property(e => e.IdPeminjam).HasColumnName("id_peminjam");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.TglDeadline)
                    .HasColumnType("date")
                    .HasColumnName("tgl_deadline");

                entity.Property(e => e.TglKembali)
                    .HasColumnType("date")
                    .HasColumnName("tgl_kembali");

                entity.Property(e => e.TglPinjam)
                    .HasColumnType("date")
                    .HasColumnName("tgl_pinjam");

                entity.HasOne(d => d.IdAdminNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdAdmin)
                    .HasConstraintName("FK__nota__id_admin__300424B4");

                entity.HasOne(d => d.IdPeminjamNavigation)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.IdPeminjam)
                    .HasConstraintName("FK__nota__id_peminja__2F10007B");
            });

            modelBuilder.Entity<Peminjam>(entity =>
            {
                entity.HasKey(e => e.IdPeminjam)
                    .HasName("PK__peminjam__120EA83A7A111964");

                entity.ToTable("peminjam");

                entity.HasIndex(e => e.Username, "UQ__peminjam__F3DBC572FC685800")
                    .IsUnique();

                entity.Property(e => e.IdPeminjam).HasColumnName("id_peminjam");

                entity.Property(e => e.Alamat)
                    .HasColumnType("text")
                    .HasColumnName("alamat");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.Nama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nama");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Pinjaman>(entity =>
            {
                entity.HasKey(e => e.IdPinjaman)
                    .HasName("PK__pinjaman__74998D824463F24A");

                entity.ToTable("pinjaman");

                entity.Property(e => e.IdPinjaman).HasColumnName("id_pinjaman");

                entity.Property(e => e.IdBuku).HasColumnName("id_buku");

                entity.Property(e => e.IdNota).HasColumnName("id_nota");

                entity.Property(e => e.Jumlah).HasColumnName("jumlah");

                entity.HasOne(d => d.IdBukuNavigation)
                    .WithMany(p => p.Pinjamen)
                    .HasForeignKey(d => d.IdBuku)
                    .HasConstraintName("FK_pinjaman_buku");

                entity.HasOne(d => d.IdNotaNavigation)
                    .WithMany(p => p.Pinjamen)
                    .HasForeignKey(d => d.IdNota)
                    .HasConstraintName("FK__pinjaman__id_not__32E0915F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
