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
    public partial class FQuanLyHoaDon : Form
    {
        BUS_HoaDon bHoaDon;
        public FQuanLyHoaDon()
        {
            InitializeComponent();
            bHoaDon = new BUS_HoaDon();
        }
        private void DSHoaDon()
        {
            gVDH.DataSource = null;
            bHoaDon.DSHoaDon(gVDH);
            //Định dạng các cột
            gVDH.Columns[0].Width = (int)(gVDH.Width * 0.1);
            gVDH.Columns[1].Width = (int)(gVDH.Width * 0.25);
            gVDH.Columns[2].Width = (int)(gVDH.Width * 0.25);
            gVDH.Columns[3].Width = (int)(gVDH.Width * 0.20);
            gVDH.Columns[4].Width = (int)(gVDH.Width * 0.20);


        }

        private void FQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            DSHoaDon();
            bHoaDon.DSNhanVien(cbNhanVien);
            bHoaDon.DSKhachHang(cbKhachHang);
        }

        private void gVDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVDH.Rows.Count)
            {
                txtMaDH.Text = gVDH.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
                dtpNgayDatHang.Text = gVDH.Rows[e.RowIndex].Cells[1].Value.ToString();
                dtpkNgayGH.Text = gVDH.Rows[e.RowIndex].Cells[2].Value.ToString();
                cbKhachHang.Text = gVDH.Rows[e.RowIndex].Cells[3].Value.ToString();
                cbNhanVien.Text = gVDH.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            HoaDon d = new HoaDon();
            d.MaHD = int.Parse(txtMaDH.Text);
            d.NgayLapHD = dtpNgayDatHang.Value;// Xử lý ngày đặt hàng không đc là ngày trong tương lai(cần làm)           
            d.MaNV = int.Parse(cbNhanVien.SelectedValue.ToString());
            d.MaKH = int.Parse(cbKhachHang.SelectedValue.ToString());
            //gọi sự kiện sửa dh của bus

            if (bHoaDon.SuaHD(d))
            {
                MessageBox.Show("Sửa đơn hàng thành công!!!");
                bHoaDon.DSHoaDon(gVDH);
            }
            else
            {
                MessageBox.Show("Sửa đơn hàng không thành công!!!");
            }
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            //Nếu có trong order thi không xóa
            int maHD;
            maHD = int.Parse(txtMaDH.Text);

            if (bHoaDon.XoaHD(maHD))
            {
                MessageBox.Show("Xóa đơn hàng thành công!!!");
                bHoaDon.DSHoaDon(gVDH);
            }
            else
            {
                MessageBox.Show("Xóa đơn hàng không thành công!!!");
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            HoaDon hd = new HoaDon();
            hd.NgayLapHD = dtpNgayDatHang.Value;
            hd.MaNV = int.Parse(cbNhanVien.SelectedValue.ToString());
            hd.MaKH = int.Parse(cbKhachHang.SelectedValue.ToString());
            hd.NgayGiaoHang = dtpkNgayGH.Value;
            //gọi xử lý thêm đơn hàng
            if (bHoaDon.ThemHD(hd))
            {
                
                MessageBox.Show("Thêm thành công");
                DSHoaDon();
               
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }
        private void gVDH_DoubleClick(object sender, EventArgs e)
        {
            int maDH;
            FChiTietHoaDon f = new FChiTietHoaDon();
            maDH = int.Parse(gVDH.CurrentRow.Cells[0].Value.ToString());
            f.maHD = maDH;
            f.ShowDialog();
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
