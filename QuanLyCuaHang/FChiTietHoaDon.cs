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
    public partial class FChiTietHoaDon : Form
    {
        #region Bien toan cuc
        public int maHD;
        BUS_CTHD bCTHD;
        //private BUS_SanPham bUS_SanPham;
        //private bool co = false;
        #endregion
        public FChiTietHoaDon()
        {
            InitializeComponent();
            bCTHD = new BUS_CTHD();
        }
        private void LayDSCTHD(int maHD)
        {

            gVCTDH.DataSource = null;
            bCTHD.LayDSCTHD(gVCTDH, maHD);

            ////Định dạng các cột

            gVCTDH.Columns[0].Width = (int)(gVCTDH.Width * 0.2);
            gVCTDH.Columns[1].Width = (int)(gVCTDH.Width * 0.25);
            gVCTDH.Columns[2].Width = (int)(gVCTDH.Width * 0.25);
            gVCTDH.Columns[3].Width = (int)(gVCTDH.Width * 0.25);


        }
        private void btThem_Click(object sender, EventArgs e)
        {
            FThemSanPham f = new FThemSanPham();
            f.maHD = maHD;
            f.ShowDialog();
        }
        private void FChiTietHoaDon_Load(object sender, EventArgs e)
        {
            bCTHD.DSSP(cbTenSP);
        }
        private void FChiTietHoaDon_Activated(object sender, EventArgs e)
        {
            LayDSCTHD(maHD);
        }
        private void gVCTDH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < gVCTDH.Rows.Count)
            {
                txtMaHD.Text = gVCTDH.Rows[e.RowIndex].Cells["MaHD"].Value.ToString();
                cbTenSP.Text = gVCTDH.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDongia.Text = gVCTDH.Rows[e.RowIndex].Cells[2].Value.ToString();
                numSoLuong.Text = gVCTDH.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
        private void btSuaCTHD_Click(object sender, EventArgs e)
        {
            CTHD d = new CTHD();
            d.MaHD = int.Parse(txtMaHD.Text);
            d.MaSP = int.Parse(cbTenSP.SelectedValue.ToString());
            d.Soluong = short.Parse(numSoLuong.Value.ToString());
            d.DongiaBan = int.Parse(txtDongia.Text);
            //gọi sự kiện sửa dh của bus

            if (bCTHD.SuaCTHD(d))
            {
                MessageBox.Show("Sửa chi tiết đơn hàng thành công!!!");
                //bCTHD.LayDSCTHD(gVCTDH);
            }
            else
            {
                MessageBox.Show("Sửa chi tiết đơn hàng không thành công!!!");
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            int maHD = int.Parse(txtMaHD.Text);
            int maSP = int.Parse(cbTenSP.SelectedValue.ToString());
            if (bCTHD.XoaCTDH(maHD, maSP))
            {
                MessageBox.Show("Xóa đơn hàng thành công!!!");
                bCTHD.LayDSCTHD(gVCTDH, maHD);
            }
            else
            {
                MessageBox.Show("Xóa đơn hàng không thành công!!!");
            }
        }

        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
