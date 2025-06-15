namespace FluentAPI.Models
{
    public class Phongban
    {
        public string MaPhong { get; set; }
        public string TenPhong { get; set; }

        public ICollection<Nhanvien> Nhanviens { get; set; } // điều hướng đến Nhanvien
    }
}
