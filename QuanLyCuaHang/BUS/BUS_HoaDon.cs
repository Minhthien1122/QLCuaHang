using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHang.DAO;


namespace QuanLyCuaHang.BUS
{
    class BUS_HoaDon
    {
        DAO_HoaDon dAO_HoaDon;
        public BUS_HoaDon()
        {
            dAO_HoaDon = new DAO_HoaDon();
        }
        public void DSHoaDon(DataGridView dg)
        {
            dg.DataSource = dAO_HoaDon.DSHoaDon();
        }
        public void DSKhachHang(ComboBox cb)
        {
            DAO_KhachHang dAO_KhachHang = new DAO_KhachHang();
            cb.DataSource = dAO_KhachHang.ListKhachHang();
            cb.DisplayMember = "TenKH";
            cb.ValueMember = "MaKH";
        }
        public void DSNhanVien(ComboBox cb)
        {
            DAO_NhanVien dAO_NhanVien = new DAO_NhanVien();
            cb.DataSource = dAO_NhanVien.ListNhanVien();
            cb.DisplayMember = "Ten";
            cb.ValueMember = "MaNV";
        }
        public bool SuaHD(HoaDon d)
        {
            if (dAO_HoaDon.KTHD(d.MaHD))//có đơn hàng
            {
                try
                {
                    dAO_HoaDon.SuaHD(d);
                    //sủa thanh công
                    return true;
                }

                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool XoaHD(int maHD)
        {
            if (dAO_HoaDon.KTHD(maHD))// có đơn hàng trong order mới xóa
            {
                try
                {
                    dAO_HoaDon.XoaHD(maHD);
                    //xoa thanh công
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool ThemHD(HoaDon hd)
        {
            try
            {
                dAO_HoaDon.ThemHD(hd);
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}


