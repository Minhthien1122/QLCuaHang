using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang.DAO
{
    class DAO_SanPham
    {
        QuanLyBanHangEntities5 db;
        public DAO_SanPham()
        {
            db = new QuanLyBanHangEntities5();
        }

        //Lấy DS SP
        public dynamic ListSanPham()
        {
            var ds = db.SanPhams.Select(s => new
            {
                s.MaSP,
                s.TenSP,
                s.LoaiSP.TenLoaiSP,
                s.SoLuong,
                s.Dongia,
            }).ToList();
            return ds;
        }
        public SanPham LaySP(int maSP)
        {
            SanPham p = db.SanPhams.Where(s => s.MaSP == maSP).FirstOrDefault();
            return p;
        }
        public dynamic LayDSLoaiSP()
        {
            var ds = db.LoaiSPs.Select(s => new
            {
                s.MaLoaiSP,
                s.TenLoaiSP
            }).ToList();
            return ds;
        }

        public bool CheckSanPham(int maSP)
        {
            SanPham sp = db.SanPhams.Find(maSP);
            if (sp != null)
            {
                return true;
            }
            else
                return false;
        }

        public void AddSanPham(SanPham sp)
        {
            db.SanPhams.Add(sp);
            db.SaveChanges();
        }

        public void EditSanPham(SanPham sp)
        {
            SanPham sanpham = db.SanPhams.Find(sp.MaSP);
            sanpham.TenSP = sp.TenSP;
            sanpham.MaSP = sp.MaSP;
            sanpham.SoLuong = sp.SoLuong;
            sanpham.Dongia = sp.Dongia;
            db.SaveChanges();
        }

        public void DeleteSanPham(int maSP)
        {
            SanPham sanpham = db.SanPhams.Find(maSP);
            db.SanPhams.Remove(sanpham);
            db.SaveChanges();
        }
    }
}
