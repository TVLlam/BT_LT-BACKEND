namespace FluentAPI.Models
{
    public class Nhanvien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string MaPhong { get; set; }
        public Phongban Phongban { get; set; } // điều hướng đến Phongban
    }
}
