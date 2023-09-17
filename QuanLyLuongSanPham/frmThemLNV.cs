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
    public partial class frmThemLNV : Form
    {
        public frmThemLNV()
        {
            InitializeComponent();
        }
        clsNhanVien nv = new clsNhanVien();
        clsLuongNV lnv = new clsLuongNV();
        void XuLyHoTroAutocomplete()
        {
            IEnumerable<tblNhanVienHanhChinh> dsNV = nv.GetAllNhanVien();
            txtID.AutoCompleteCustomSource.Clear();
            foreach (tblNhanVienHanhChinh n in dsNV)
                txtID.AutoCompleteCustomSource.Add(n.IDNV);//Add item autocomplete vào txt tìm kiếm
        }

        private void frmThemLNV_Load(object sender, EventArgs e)
        {
            XuLyHoTroAutocomplete();
            lblSTT.Text = (lnv.GetLNV().Count() + 1).ToString();
            cboThang.SelectedIndex = (DateTime.Now.Month - 1);
            cboNam.SelectedIndex = (DateTime.Now.Year - 2021);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text.Count() == 5)
            {
                tblNhanVienHanhChinh n = nv.GetNVByID(txtID.Text);
                txtTen.Text = n.HoTen;
                lblHSL.Text = n.HeSoLuong.ToString();
                lblPC.Text = n.PhuCap.ToString();
            }
        }
        tblLuongNV TaoLNV()
        {
            tblLuongNV l = new tblLuongNV();
            l.STT = lblSTT.Text;
            l.IDNV = txtID.Text;
            if (txtSNL.Text != "")
                l.SoNgayLam = Convert.ToInt32(txtSNL.Text);
            else
                l.SoNgayLam = 0;

            if (txtTCLe.Text != "")
                l.TangCaNgayLe = Convert.ToInt32(txtTCLe.Text);
            else
                l.TangCaNgayLe = 0;

            if (txtTCNghi.Text != "")
                l.TangCaNgayNghi = Convert.ToInt32(txtTCNghi.Text);
            else
                l.TangCaNgayNghi = 0;

            if (txtTCThuong.Text != "")
                l.TangCaThuong = Convert.ToInt32(txtTCThuong.Text);
            else
                l.TangCaThuong = 0;

            l.ThangLam = cboThang.Text + "/" + cboNam.Text;
            return l;
        }

        private void btnOK_Click(object sender, EventArgs e)
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
                    r = MessageBox.Show("Thêm?", "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)//nếu yes
                    {
                        tblLuongNV l = TaoLNV();//tạo item 
                        lnv.insertLuongNhanVien(l);
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
    }
}
