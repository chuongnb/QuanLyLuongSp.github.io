using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuongSanPham
{
    public partial class frmQLTKNV : Form
    {
        public frmQLTKNV()
        {
            InitializeComponent();
        }
        public string _messageAccount;

        public string MessageAccount
        {
            get { return _messageAccount; }
            set { _messageAccount = value; }
        }
        clsNhanVien nv = new clsNhanVien();
        clsLuongNV lnv = new clsLuongNV();
        private void frmQLTKNV_Load(object sender, EventArgs e)
        {
            lblID.Text = MessageAccount;
            tblNhanVienHanhChinh n = nv.GetNVByID(lblID.Text);
            txtTen.Text = n.HoTen;
            if (n.GioiTinh.Trim().ToUpper().Equals("NAM"))
                radNam.Checked = true;
            else
                radNu.Checked = true;
            dtmNS.Text = n.NgaySinh.ToShortDateString();
            lblHSL.Text = n.HeSoLuong.ToString();
            lblPC.Text = n.PhuCap.ToString();
            lblTrangThai.Text = n.TrangThai;
            lblChucVu.Text = n.ChucVu;
            dtmNgayBD.Text = n.NgayBatDau.ToShortDateString();
            lblPB.Text = n.IDPB;
        }

        private void btnXemPhieuLuong_Click(object sender, EventArgs e)
        {
            frmPhieuLuong frm = new frmPhieuLuong();
            frm.MessageAccount = lblID.Text;
            frm.ShowDialog();
        }
    }
}
