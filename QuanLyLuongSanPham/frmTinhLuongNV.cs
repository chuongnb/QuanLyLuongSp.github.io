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
    public partial class frmTinhLuongNV : Form
    {
        public frmTinhLuongNV()
        {
            InitializeComponent();
        }
        clsLuongNV lnv = new clsLuongNV();
        clsNhanVien nv = new clsNhanVien();
        private void frmTinhLuongNV_Load(object sender, EventArgs e)
        {
            cboThang.SelectedIndex = DateTime.Now.Month - 3;
            cboNam.SelectedIndex = DateTime.Now.Year - 2021;
            lblThoiGian.Text = (DateTime.Now.Month - 1).ToString() + "/" + DateTime.Now.Year.ToString();
            string thanglam = cboThang.Text.Trim() + "/" + cboNam.Text.Trim();
            CreateColumns(lvwDanhSach);
            LoadNVToListView(lvwDanhSach, lnv.GetLuongNVTheoThang(thanglam));
        }
        // Tạo cột cho lvwDanhSach
        public void CreateColumns(ListView lvw)
        {
            lvw.Columns.Clear();
            lvw.View = View.Details;
            lvw.GridLines = true;
            lvw.FullRowSelect = true;
            lvw.Columns.Add("STT", 45);
            lvw.Columns.Add("ID", 80);
            lvw.Columns.Add("Tháng", 80);
            lvw.Columns.Add("Số ngày làm", 90);
            lvw.Columns.Add("Tăng ca ngày thường",150);
            lvw.Columns.Add("Tăng ca ngày nghỉ", 150);
            lvw.Columns.Add("Tăng ca ngày lễ", 150);
        }
        //Tạo list view item (NV)
        ListViewItem TaoItemNV(tblLuongNV l)
        {
            ListViewItem lvwItem;
            lvwItem = new ListViewItem(l.STT.Trim());
            lvwItem.SubItems.Add(l.IDNV.Trim());
            lvwItem.SubItems.Add(l.ThangLam);//định dạng ngày theo dd-MM-yyyy
            lvwItem.SubItems.Add(l.SoNgayLam.ToString());
            lvwItem.SubItems.Add(l.TangCaThuong.ToString());
            lvwItem.SubItems.Add(l.TangCaNgayNghi.ToString());
            lvwItem.SubItems.Add(l.TangCaNgayLe.ToString());
            return lvwItem;
        }
        //Load luong lên listview
        void LoadNVToListView(ListView lvw, IEnumerable<tblLuongNV> dsLNV)
        {
            ListViewItem ItemNV;
            foreach (tblLuongNV n in dsLNV)
            {
                ItemNV = TaoItemNV(n);
                lvw.Items.Add(ItemNV);
            }
        }
        //Load lên text box
        void LuongToTextBox(tblLuongNV luong)
        {
            txtID.Text = luong.IDNV;
            txtSNL.Text = luong.SoNgayLam.ToString();
            txtTCLe.Text = luong.TangCaNgayLe.ToString();
            txtTCNghi.Text = luong.TangCaThuong.ToString();
            txtTCThuong.Text = luong.TangCaThuong.ToString();
            txtTen.Text = nv.GetNVByID(txtID.Text).HoTen;
            lblHSL.Text = nv.GetNVByID(txtID.Text).HeSoLuong.ToString();
            lblPC.Text = nv.GetNVByID(txtID.Text).PhuCap.ToString();

            float HSL =nv.GetNVByID(txtID.Text).HeSoLuong;
            float PC = nv.GetNVByID(txtID.Text).PhuCap;
            float SNL = Convert.ToInt32(luong.SoNgayLam);
            float TCL = Convert.ToInt32(luong.TangCaNgayLe);
            float TCN = Convert.ToInt32(luong.TangCaNgayNghi);
            float TCT = Convert.ToInt32(luong.TangCaThuong);
            double Luong = Math.Round(HSL / 30 * SNL + TCL * HSL / 720 * 3 + TCN * HSL / 720 * 2 + TCT * HSL / 720 * 1.5);
            lblLuong.Text = Luong.ToString();
            lblBHXH.Text = Math.Round((Luong * 8 / 100)).ToString();
            lblBHYT.Text = Math.Round(Luong * 1 / 100).ToString();
            if (Luong > 11000000)
                lblThue.Text = (Luong * 10 / 100).ToString();
            else
                lblThue.Text = "0";
            lblTongNhan.Text = (Luong - Convert.ToInt32(lblBHYT.Text) - Convert.ToInt32(lblBHXH.Text) - Convert.ToInt32(lblThue.Text)).ToString();
        }
        private void lvwDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSTT;
            if (lvwDanhSach.SelectedItems.Count == 1)
            {
                strSTT = lvwDanhSach.SelectedItems[0].Text;
                LuongToTextBox(lnv.GetLuongNVTheoSTT(strSTT));
                btnOK.Enabled = true;
                button2.Enabled = true;
            }
            else
            {
                btnOK.Enabled = false;
                txtSNL.Enabled = false;
                txtTCLe.Enabled = false;
                txtTCNghi.Enabled = false;
                txtTCThuong.Enabled = false;
                btnOK.Text = "Sửa";
                btnHuy.Enabled = false;
                button2.Enabled = false;
            }
        }
        tblLuongNV TaoLuongNV()
        {
            tblLuongNV l = new tblLuongNV();
            l.STT = lvwDanhSach.SelectedItems[0].Text;
            l.IDNV = txtID.Text;
            l.SoNgayLam = Convert.ToInt32(txtSNL.Text);
            l.ThangLam = lblThoiGian.Text;
            l.TangCaNgayLe = Convert.ToInt32(txtTCLe.Text);
            l.TangCaNgayNghi = Convert.ToInt32(txtTCNghi.Text);
            l.TangCaThuong = Convert.ToInt32(txtTCThuong.Text);
            return l;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtSNL.Enabled == false)
            {
                txtSNL.Enabled = true;
                txtTCLe.Enabled = true;
                txtTCNghi.Enabled = true;
                txtTCThuong.Enabled = true;
                btnOK.Text = "OK";
                btnHuy.Enabled = true;
            }
            else
            {
                DialogResult r = MessageBox.Show("Lưu thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    tblLuongNV l = TaoLuongNV();
                    lnv.SuaLuongNV(l);
                    lvwDanhSach.Items.Clear();
                    LoadNVToListView(lvwDanhSach, lnv.GetLuongNVTheoThang(lblThoiGian.Text));
                    txtSNL.Enabled = false;
                    txtTCLe.Enabled = false;
                    txtTCNghi.Enabled = false;
                    txtTCThuong.Enabled = false;
                    btnOK.Text = "Sửa";
                    btnHuy.Enabled = false;
                    btnOK.Enabled = false;//thêm line này
                }
            }
        }

        private void frmTinhLuongNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtSNL.Enabled = false;
            txtTCLe.Enabled = false;
            txtTCNghi.Enabled = false;
            txtTCThuong.Enabled = false;
            btnOK.Text = "Sửa";
            btnHuy.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemLNV frm = new frmThemLNV();
            frm.ShowDialog();
            lvwDanhSach.Items.Clear();
            LoadNVToListView(lvwDanhSach, lnv.GetLuongNVTheoThang(lblThoiGian.Text));
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            string thanglam = cboThang.Text.Trim() + "/" + cboNam.Text.Trim();
            lvwDanhSach.Items.Clear();
            LoadNVToListView(lvwDanhSach, lnv.GetLuongNVTheoThang(thanglam));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmPhieuLuong frm = new frmPhieuLuong();
            frm.MessageAccount = txtID.Text;
            frm.ShowDialog();
        }

        private void cboThang_Click(object sender, EventArgs e)
        {

        }
    }
}
