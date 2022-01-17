using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang.DAO
{
    class DAO_HoaDon
    {
        QuanLyBanHangEntities5 db;
        public DAO_HoaDon()
        {
            db = new QuanLyBanHangEntities5();
        }
        public dynamic DSHoaDon()
        {
            dynamic ds = db.HoaDons.Select(s => new
            {
                s.MaHD,
                s.NgayLapHD,
                s.NgayGiaoHang,
                s.KhachHang.TenKH,
                s.Nhanvien.Ten
            }).ToList();
            return ds;
        }
        public bool KTHD(int d)
        {
            HoaDon hoaDon = db.HoaDons.Find(d);
            if (hoaDon != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void SuaHD(HoaDon hd)
        {
            HoaDon hoaDon = db.HoaDons.Find(hd.MaHD);
            hoaDon.NgayLapHD = hd.NgayLapHD;
            hoaDon.MaKH = hd.MaKH;
            hoaDon.MaNV = hd.MaNV;

            db.SaveChanges();
        }
        public void XoaHD(int maHD)
        {
            HoaDon order = db.HoaDons.Find(maHD);
            db.HoaDons.Remove(order);

            db.SaveChanges();
        }
        public void ThemHD(HoaDon hd)
        {
            db.HoaDons.Add(hd);
            db.SaveChanges();
        }
    }
}