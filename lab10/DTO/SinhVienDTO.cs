using System;

namespace Lab10_DisconnectedData.DTO
{
    public class SinhVienDTO
    {
        public string MaSV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public bool GioiTinh { get; set; }
        public string MaKhoa { get; set; }
        public decimal DiemTB { get; set; }
        public string Email { get; set; }

        public string GioiTinhStr => GioiTinh ? "Nam" : "Nữ";
    }
}
