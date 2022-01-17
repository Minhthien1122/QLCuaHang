using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang.DAO
{
    class DAO_NhanVien
    {
        QuanLyBanHangEntities5 db;
        public DAO_NhanVien()
        {
            db = new QuanLyBanHangEntities5();
        }

        public dynamic ListNhanVien()
        {
            dynamic ds = db.Nhanviens.Select(nv => new
            {
                nv.MaNV,
                nv.HoNV,
                nv.Ten,
                nv.Diachi,
                nv.Dienthoai
            }).ToList();
            return ds;
        }
        public void AddNhanVien(Nhanvien nhanvien)
        {
            db.Nhanviens.Add(nhanvien);
            db.SaveChanges();
        }
        public bool CheckNhanVien(int maNV)
        {
            Nhanvien nhanvien = db.Nhanviens.Find(maNV);
            if (nhanvien != null)
            {
                return true;
            }
            else
                return false;
        }
        public void DeleteNhanVien(int maNV)
        {
            Nhanvien nhanvien = db.Nhanviens.Find(maNV);
            db.Nhanviens.Remove(nhanvien);
            db.SaveChanges();
        }
        public void EditNhanVien(Nhanvien nv)
        {
            Nhanvien nhanvien = db.Nhanviens.Find(nv.MaNV);
            nhanvien.HoNV = nv.HoNV;
            nhanvien.Ten = nv.Ten;
            nhanvien.Diachi = nv.Diachi;
            nhanvien.Dienthoai = nv.Dienthoai;
            
            db.SaveChanges();
        }
    }
}
