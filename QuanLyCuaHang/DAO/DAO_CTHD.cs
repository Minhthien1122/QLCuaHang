using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang.DAO
{
    class DAO_CTHD
    {
        QuanLyBanHangEntities5 db;
        public DAO_CTHD()
        {
            db = new QuanLyBanHangEntities5();
        }
        public dynamic LayDSCTHD(int maHD)
        {
            dynamic ds = db.CTHDs.Where(s => s.MaHD == maHD)
                    .Select(s => new {
                        s.MaHD,
                        s.SanPham.TenSP,
                        s.DongiaBan,
                        s.Soluong
                    }).ToList();
            return ds;
        }
        public bool KiemTraSPDH(CTHD d)
        {
            //kt sp cos trong don hang ch
            bool kq = false;
            int? sl = -1;
            sl = db.sp_KTSPDonHang(d.MaHD, d.MaSP).FirstOrDefault();
            if (sl == 0)
            {
                kq = true;
            }
            return kq;
        }
        public void ThemCTDH(CTHD d)
        {
            db.CTHDs.Add(d);
            db.SaveChanges();
        }
        public bool KTCTHD(CTHD d)
        {
            CTHD c = db.CTHDs.Find(d.MaHD, d.MaSP);
            if (c != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SuaCTHD(CTHD hd)
        {
            bool isThanhCong;
            try
            {
                CTHD order = db.CTHDs.First(s => s.MaHD == hd.MaHD
                     && s.MaSP == hd.MaSP);
                isThanhCong = true;
                order.DongiaBan = hd.DongiaBan;

                order.Soluong = hd.Soluong;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                isThanhCong = false;
            }
            return isThanhCong;
        }
        public bool XoaCTDH(int maHD, int maSP)
        {
            bool isThanhCong;
            try
            {
                CTHD ds = db.CTHDs.First(s => s.MaHD == maHD
                && s.MaSP == maSP);
                db.CTHDs.Remove(ds);
                db.SaveChanges();
                isThanhCong = true;
            }
            catch (Exception)
            {
                isThanhCong = false;
            }

            return isThanhCong;
        }
    }
}

