using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHang.BUS;


namespace QuanLyCuaHang
{
    public partial class FQuanLyKhachHang : Form
    {
        BUS_KhachHang bKhachHang;
        public FQuanLyKhachHang()
        {
            bKhachHang = new BUS_KhachHang();
            InitializeComponent();
        }
        private void ListKhachHang()
        {
            gVKH.DataSource = null;
            bKhachHang.ListKhachHang(gVKH);

            gVKH.Columns[0].Width = (int)(gVKH.Width * 0.07);
            gVKH.Columns[1].Width = (int)(gVKH.Width * 0.15);
            gVKH.Columns[2].Width = (int)(gVKH.Width * 0.3);
            gVKH.Columns[3].Width = (int)(gVKH.Width * 0.15);
            gVKH.Columns[4].Width = (int)(gVKH.Width * 0.15);
            gVKH.Columns[5].Width = (int)(gVKH.Width * 0.15);
        }
        private void FQuanLyKhachHang_Load(object sender, EventArgs e)
        {
            ListKhachHang();
        }

        private void gVKH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVKH.Rows.Count)
            {
                txtMaKH.Text = gVKH.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtTenKH.Text = gVKH.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDiaChi.Text = gVKH.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDienThoai.Text = gVKH.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmail.Text = gVKH.Rows[e.RowIndex].Cells[4].Value.ToString();
                if (gVKH.Rows[e.RowIndex].Cells["Fax"].Value == null)
                {
                    txtFax.Text = null;
                }
                else
                {
                    txtFax.Text = gVKH.Rows[e.RowIndex].Cells["Fax"].Value.ToString();
                }
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            KhachHang khachhang = new KhachHang();
            khachhang.TenKH = txtTenKH.Text;
            khachhang.DiaChi = txtDiaChi.Text;
            khachhang.Email = txtEmail.Text;
            khachhang.DienThoai = txtDienThoai.Text;
            khachhang.Fax = txtFax.Text;

            if (bKhachHang.AddKhachHang(khachhang))
            {
                MessageBox.Show("Thêm khách hàng thành công!");
                ListKhachHang();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại!");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maKH;
            maKH = int.Parse(txtMaKH.Text);

            if (bKhachHang.DeleteKhachHang(maKH))
            {
                MessageBox.Show("Xóa khách hàng thành công!");
                bKhachHang.ListKhachHang(gVKH);
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại!");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            KhachHang kh = new KhachHang();
            kh.MaKH = int.Parse(txtMaKH.Text);
            kh.TenKH = txtTenKH.Text;
            kh.Email = txtEmail.Text;
            kh.DiaChi = txtDiaChi.Text;
            kh.DienThoai = txtDienThoai.Text;
            kh.Fax = txtFax.Text;

            if (bKhachHang.EditKhacHang(kh))
            {
                MessageBox.Show("Sửa thông tin khách hàng thành công!");
                bKhachHang.ListKhachHang(gVKH); ;
            }
            else
            {
                MessageBox.Show("Sửa thông tin khách hàng thất bại!");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
