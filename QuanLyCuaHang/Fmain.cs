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
    public partial class Fmain : Form
    {
        public Fmain()
        {
            InitializeComponent();
        }

        private void mnuNhanVien_Click(object sender, EventArgs e)
        {
            FQuanLyNhanVien f1 = new FQuanLyNhanVien();
            f1.MdiParent = this;
            f1.StartPosition = FormStartPosition.CenterScreen;
            f1.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            FQuanLyKhachHang f2 = new FQuanLyKhachHang();
            f2.MdiParent = this;
            f2.StartPosition = FormStartPosition.CenterScreen;
            f2.Show();
        }

        private void mnuHangHoa_Click(object sender, EventArgs e)
        {
            FQuanLySanPham f3 = new FQuanLySanPham();
            f3.MdiParent = this;
            f3.StartPosition = FormStartPosition.CenterScreen;
            f3.Show();
        }

        private void mnuHoaDonBan_Click(object sender, EventArgs e)
        {
            FQuanLyHoaDon f4 = new FQuanLyHoaDon();
            f4.MdiParent = this;
            f4.StartPosition = FormStartPosition.CenterScreen;
            f4.Show();
        }
    }
}
