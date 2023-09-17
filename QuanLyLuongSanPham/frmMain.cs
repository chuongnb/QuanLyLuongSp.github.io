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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }
        private string _messageID;
        public string MessageID //nhận thông tin
        {
            get { return _messageID; }
            set { _messageID = value; }
        }
        //khai báo biến class
        clsAccountCN acn = new clsAccountCN();
        clsAccountNV anv = new clsAccountNV();
        clsCongNhan cn = new clsCongNhan();
        clsNhanVien nv = new clsNhanVien();
        //sự kiện load form
        private void frmMain_Load(object sender, EventArgs e)
        {
            lblID.Text = MessageID;//nhận id đăng nhập          
            if (lblID.Text.Substring(0, 2).ToUpper().Equals("CN"))
            {
                lblQuyen.Text = cn.GetCNByID(lblID.Text).ChucVu;
                mnuMainNhanSuQuanLyNhanVien.Enabled = false;
                lblTaiKhoan.Text = cn.GetCNByID(MessageID).HoTen;
            }
            else
            {
                lblQuyen.Text = nv.GetNVByID(lblID.Text).ChucVu;
                mnuMainNhanSuQuanLyCongNhan.Enabled = false;
                lblTaiKhoan.Text = nv.GetNVByID(MessageID).HoTen;
            }
            lblPhienLamViec.Text = DateTime.Now.ToShortDateString();
            this.WindowState = FormWindowState.Maximized;
            if (lblQuyen.Text.Trim().ToUpper().Equals("QUẢN LÝ")==false)
            {
                mnuMainChucNang.Enabled = false;
                mnuMainNhanSu.Enabled = false;
            }
        }
        //kiểm tra tồn tại form
        bool KiemTraTonTaiForm(String frmTenForm)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name.Equals(frmTenForm))
                {
                    frm.Activate();
                    return true;
                }
            }
            return false;
        }
        //sự kiện mở form đổi mật khẩu
        private void mnuMainHeThongDoiMK_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTaiForm("frmDoiMK") == false)
            {
                frmDoiMK frm = new frmDoiMK();
                frm.MdiParent = this;
                frm.Name = "frmDoiMK";
                frm.MessageAccount = lblID.Text;
                frm.Show();
            }
        }
        //sự kiện chọn thoát ở menu hệ thống
        private void mnuMainHeThongThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //hỏi đóng form
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
        //mở form quản lý nhân viên
        private void mnuMainNhanSuQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTaiForm("frmQLNV") == false)
            {
                frmQLNV frm = new frmQLNV();
                frm.MdiParent = this;
                frm.Name = "frmQLNV";
                frm.MessageID = lblID.Text;//thêm
                frm.Show();
            }
        }
        //mở form quản lý công nhân
        private void mnuMainNhanSuQuanLyCongNhan_Click(object sender, EventArgs e)
        {
            if (KiemTraTonTaiForm("frmQLCN") == false)
            {
                frmQLCN frm = new frmQLCN();
                frm.MdiParent = this;
                frm.Name = "frmQLCN";
                frm.MessageID = lblID.Text;//thêm
                frm.Show();
            }
        }
        //mở form quản lý tài khoản người dùng
        private void mnuMainNguoiDungQLTK_Click(object sender, EventArgs e)
        {
            if (lblID.Text.Substring(0, 2).ToUpper().Equals("NV"))
            {
                if (KiemTraTonTaiForm("frmQLTKNV") == false)
                {
                    frmQLTKNV frm = new frmQLTKNV();
                    frm.MdiParent = this;
                    frm.Name = "frmQLTKNV";
                    frm.MessageAccount = lblID.Text;
                    frm.Show();
                }
            }
            else
            {
                if (KiemTraTonTaiForm("frmQLTKCN") == false)
                {
                    frmQLTKCN frm = new frmQLTKCN();
                    frm.MdiParent = this;
                    frm.Name = "frmQLTKCN";
                    frm.MessageAccount = lblID.Text;
                    frm.Show();
                }
            }
        }
        //mở form tính lương
        private void mnuMainChucNangTinhLuong_Click(object sender, EventArgs e)
        {
            //mở tính lương công nhân
            if(lblID.Text.Substring(0, 2).ToUpper().Equals("CN"))
            {
                if (KiemTraTonTaiForm("frmTinhLuongCN")==false)
                {
                    frmTinhLuongCN frm = new frmTinhLuongCN();
                    frm.MdiParent = this;
                    frm.Name = "frmTinhLuongCN";
                    frm.Show();
                }
            }
            //mở tính lương nhân viên
            else if (lblID.Text.Substring(0, 2).ToUpper().Equals("NV"))
            {
                if (KiemTraTonTaiForm("frmTinhLuongNV")==false)
                {
                    frmTinhLuongNV frm = new frmTinhLuongNV();
                    frm.MdiParent = this;
                    frm.Name = "frmTinhLuongNV";
                    frm.Show();
                }
            }           
        }
    }
}
