using System;
using System.Collections.Generic;

namespace DatabaseFirst.Models;

public partial class PhongBan
{
    public string MaPhong { get; set; } = null!;

    public string TenPhong { get; set; } = null!;

    public string? DienThoai { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; set; } = new List<NhanVien>();
}
