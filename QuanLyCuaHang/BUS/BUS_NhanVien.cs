using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHang.DAO;

namespace QuanLyCuaHang.BUS
{
    class BUS_NhanVien
    {
        DAO_NhanVien dNhanVien;
        public BUS_NhanVien()
        {
            dNhanVien = new DAO_NhanVien();
        }
        public void ListNhanVien(DataGridView dg)
        {
            dg.DataSource = dNhanVien.ListNhanVien();
        }
        public bool AddNhanVien(Nhanvien nhanvien)
        {
            try
            {
                dNhanVien.AddNhanVien(nhanvien);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool DeleteNhanVien(int maNV)
        {
            if (dNhanVien.CheckNhanVien(maNV))
            {
                try
                {
                    dNhanVien.DeleteNhanVien(maNV);
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
        public bool EditNhanVien(Nhanvien nv)
        {
            if (dNhanVien.CheckNhanVien(nv.MaNV))
            {
                try
                {
                    dNhanVien.EditNhanVien(nv);
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
    }
}
