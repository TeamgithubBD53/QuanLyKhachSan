using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;

namespace BLL
{
   public class phongBLL
    {
        phongDAL Stclr = new phongDAL();
        public DataTable hienthithongtinphong()
        {
            return Stclr.hienthithongtinphong();
        }
         public bool them_phong(int maPhong, bool tinhTrang, string loaiPhong, int donGia)
        {
            return Stclr.them_phong(maPhong,tinhTrang, loaiPhong, donGia);
        }
        public void xoa_phong(int maPhong)
        {
            Stclr.xoa_phong(maPhong);

        }

        public void sua_phong(int maPhong, bool tinhTrang, string loaiPhong, int donGia)
        {

            Stclr.sua_phong(maPhong,tinhTrang,loaiPhong,donGia);
        }
    }
}
