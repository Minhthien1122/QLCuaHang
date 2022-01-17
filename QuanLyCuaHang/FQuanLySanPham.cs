using QuanLyCuaHang.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyCuaHang
{
    public partial class FQuanLySanPham : Form
    {
        BUS_SanPham bUS_SanPham;
        public FQuanLySanPham()
        {
            InitializeComponent();
            bUS_SanPham = new BUS_SanPham();
        }

        public void ListSanPham()
        {
            gVSanPham.DataSource = null; //Để khi gọi lại k bị cập nhật đè lên
            bUS_SanPham.ListSanPham(gVSanPham);
            //định dạng các cột
            gVSanPham.Columns[0].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[1].Width = (int)(gVSanPham.Width * 0.15);
            gVSanPham.Columns[2].Width = (int)(gVSanPham.Width * 0.20);
            gVSanPham.Columns[3].Width = (int)(gVSanPham.Width * 0.20);
            gVSanPham.Columns[4].Width = (int)(gVSanPham.Width * 0.25);
            //gVSanPham.Columns[5].Width = (int)(gVSanPham.Width * 0.2);
        }

        private void FQuanLySanPham_Load(object sender, EventArgs e)
        {
            ListSanPham();
            bUS_SanPham.LayDSLoaiSP(cbLoaiSP);
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();

            sp.TenSP = txtTenSP.Text;
            sp.MaLoaiSP = int.Parse(cbLoaiSP.SelectedValue.ToString());
            sp.SoLuong = txtSoLuong.Text;
            sp.Dongia = int.Parse(txtDonGia.Text.Replace(".", ""));

            //bUS_SanPham.ThemSP(sp);
            //ListSanPham();
            if (bUS_SanPham.AddSanPham(sp))
            {
                MessageBox.Show("Thêm sản phẩm thành công!");
                ListSanPham();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại!");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();

            sp.TenSP = txtTenSP.Text;
            sp.MaLoaiSP = int.Parse(cbLoaiSP.SelectedValue.ToString());
            sp.SoLuong = txtSoLuong.Text;
            sp.Dongia = int.Parse(txtDonGia.Text.Replace(".", ""));

            if (bUS_SanPham.EditSanPham(sp))
            {
                MessageBox.Show("Sửa đơn hàng thành công!");
                bUS_SanPham.ListSanPham(gVSanPham);
            }
            else
            {
                MessageBox.Show("Sửa đơn hàng thất bại!");
            }
        }

        private void gVSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.RowIndex < gVSanPham.Rows.Count)
                {
                    txtMaSP.Text = gVSanPham.Rows[e.RowIndex].Cells[0].Value.ToString();
                    txtTenSP.Text = gVSanPham.Rows[e.RowIndex].Cells[1].Value.ToString();
                    cbLoaiSP.Text = gVSanPham.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtSoLuong.Text = gVSanPham.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtDonGia.Text = gVSanPham.Rows[e.RowIndex].Cells[4].Value.ToString();

                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maSP;
            maSP = int.Parse(txtMaSP.Text);

            if (bUS_SanPham.DeleteSanPham(maSP))
            {
                MessageBox.Show("Xóa sản phẩm thành công!");
                bUS_SanPham.ListSanPham(gVSanPham);
            }
            else
            {
                MessageBox.Show("Xóa sản phẩm thất bại!");
            }
        }
    }
}
