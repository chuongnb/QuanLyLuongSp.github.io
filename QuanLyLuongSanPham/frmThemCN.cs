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
    public partial class frmThemCN : Form
    {
        private string _messageCX;
        public frmThemCN()
        {
            InitializeComponent();
        }

        public string MessageCX //lớp nhận thông tin
        {
            get { return _messageCX; }
            set { _messageCX = value; }
        }
        clsAccountCN acn = new clsAccountCN();
        clsCongNhan cn = new clsCongNhan();
        private void frmThemCN_Load(object sender, EventArgs e)
        {
            lblCongXuong.Text = MessageCX;
            radNam.Checked = true;
            cboChucVu.SelectedIndex = 0;
            dtmNgayBD.MaxDate = DateTime.Now;
        }
        //tạo item chứa thông tin công nhân
        tblCongNhan TaoCongNhan()
        {
            tblCongNhan c = new tblCongNhan();
            c.IDCN = txtID.Text;
            c.HoTen = txtTen.Text;
            c.NgayBatDau = Convert.ToDateTime(dtmNgayBD.Text).Date;
            c.NgaySinh = Convert.ToDateTime(dtmNS.Text).Date;
            if (radNam.Checked == true)
                c.GioiTinh = "Nam";
            else
                c.GioiTinh = "Nữ";
            c.TrangThai = "Làm việc";
            c.ChucVu = cboChucVu.SelectedItem.ToString();
            c.PhuCap = Convert.ToInt32(txtPhuCap.Text);
            c.IDCX = lblCongXuong.Text;
            return c;
        }
        //tạo item chứa account CN
        tblAccountCN TaoAccCongNhan()
        {
            tblAccountCN a = new tblAccountCN();
            a.IDCN = txtID.Text.ToUpper().Trim();
            a.PassCN = "123456ab";
            a.STT = txtID.Text.Substring(txtID.Text.Length - 2, 2);
            return a;
        }
        //thêm CN
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtID.Text != "")
            {
                if (clsCheck.IDCNCheck(txtID.Text) == false)
                {
                    MessageBox.Show("ID phải có dạng CNxxx !\nx là một chữ số [0-9]", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtID.Focus();
                }
                else
                {
                    DialogResult r;
                    r = MessageBox.Show("Thêm công nhân?", "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)//nếu yes
                    {
                        tblCongNhan c = TaoCongNhan();//tạo item chứa thông tin nhân viên trên textbox
                        tblAccountCN a = TaoAccCongNhan();
                        cn.insertCongNhan(c);//Lưu vào database
                        acn.insertAccCongNhan(a);
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
        //không thêm và thoát
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemCN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnThem.Enabled == true)
            {
                DialogResult r = MessageBox.Show("Bạn có chắc thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.No)
                    e.Cancel = true;
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (cn.CheckIfExistCN(txtID.Text) != null)
            {
                DialogResult r;
                r = MessageBox.Show("Trùng mã", "Thông báo",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Text = "";
                txtID.Focus();
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
