//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyCuaHang
{
    using System;
    using System.Collections.Generic;
    
    public partial class CTHD
    {
        public int MaHD { get; set; }
        public int MaSP { get; set; }
        public Nullable<short> Soluong { get; set; }
        public Nullable<double> DongiaBan { get; set; }
        public Nullable<float> Giamgia { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual SanPham SanPham { get; set; }
    }
}
