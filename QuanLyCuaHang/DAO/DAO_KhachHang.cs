using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang.DAO
{
    class DAO_KhachHang
    {
        QuanLyBanHangEntities5 db;
        public DAO_KhachHang()
        {
            db = new QuanLyBanHangEntities5();
        }

        public dynamic ListKhachHang()
        {
            dynamic ds = db.KhachHangs.Select(kh => new
            {
                kh.MaKH,
                kh.TenKH,
                kh.DiaChi,
                kh.DienThoai,
                kh.Email,
                kh.Fax
            }).ToList();
            return ds;
        }
        public void AddKhachHang(KhachHang kh)
        {
            db.KhachHangs.Add(kh);
            db.SaveChanges();
        }
        public bool CheckKhachHang(int maKH)
        {
            KhachHang khachhang = db.KhachHangs.Find(maKH);
            if (khachhang != null)
            {
                return true;
            }
            else
                return false;
        }
        public void DeleteKhachHang(int maKH)
        {
            KhachHang khachhang = db.KhachHangs.Find(maKH);
            db.KhachHangs.Remove(khachhang);
            db.SaveChanges();
        }
        public void EditKhachHang(KhachHang kh)
        {
            KhachHang khachhang = db.KhachHangs.Find(kh.MaKH);
            khachhang.TenKH = kh.TenKH;
            khachhang.Email = kh.Email;
            khachhang.DiaChi = kh.DiaChi;
            khachhang.DienThoai = kh.DienThoai;
            khachhang.Fax = kh.Fax;

            db.SaveChanges();
        }
    }
}
