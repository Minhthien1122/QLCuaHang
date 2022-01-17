using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyCuaHang.DAO;
using System.Windows.Forms;

namespace QuanLyCuaHang.BUS
{
    class BUS_KhachHang
    {
        DAO_KhachHang dKhachHang;
        public BUS_KhachHang()
        {
            dKhachHang = new DAO_KhachHang();
        }
        public void ListKhachHang(DataGridView dg)
        {
            dg.DataSource = dKhachHang.ListKhachHang();
        }
        public bool AddKhachHang(KhachHang kh)
        {
            try
            {
                dKhachHang.AddKhachHang(kh);
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }
        public bool DeleteKhachHang(int maKH)
        {
            if (dKhachHang.CheckKhachHang(maKH))
            {
                try
                {
                    dKhachHang.DeleteKhachHang(maKH);
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
        public bool EditKhacHang(KhachHang kh)
        {
            if(dKhachHang.CheckKhachHang(kh.MaKH))
            {
                try
                {
                    dKhachHang.EditKhachHang(kh);
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
