using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyCuaHang.DAO;
using System.Transactions;

namespace QuanLyCuaHang.BUS
{
    class BUS_CTHD
    {
        DAO_CTHD dCTHD;
        DAO_SanPham dSanPham;
        public BUS_CTHD()
        {
            dCTHD = new DAO_CTHD();
            dSanPham = new DAO_SanPham();
        }
        public void LayDSCTHD(DataGridView dg, int maHD)
        {
            dg.DataSource = dCTHD.LayDSCTHD(maHD);
        }
        public void DSSP(ComboBox cb)
        {
            DAO_SanPham DSSP = new DAO_SanPham();
            cb.DataSource = DSSP.ListSanPham();
            cb.DisplayMember = "TenSP";
            cb.ValueMember = "MaSP";
        }
        public bool ThemCTDH(int maHD, DataTable dtDonHang)
        {
            //duyet tung dong 
            // kiem tra sp cos chua neu co k them
            //theem dong vaof order
            bool kq = false;
            using (TransactionScope trans = new TransactionScope())
            {
                try
                {
                    foreach (DataRow item in dtDonHang.Rows)
                    {
                        CTHD d = new CTHD();
                        d.MaHD = maHD;
                        d.MaSP = int.Parse(item[0].ToString());
                        d.DongiaBan = float.Parse(item[1].ToString());
                        d.Soluong = short.Parse(item[2].ToString());
                        d.Giamgia = float.Parse(item[0].ToString());
                        // kiem tra sp cos chua neu co k them
                        if (dCTHD.KiemTraSPDH(d))
                        {
                            //theem dong ctdh vaf ctdh
                            dCTHD.ThemCTDH(d);
                        }
                        else
                        {
                            throw new Exception("San pham đã tồn tại" + d.Soluong);
                        }
                    }
                    trans.Complete();
                    kq = true;
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            return kq;
        }
        public bool XoaCTDH(int maHD, int maSP)
        {
            if (dCTHD.XoaCTDH(maHD, maSP))
            {
                try
                {
                    dCTHD.XoaCTDH(maHD, maSP);
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
        public bool SuaCTHD(CTHD d)
        {
            if (dCTHD.KTCTHD(d))//có đơn hàng
            {
                try
                {
                    dCTHD.SuaCTHD(d);
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
    }
}
