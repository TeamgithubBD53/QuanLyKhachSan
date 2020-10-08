using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class nhanvienDTO
    {
        private int _maNhanVien;
        private string _hoTen;
        private bool _gioiTinh;
        private DateTime _ngaySinh;
        private string _soChungMinh;
        private string _diaChi;
        private string _soDienThoai;
        private DateTime _ngayVaoLam;

        public int MaNhanVien { get => _maNhanVien; set => _maNhanVien = value; }
        public string HoTen { get => _hoTen; set => _hoTen = value; }
        public bool GioiTinh { get => _gioiTinh; set => _gioiTinh = value; }
        public DateTime NgaySinh { get => _ngaySinh; set => _ngaySinh = value; }
        public string SoChungMinh { get => _soChungMinh; set => _soChungMinh = value; }
        public string DiaChi { get => _diaChi; set => _diaChi = value; }
        public string SoDienThoai { get => _soDienThoai; set => _soDienThoai = value; }
        public DateTime NgayVaoLam { get => _ngayVaoLam; set => _ngayVaoLam = value; }
    }
}
