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
    public partial class frmQLTKCN : Form
    {
        public frmQLTKCN()
        {
            InitializeComponent();
        }
        public string _messageAccount;

        public string MessageAccount
        {
            get { return _messageAccount; }
            set { _messageAccount = value; }
        }

        clsCongNhan cn = new clsCongNhan();
        private void frmQLTKCN_Load(object sender, EventArgs e)
        {
            lblID.Text = MessageAccount;
            tblCongNhan c = cn.GetCNByID(lblID.Text);
            txtTen.Text = c.HoTen;
            if (c.GioiTinh.Trim().ToUpper().Equals("NAM"))
                radNam.Checked = true;
            else
                radNu.Checked = true;
            dtmNS.Text = c.NgaySinh.ToShortDateString();
            dtmNgayBD.Text = c.NgayBatDau.ToShortDateString();
            lblTrangThai.Text = c.TrangThai;
            lblCX.Text = c.IDCX;
            lblChucVu.Text = c.ChucVu;
        }
        //tạo item chứa thông tin công nhân
        tblCongNhan TaoCongNhan()
        {
            tblCongNhan c = new tblCongNhan();
            c.IDCN = lblID.Text;
            c.HoTen = txtTen.Text;
            c.NgayBatDau = Convert.ToDateTime(dtmNgayBD.Text).Date;
            c.NgaySinh = Convert.ToDateTime(dtmNS.Text).Date;
            if (radNam.Checked == true)
                c.GioiTinh = "Nam";
            else
                c.GioiTinh = "Nữ";
            c.TrangThai = lblTrangThai.Text.Trim();
            c.ChucVu = lblChucVu.Text;
            c.PhuCap = cn.GetCNByID(lblID.Text).PhuCap;
            c.IDCX = lblCX.Text;
            return c;
        }
        private void btnSuaTT_Click(object sender, EventArgs e)
        {
            if (txtTen.Enabled == false)
            {
                txtTen.Enabled = true;
                radNam.Enabled = true;
                radNu.Enabled = true;
                dtmNS.Enabled = true;
            }
            else
            {
                DialogResult r = MessageBox.Show("Lưu thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    btnSuaTT.Enabled = false;
                    txtTen.Enabled = false;
                    radNam.Enabled = false;
                    radNu.Enabled = false;
                    dtmNS.Enabled = false;
                    tblCongNhan c = TaoCongNhan();
                    cn.SuaCN(c);
                }
            }
        }

        private void frmQLTKCN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnXemPhieuLuong_Click(object sender, EventArgs e)
        {
            frmPhieuLuongCN frm = new frmPhieuLuongCN();
            frm.MessageAccount = lblID.Text;
            frm.ShowDialog();
        }
    }
}
