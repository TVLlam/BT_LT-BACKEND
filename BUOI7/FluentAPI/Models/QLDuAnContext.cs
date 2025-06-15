using Microsoft.EntityFrameworkCore;
namespace FluentAPI.Models
{
    public class QLDuAnContext: DbContext
    {

        public QLDuAnContext() { }
        public QLDuAnContext(DbContextOptions<QLDuAnContext> options) : base(options) { }
        //khai báo tập thực thể
        public DbSet<Nhanvien> Nhanviens { get; set; }
        public DbSet<Phongban> Phongbans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cấu hình thực thể PhongBan
            modelBuilder.Entity<Phongban>(e =>
            {
                e.ToTable("PhongBan"); // Tên bảng trong CSDL
                e.HasKey(e => e.MaPhong); // Khóa chính

                //Cấu hình thuộc tính MaPhong
                e.Property(e => e.MaPhong)
                    .HasColumnName("MaPhong") // Tên cột trong CSDL
                    .HasMaxLength(10) // Độ dài tối đa
                    .HasColumnType("varchar") // Kiểu dữ liệu
                    .IsRequired(); // Bắt buộc

                //Cấu hình thuộc tính TenPhong
                e.Property(e => e.TenPhong)
                    .HasColumnName("TenPhong") // Tên cột trong CSDL
                    .HasMaxLength(100) // Độ dài tối đa
                    .HasColumnType("nvarchar") // Kiểu dữ liệu
                    .IsRequired(); // Bắt buộc
            });

            //Cấu hình thực thể NhanVien
            modelBuilder.Entity<Nhanvien>(e =>
            {
                e.ToTable("NhanVien"); // Tên bảng trong CSDL
                e.HasKey(e => e.MaNV); // Khóa chính

                //Cấu hình thuộc tính MaNV
                e.Property(e => e.MaNV)
                    .HasColumnName("MaNV") // Tên cột trong CSDL
                    .HasMaxLength(10) // Độ dài tối đa
                    .HasColumnType("varchar") // Kiểu dữ liệu
                    .IsRequired(); // Bắt buộc
                //Cấu hình thuộc tính HoTen
                e.Property(e => e.HoTen)
                    .HasColumnName("HoTen") // Tên cột trong CSDL
                    .HasMaxLength(100) // Độ dài tối đa
                    .HasColumnType("nvarchar") // Kiểu dữ liệu
                    .IsRequired(); // Bắt buộc

                //Cấu hình thuộc tính MaPhong
                e.Property(e => e.MaPhong)
                    .HasColumnName("MaPhong") // Tên cột trong CSDL
                    .HasMaxLength(10) // Độ dài tối đa
                    .HasColumnType("varchar") // Kiểu dữ liệu
                    .IsRequired(); // Bắt buộc

                //Cấu hình quan hệ giữa phong ban và nhân viên
                e.HasOne(pb => pb.Phongban) // Điều hướng đến Phongban
                    .WithMany(nv => nv.Nhanviens) // Phongban có nhiều Nhanvien
                    .HasForeignKey(pb => pb.MaPhong) // Khóa ngoại
                    .HasConstraintName("FK_NhanVien_PhongBan"); // Tên ràng buộc khóa ngoại
            });
            base.OnModelCreating(modelBuilder);

        }
    }
   
}