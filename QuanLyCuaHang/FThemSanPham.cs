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
    public partial class FThemSanPham : Form
    {
        #region Bien toan cuc
        public int maHD;
        private BUS_CTHD bCTHD;
        private BUS_SanPham bUS_SanPham;
        private bool co = false;
        DataTable dtHoaDon;
        #endregion

        public FThemSanPham()
        {
            InitializeComponent();
            //bHoaDon = new BUS_HoaDon();
            bUS_SanPham = new BUS_SanPham();
        }

        private void FThemSanPham_Load(object sender, EventArgs e)
        {
            bUS_SanPham.DSSP(cbTenSP);
            co = true;
            //HT MaHD
            txtMaHD.Text = maHD.ToString();
            // định nghĩa dg có 4 cột 
            dtHoaDon = new DataTable();
            dtHoaDon.Columns.Add("MaSP");
            dtHoaDon.Columns.Add("DonGia");
            dtHoaDon.Columns.Add("SoLuong");
            dtHoaDon.Columns.Add("Giamgia");

            gVCTDH.DataSource = dtHoaDon;
            gVCTDH.Columns[0].Width = (int)(gVCTDH.Width * 0.15);
            gVCTDH.Columns[1].Width = (int)(gVCTDH.Width * 0.25);
            gVCTDH.Columns[2].Width = (int)(gVCTDH.Width * 0.25);
            gVCTDH.Columns[3].Width = (int)(gVCTDH.Width * 0.25);

        }

        private void btThem_Click(object sender, EventArgs e)
        {
            DataRow r;
            bool kt = true;

            //Kiểm tra sp đó có trong dg, ch có thêm, có rồi tăng sl
            foreach (DataRow item in dtHoaDon.Rows)
            {
                if (cbTenSP.SelectedValue.ToString() == item[0].ToString())
                {
                    item[2] = int.Parse(item[2].ToString()) + numSoLuong.Value;
                    kt = false;
                    break;
                }
            }
            if (kt)//thêm 1 dòng mới
            {
                r = dtHoaDon.NewRow();
                r[0] = int.Parse(cbTenSP.SelectedValue.ToString());
                r[1] = int.Parse(txtDonGia.Text.Replace(".", ""));
                r[2] = Convert.ToInt32(numSoLuong.Value);
                r[3] = int.Parse(txtGiamGia.Text);
                dtHoaDon.Rows.Add(r);
            }
        }
        private void btLuuCTDH_Click(object sender, EventArgs e)
        {
            bCTHD = new BUS_CTHD();
            //Luu datatb xuống db
            if (bCTHD.ThemCTDH(maHD, dtHoaDon))
            {
                MessageBox.Show("Thêm sản phẩm thành công");
                //đóng form
                this.Close();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại");
            }
        }
        private void btXoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewCell oneCell in gVCTDH.SelectedCells)
            {
                if (oneCell.Selected)
                    gVCTDH.Rows.RemoveAt(oneCell.RowIndex);
            }
        }
        private void btSua_Click(object sender, EventArgs e)
        {

        }
        private void btThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void gVCTDH_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0 && e.RowIndex < gVCTDH.Rows.Count)
        //    {
        //        DataGridViewRow selectedRow = gVCTDH.Rows[e.RowIndex];
        //        txbMaSP.Text = selectedRow.Cells[0].Value.ToString();
        //        txtDonGia.Text = selectedRow.Cells[1].Value.ToString();
        //        numSoLuong.Text = selectedRow.Cells[2].Value.ToString();
        //        txtGiamGia.Text = selectedRow.Cells[3].Value.ToString();
        //    }
        //}
        private void cbTenSP_SelectedIndexChanged(object sender, EventArgs e)
        {
            SanPham p;
            int maSP;
            if (co)
            {
                maSP = int.Parse(cbTenSP.SelectedValue.ToString());
                //BuSP-> Product
                p = bUS_SanPham.LayTTSP(maSP);
                //-> add cacs controls
                txtDonGia.Text = p.Dongia.ToString();
                txbMaSP.Text = p.MaSP.ToString();
                txtLoaiSP.Text = p.LoaiSP.TenLoaiSP.ToString();
            }
        }
    }
}
