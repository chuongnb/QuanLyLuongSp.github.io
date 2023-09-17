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
    public partial class frmTinhLuongCN : Form
    {
        public frmTinhLuongCN()
        {
            InitializeComponent();
        }
        clsLuongCN lcn = new clsLuongCN();
        clsCongNhan cn = new clsCongNhan();
        clsCongDoan cd = new clsCongDoan();
        private void frmTinhLuongNV_Load(object sender, EventArgs e)
        {            
            CreateColumns(lvwDanhSach);
            LoadNVToListView(lvwDanhSach, lcn.GetLCN());
        }
        // Tạo cột cho lvwDanhSach
        public void CreateColumns(ListView lvw)
        {
            lvw.Columns.Clear();
            lvw.View = View.Details;
            lvw.GridLines = true;
            lvw.FullRowSelect = true;
            lvw.Columns.Add("STT", 60);
            lvw.Columns.Add("ID", 80);
            lvw.Columns.Add("Công đoạn", 100);
            lvw.Columns.Add("Số lượng", 90);
            lvw.Columns.Add("Ca", 150);
            lvw.Columns.Add("Ngày làm", 150);
        }
        //Tạo list view item (NV)
        ListViewItem TaoItemNV(tblLuongCN l)
        {
            ListViewItem lvwItem;
            lvwItem = new ListViewItem(l.STT.Trim());
            lvwItem.SubItems.Add(l.IDCN.Trim());
            lvwItem.SubItems.Add(l.IDCD);//định dạng ngày theo dd-MM-yyyy
            lvwItem.SubItems.Add(l.SoLuong.ToString());
            lvwItem.SubItems.Add(l.Ca.ToString());
            lvwItem.SubItems.Add(String.Format("{0:dd-MM-yyyy}", l.NgayLam));
            return lvwItem;
        }
        //Load luong lên listview
        void LoadNVToListView(ListView lvw, IEnumerable<tblLuongCN> dsLCN)
        {
            ListViewItem ItemNV;
            foreach (tblLuongCN n in dsLCN)
            {
                ItemNV = TaoItemNV(n);
                lvw.Items.Add(ItemNV);
            }
        }
        //Load lên text box
        void LuongToTextBox(tblLuongCN luong)
        {
            txtID.Text = luong.IDCN;
            txtPhuCap.Text = cn.GetCNByID(txtID.Text).PhuCap.ToString();
            dtmNgayLam.Text = luong.NgayLam.ToString();
            if (luong.Ca.Equals("1"))
                cboCa.SelectedIndex = 0;
            else if (luong.Ca.Equals("2"))
                cboCa.SelectedIndex = 1;
            else
                cboCa.SelectedIndex = 2;

            if (luong.IDCD.Equals("CD001"))
                cboCongDoan.SelectedIndex = 0;
            else if (luong.IDCD.Equals("CD002"))
                cboCongDoan.SelectedIndex = 1;
            else if (luong.IDCD.Equals("CD003"))
                cboCongDoan.SelectedIndex = 2;
            else if (luong.IDCD.Equals("CD004"))
                cboCongDoan.SelectedIndex = 3;
            else
                cboCongDoan.SelectedIndex = 4;

            txtSoLuong.Text = luong.SoLuong.ToString();
            txtTen.Text = cn.GetCNByID(txtID.Text).HoTen;

            int SL = Convert.ToInt32(txtSoLuong.Text);
            int HSCD = cd.GetCongDoan(luong.IDCD).LuongCD;
            if (dtmNgayLam.Value.DayOfWeek == DayOfWeek.Saturday || dtmNgayLam.Value.DayOfWeek == DayOfWeek.Sunday)
                lblLuong.Text = (SL * HSCD * 2).ToString();
            else if (luong.Ca == "3")
                lblLuong.Text = (SL * HSCD * 1.3).ToString();
            else
                lblLuong.Text = (SL * HSCD).ToString();
            lblBHXH.Text = (Convert.ToInt32(lblLuong.Text) * 8 / 100).ToString();
            lblBHYT.Text = (Convert.ToInt32(lblLuong.Text) * 1 / 100).ToString();
        }
        private void lvwDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSTT;
            if (lvwDanhSach.SelectedItems.Count == 1)
            {
                strSTT = lvwDanhSach.SelectedItems[0].Text;
                LuongToTextBox(lcn.GetLCNThuocSTT(strSTT));
                btnSua.Enabled = true;
                btnKetToan.Enabled = true;
            }
            else
            {
                btnSua.Enabled = false;
                btnKetToan.Enabled = false;
                dtmNgayLam.Enabled = false;
                cboCongDoan.Enabled = false;
                cboCa.Enabled = false;
                txtSoLuong.Enabled = false;
                btnSua.Text = "Sửa";
                btnHuy.Enabled = false;
            }           
        }
        tblLuongCN TaoLuongCN()
        {
            tblLuongCN l = new tblLuongCN();
            l.STT = lvwDanhSach.SelectedItems[0].Text;
            l.IDCN = txtID.Text;
            l.IDCD = cboCongDoan.SelectedItem.ToString();
            l.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            l.Ca = cboCa.SelectedItem.ToString();
            l.NgayLam = dtmNgayLam.Value;
            return l;
        }

        private void frmTinhLuongCN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtmNgayLam.Enabled == false)
            {
                dtmNgayLam.Enabled = true;
                cboCa.Enabled = true;
                cboCongDoan.Enabled = true;
                txtSoLuong.Enabled = true;
                btnSua.Text = "OK";
                btnHuy.Enabled = true;
            }
            else
            {
                DialogResult r = MessageBox.Show("Lưu thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    tblLuongCN l = TaoLuongCN();
                    lcn.SuaLuongCN(l);
                    lvwDanhSach.Items.Clear();
                    LoadNVToListView(lvwDanhSach, lcn.GetLCN());
                    dtmNgayLam.Enabled = false;
                    cboCongDoan.Enabled = false;
                    cboCa.Enabled = false;
                    txtSoLuong.Enabled = false;
                    btnSua.Text = "Sửa";
                    btnHuy.Enabled = false;
                    btnSua.Enabled = false; //thêm line này
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            dtmNgayLam.Enabled = false;
            cboCongDoan.Enabled = false;
            cboCa.Enabled = false;
            txtSoLuong.Enabled = false;
            btnSua.Text = "Sửa";
            btnHuy.Enabled = false;
        }

        private void btnKetToan_Click(object sender, EventArgs e)
        {
            frmPhieuLuongCN frm = new frmPhieuLuongCN();
            frm.MessageAccount = txtID.Text;
            frm.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemLCN frm = new frmThemLCN();
            frm.ShowDialog();
            lvwDanhSach.Items.Clear();
            LoadNVToListView(lvwDanhSach, lcn.GetLCN());
        }
    }
}
