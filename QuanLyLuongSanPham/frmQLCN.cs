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
    public partial class frmQLCN : Form
    {
        public frmQLCN()
        {
            InitializeComponent();
        }
        //Lấy class vào xài
        clsAccountCN acn = new clsAccountCN();
        clsCongDoan cd = new clsCongDoan();
        clsCongNhan cn = new clsCongNhan();
        clsLuongCN lcn = new clsLuongCN();
        clsCongXuong cx = new clsCongXuong();

        private string _messageID;//thêm
        public string MessageID //thêm
        {
            get { return _messageID; }
            set { _messageID = value; }
        }

        //sự kiện load form
        private void frmQLCN_Load(object sender, EventArgs e)
        {
            lblCongXuong.Text =cn.GetCNByID(MessageID).IDCX;//sửa
            CreateColumns(lvwDanhSach);
            CreateItemForCboCongXuong();
            IEnumerable<tblCongNhan> c = cn.GetCNByIDCX(lblCongXuong.Text);
            LoadCNToListView(lvwDanhSach, c);
            cboTimKiem.SelectedIndex = 0;
        }

        //Tạo cột cho list view
        public void CreateColumns(ListView lvw)
        {
            lvw.Columns.Clear();
            lvw.View = View.Details;
            lvw.GridLines = true;
            lvw.FullRowSelect = true;
            lvw.Columns.Add("ID", 60);
            lvw.Columns.Add("Họ tên", 170);
            lvw.Columns.Add("Giới tính", 80);
            lvw.Columns.Add("Ngày sinh", 130);
            lvw.Columns.Add("Ngày bắt đầu làm", 130);
            lvw.Columns.Add("Chức vụ", 100);
            lvw.Columns.Add("Trạng thái", 100);
        }

        //Tạo list view item (CN)
        ListViewItem TaoItemCN(tblCongNhan c)
        {
            ListViewItem lvwItem;
            lvwItem = new ListViewItem(c.IDCN);
            lvwItem.SubItems.Add(c.HoTen.Trim());
            lvwItem.SubItems.Add(c.GioiTinh.Trim());
            lvwItem.SubItems.Add(String.Format("{0:dd-MM-yyyy}", c.NgaySinh));//định dạng ngày theo dd-MM-yyyy
            lvwItem.SubItems.Add(String.Format("{0:dd-MM-yyyy}", c.NgayBatDau));
            lvwItem.SubItems.Add(c.ChucVu.Trim());
            lvwItem.SubItems.Add(c.TrangThai.Trim());
            lvwItem.Tag = c;
            return lvwItem;
        }

        //Load CN lên listview
        void LoadCNToListView(ListView lvw, IEnumerable<tblCongNhan> dsCN)
        {
            ListViewItem ItemCN;
            foreach (tblCongNhan c in dsCN)
            {
                ItemCN = TaoItemCN(c);
                lvw.Items.Add(ItemCN);
            }
        }

        //Tạo item cho cbo công xưởng
        void CreateItemForCboCongXuong()
        {
            IEnumerable<tblCongXuong> dsCX = cx.GetAllCongXuong();
            foreach (tblCongXuong x in dsCX)
                cboCongXuong.Items.Add(x.IDCX);
        }
        
        //Load CN lên text box
        void CNToTextBox(tblCongNhan c)
        {
            txtID.Text = c.IDCN;
            txtTen.Text = c.HoTen.Trim();
            //load nam nữ
            if (c.GioiTinh.Trim().Equals("Nam"))
                radNam.Checked = true;
            else
                radNu.Checked = true;

            dtmNS.Text = c.NgaySinh.ToShortDateString();
            dtmNgayBD.Text = c.NgayBatDau.ToShortDateString();
            //load chức vụ
            if (c.ChucVu.Trim().Equals("Công nhân"))
                cboChucVu.SelectedIndex = 0;
            else
                cboChucVu.SelectedIndex = 1;
            //load công xưởng
            if (c.IDCX.Trim().Equals(cboCongXuong.Items[0]))
                cboCongXuong.SelectedIndex = 0;
            else
                cboCongXuong.SelectedIndex = 1;
            if (c.TrangThai.Trim().ToUpper().Equals("LÀM VIỆC"))
                cboTrangThai.SelectedIndex = 0;
            else
                cboTrangThai.SelectedIndex = 1;
        }

        private void lvwDanhSach_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTen.Enabled = false;
            radNam.Enabled = false;
            radNu.Enabled = false;
            dtmNS.Enabled = false;
            cboCongXuong.Enabled = false;
            cboChucVu.Enabled = false;
            dtmNgayBD.Enabled = false;
            cboTrangThai.Enabled = false;
            tblCongNhan c = null;
            if(lvwDanhSach.SelectedItems.Count == 1)
            {
                btnXoa.Enabled = true;
                c = (tblCongNhan)lvwDanhSach.SelectedItems[0].Tag;
                CNToTextBox(c);
                btnSuaCV.Enabled = true;
                btnSuaTT.Enabled = true;
            }
            else if (lvwDanhSach.SelectedItems.Count > 1)
            {
                btnXoa.Enabled = true;
                btnSuaCV.Enabled = false;
                btnSuaTT.Enabled = false;
                txtTen.Enabled = false;
                radNam.Enabled = false;
                radNu.Enabled = false;
                dtmNS.Enabled = false;
                cboCongXuong.Enabled = false;
                cboChucVu.Enabled = false;
                dtmNgayBD.Enabled = false;
                cboTrangThai.Enabled = false;
            }
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
            c.TrangThai = cboTrangThai.Text.Trim();
            c.ChucVu = cboChucVu.SelectedItem.ToString();
            c.PhuCap = cn.GetCNByID(txtID.Text).PhuCap;
            c.IDCX = cboCongXuong.SelectedItem.ToString();
            return c;
        }
        //nút sửa thông tin
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

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            IEnumerable<tblCongNhan> c = cn.GetCNByIDCX(lblCongXuong.Text);
            lvwDanhSach.Items.Clear();
            LoadCNToListView(lvwDanhSach, c);
            btnSuaCV.Enabled = false;
            cboCongXuong.Enabled = false;
            dtmNgayBD.Enabled = false;
            cboChucVu.Enabled = false;
            btnSuaTT.Enabled = false;
            txtTen.Enabled = false;
            radNam.Enabled = false;
            radNu.Enabled = false;
            dtmNS.Enabled = false;
            btnXoa.Enabled = false;
            cboTrangThai.Enabled = false;
        }

        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            if (dtmNgayBD.Enabled == false)
            {
                tblCongNhan c = (tblCongNhan)lvwDanhSach.SelectedItems[0].Tag;
                if (c.ChucVu.Trim().Equals("quản lý"))
                    //cboChucVu.Enabled = true;
                    cboCongXuong.Enabled = false;
                else
                    cboCongXuong.Enabled = true;
                dtmNgayBD.Enabled = true;
                cboTrangThai.Enabled = true;
            }
            else
            {
                DialogResult r = MessageBox.Show("Lưu thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    btnSuaCV.Enabled = false;
                    cboCongXuong.Enabled = false;
                    cboChucVu.Enabled = false;
                    dtmNgayBD.Enabled = false;
                    cboTrangThai.Enabled = false;
                    tblCongNhan c = TaoCongNhan();
                    cn.SuaCN(c);
                }
            }
        }
        //Autocomplet
        void XuLyHoTroAutocomplete()
        {
            string strTimKiem = txtTimKiem.Text;
            IEnumerable<tblCongNhan> dsCN = cn.GetCNByIDCX(lblCongXuong.Text);// Lấy danh sách tất cả công nhân
            txtTimKiem.AutoCompleteCustomSource.Clear();
            if (cboTimKiem.SelectedIndex == 0) //Nếu chọn tìm theo ID công nhân
            {
                foreach (tblCongNhan c in dsCN)
                    txtTimKiem.AutoCompleteCustomSource.Add(c.IDCN);//Add item autocomplete vào txt tìm kiếm
            }            
            else if (cboTimKiem.SelectedIndex == 1)//Nếu chọn tìm theo họ tên
            {
                foreach (tblCongNhan c in dsCN)
                    txtTimKiem.AutoCompleteCustomSource.Add(c.HoTen);//add họ tên vào
            }
        }

        private void cboTimKiem_SelectedIndexChanged(object sender, EventArgs e)
        {
            XuLyHoTroAutocomplete();
        }

        private void tipbtnTimKiem_Click(object sender, EventArgs e)
        {
            if (cboTimKiem.SelectedIndex == 0) //Nếu chọn tìm theo ID công nhân
            {
                IEnumerable<tblCongNhan> dsCN = cn.GetCNTheoIDKhongHoanThien(txtTimKiem.Text,lblCongXuong.Text);
                lvwDanhSach.Items.Clear();
                LoadCNToListView(lvwDanhSach, dsCN);
            }
            else if (cboTimKiem.SelectedIndex == 1)//Nếu chọn tìm theo họ tên
            {
                IEnumerable<tblCongNhan> dsCN = cn.GetCNTheoTen(txtTimKiem.Text,lblCongXuong.Text);
                lvwDanhSach.Items.Clear();
                LoadCNToListView(lvwDanhSach, dsCN);
            }
            btnSuaCV.Enabled = false;
            cboCongXuong.Enabled = false;
            dtmNgayBD.Enabled = false;
            cboChucVu.Enabled = false;
            btnSuaTT.Enabled = false;
            txtTen.Enabled = false;
            radNam.Enabled = false;
            radNu.Enabled = false;
            dtmNS.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult r;
            string ID;
            int vtthuc;//biến lưu vị trí thực trong danh sách
            if (lvwDanhSach.SelectedItems.Count > 0)
            {
                r = MessageBox.Show("Bạn chắc chắn xóa?", "Thông báo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1);
                if (r == DialogResult.Yes)
                {
                    for (int i = 0; i < lvwDanhSach.SelectedItems.Count; i++)
                    {
                        vtthuc = lvwDanhSach.SelectedIndices[i];//lấy vị trí thực trong danh sách
                        string IDLay = (lvwDanhSach.Items[vtthuc].Text).ToUpper();
                        ID = lvwDanhSach.Items[vtthuc].Text;
                        cn.DeleteCongNhan(cn.GetCNByID(ID));
                        acn.DeleteAccCongNhan(acn.GetAccountCN(ID));
                        foreach (tblLuongCN luong in lcn.GetLCNThuocCN(ID))
                            lcn.DeleteLuongCongNhan(luong);
                    }
                    btnXoa.Enabled = false;
                }
                else
                    btnXoa.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemCN frm = new frmThemCN();
            frm.MessageCX = lblCongXuong.Text;
            frm.ShowDialog();
        }

        private void frmQLCN_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
