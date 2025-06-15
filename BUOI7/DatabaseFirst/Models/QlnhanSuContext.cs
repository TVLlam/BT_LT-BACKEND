using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Models;

public partial class QlnhanSuContext : DbContext
{
    public QlnhanSuContext()
    {
    }

    public QlnhanSuContext(DbContextOptions<QlnhanSuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-LU6935Q7\\TRANVANLAM;Database=QLNhanSu;Integrated security=true;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70A0B507B8C");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("MaNV");
            entity.Property(e => e.DiaChi).HasMaxLength(200);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaPhong)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaPhong)
                .HasConstraintName("FK__NhanVien__MaPhon__398D8EEE");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PK__PhongBan__20BD5E5B0E44ABD3");

            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPhong)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.DienThoai)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TenPhong).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
