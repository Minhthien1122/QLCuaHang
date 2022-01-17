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
    public partial class FQuanLyNhanVien : Form
    {
        BUS_NhanVien bNhanVien;
        public FQuanLyNhanVien()
        {
            bNhanVien = new BUS_NhanVien();
            InitializeComponent();
        }
        private void ListNhanVien()
        {
            gVNV.DataSource = null;
            bNhanVien.ListNhanVien(gVNV);

            gVNV.Columns[0].Width = (int)(gVNV.Width * 0.07);
            gVNV.Columns[1].Width = (int)(gVNV.Width * 0.15);
            gVNV.Columns[2].Width = (int)(gVNV.Width * 0.15);
            gVNV.Columns[3].Width = (int)(gVNV.Width * 0.4);
            gVNV.Columns[4].Width = (int)(gVNV.Width * 0.15);
        }

        private void FNhanVien_Load(object sender, EventArgs e)
        {
            ListNhanVien();
        }

        private void gVNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVNV.Rows.Count)
            {
                txtMaNV.Text = gVNV.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtHo.Text = gVNV.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtTen.Text = gVNV.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDiaChi.Text = gVNV.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDienThoai.Text = gVNV.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            Nhanvien nhanvien = new Nhanvien();
            nhanvien.Ten = txtTen.Text;
            nhanvien.HoNV = txtHo.Text;
            nhanvien.Diachi = txtDiaChi.Text;
            nhanvien.Dienthoai = txtDienThoai.Text;
            
            if (bNhanVien.AddNhanVien(nhanvien))
            {
                MessageBox.Show("Thêm nhân viên thành công!");
                ListNhanVien();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại!");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            int maNV;
            maNV = int.Parse(txtMaNV.Text);

            if (bNhanVien.DeleteNhanVien(maNV))
            {
                MessageBox.Show("Xóa nhân viên thành công!");
                bNhanVien.ListNhanVien(gVNV);
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại!");
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            Nhanvien nv = new Nhanvien();
            nv.MaNV = int.Parse(txtMaNV.Text);
            nv.Ten = txtTen.Text;
            nv.HoNV = txtHo.Text;
            nv.Diachi = txtDiaChi.Text;
            nv.Dienthoai = txtDienThoai.Text;

            if (bNhanVien.EditNhanVien(nv))
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công!");
                bNhanVien.ListNhanVien(gVNV);
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhân viên thất bại!");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
