using QuanLyCuaHang.DAO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang.BUS
{
    class BUS_SanPham
    {
        DAO_SanPham dAO_SanPham;
        public BUS_SanPham()
        {
            dAO_SanPham = new DAO_SanPham();
        }

        //Lấy ds sản phẩm bên DAO đổ vào datagridview
        public void ListSanPham(DataGridView dg)
        {
            //tự xử lý try catch bắt lỗi
            dg.DataSource = dAO_SanPham.ListSanPham();
        }
        public void DSSP(ComboBox cb)
        {
            //tự xủa lý lỗi  nếu có
            cb.DataSource = dAO_SanPham.ListSanPham();
            cb.DisplayMember = "TenSP";
            cb.ValueMember = "MaSP";
        }

        public void LayDSLoaiSP(ComboBox cb)
        {
            cb.DataSource = dAO_SanPham.LayDSLoaiSP();
            cb.DisplayMember = "TenLoaiSP"; //Cái hiển thị ra là tên
            cb.ValueMember = "MaLoaiSP"; //Cái lưu trữ id
        }
        public SanPham LayTTSP(int maSP)
        {
            return dAO_SanPham.LaySP(maSP);
        }
        public bool AddSanPham(SanPham sp)
        {
            try
            {
                dAO_SanPham.AddSanPham(sp);
                return true;
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public bool EditSanPham(SanPham sp)
        {
            if (dAO_SanPham.CheckSanPham(sp.MaSP))
            {
                try
                {
                    dAO_SanPham.EditSanPham(sp);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool DeleteSanPham(int maSP)
        {
            if (dAO_SanPham.CheckSanPham(maSP))
            {
                try
                {
                    dAO_SanPham.DeleteSanPham(maSP);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
