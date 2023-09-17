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
    public partial class frmThemNV : Form
    {
        private string _messagePB;
        public frmThemNV()
        {
            InitializeComponent();
        }
        public string MessagePB //đối tượng nhận thông tin
        {
            get { return _messagePB; }
            set { _messagePB = value; }
        }
        clsAccountNV anv = new clsAccountNV();
        clsNhanVien nv = new clsNhanVien();

        private void frmThemNV_Load(object sender, EventArgs e)
        {
            lblPhongBan.Text = MessagePB;
            radNam.Checked = true;
            cboChucVu.SelectedIndex = 0;
        }
        //tạo item chứa thông tin nhân viên
        tblNhanVienHanhChinh TaoNhanVien()
        {
            tblNhanVienHanhChinh n = new tblNhanVienHanhChinh();
            n.IDNV = txtID.Text;
            n.HoTen = txtTen.Text;
            n.NgayBatDau = Convert.ToDateTime(dtmNgayBD.Text).Date;
            n.NgaySinh = Convert.ToDateTime(dtmNS.Text).Date;
            if (radNam.Checked == true)
                n.GioiTinh = "Nam";
            else
                n.GioiTinh = "Nữ";
            n.ChucVu = cboChucVu.SelectedItem.ToString();
            n.PhuCap = Convert.ToInt32(txtPC.Text);
            n.HeSoLuong = Convert.ToInt32(txtHSL.Text);
            n.IDPB = lblPhongBan.Text;
            n.TrangThai = "Làm việc";
            return n;
        }
        //tạo item chứa account NV
        tblAccountNV TaoAccNhanVien()
        {
            tblAccountNV a = new tblAccountNV();
            a.IDNV = txtID.Text.ToUpper().Trim();
            a.PassNV = "123456ab";
            a.STT = txtID.Text.Substring(txtID.Text.Length - 2, 2);
            return a;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (clsCheck.IDNVCheck(txtID.Text) == false)
                {
                    MessageBox.Show("ID phải có dạng NVxxx !\nx là một chữ số [0-9]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Focus();
                }
                else
                {
                    DialogResult r;
                    r = MessageBox.Show("Thêm nhân viên?", "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)//nếu yes
                    {
                        tblNhanVienHanhChinh n= TaoNhanVien();//tạo item chứa thông tin nhân viên trên textbox
                        tblAccountNV a = TaoAccNhanVien();
                        nv.insertNhanVien(n);//Lưu vào database
                        anv.insertAccNhanVien(a);
                        btnThem.Enabled = false;
                        this.Close();//đóng form
                    }
                }
            }
            else
            {
                DialogResult r;
                r = MessageBox.Show("Mã trống", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (nv.CheckIfExistNV(txtID.Text) != null)
            {
                DialogResult r;
                r = MessageBox.Show("Trùng mã", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Text = "";
                txtID.Focus();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnThem.Enabled == true)
            {
                DialogResult r = MessageBox.Show("Bạn có chắc thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    e.Cancel = true;
            }
        }
    }
}
