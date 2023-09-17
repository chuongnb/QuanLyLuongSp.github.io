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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //khai báo các class để dùng
        clsAccountCN acn = new clsAccountCN();
        clsCongNhan cn = new clsCongNhan();
        clsNhanVien nv = new clsNhanVien();
        clsAccountNV anv = new clsAccountNV();
        //Đăng nhập
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string ID = txtUserID.Text.ToUpper();// biến id lưu dữ liệu nhập vào từ txtID viết in hoa
            if (ID.Substring(0, 2).Equals("CN"))// nếu biến id chứa 2 ký tự đầu là CN
            {
                if (cn.CheckIfExistCN(ID) != null)//nếu tồn tại ID trong CSDL
                {
                    tblAccountCN a = acn.GetAccountCN(ID.Trim());//lấy thông tin account theo id
                    if (a.PassCN.Trim().Equals(txtPass.Text))//nếu pass đúng với thông tin account
                    {
                        frmMain frm = new frmMain();//tạo formMain mới
                        frm.MessageID = a.IDCN;//gửi Id đăng nhập sang formMain
                        this.Hide();//ẩn form đăng nhập
                        frm.ShowDialog();//mở form Main vừa tạo
                        Application.Exit();//đóng form đăng nhập
                    }
                    else
                        //nếu pass sai thông báo
                        MessageBox.Show("Pass sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else // nếu không tìm thấy id thông báo
                    MessageBox.Show("ID không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            //nếu  biến id chứa 2 ký tự đầu là NV hoặc QL (nhân viên hoặc quản lý đăng nhập)
            else if (ID.Substring(0, 2).Equals("NV"))
            {
                if (nv.CheckIfExistNV(ID) != null)//nếu tồn tại id trong csdl
                {
                    tblAccountNV a = anv.GetAccountNV(ID.Trim());//lấy thông tin đăng nhập theo id
                    if (a.PassNV.Trim().Equals(txtPass.Text))//nếu pass đúng
                    {
                        frmMain frm = new frmMain();//tạo form main mới
                        frm.MessageID = a.IDNV;//gửi id đăng nhập sang form main vừa tạo
                        this.Hide();//ẩn form đăng nhập
                        frm.ShowDialog();//mở form main
                                         //if (frm.ShowDialog() == DialogResult.OK)
                                         //frm.ShowDialog();
                        Application.Exit();//đóng form đăng nhập
                        /*this.Show();
                        txtPass.Text = "";
                        txtUserID.Text = "";
                        chkHienPass.Checked = false;
                        txtUserID.Focus();*/
                    }
                    else//nếu pas sai thông báo
                        MessageBox.Show("Pass sai!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else//nếu không tìm thấy id trong csdl thông báo
                    MessageBox.Show("ID không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else//nếu nhập id có dạng không bắt đầu bằng CN,NV hoặc QL thông báo
                MessageBox.Show("ID không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            txtPass.UseSystemPasswordChar = true;//dùng system password char cho text box pass(ẩn pass)
        }
        private void chkHienPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienPass.Checked)//nếu chọn hiện pass
                txtPass.UseSystemPasswordChar = false;//không dùng password char
            else//nếu bỏ chọn hiện pass
                txtPass.UseSystemPasswordChar = true;//dùng password char
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblQuenPass_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Vui lòng liên hệ phòng nhân sự để reset mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
