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
    public partial class frmQLNV : Form
    {
        public frmQLNV()
        {
            InitializeComponent();
        }
        clsAccountNV anv = new clsAccountNV();
        clsNhanVien nv = new clsNhanVien();
        clsLuongNV lnv = new clsLuongNV();
        clsPhongBan pb = new clsPhongBan();

        private string _messageID;//thêm
        public string MessageID //thêm
        {
            get { return _messageID; }
            set { _messageID = value; }
        }

        private void frmQLNV_Load(object sender, EventArgs e)
        {
            lblPhongBan.Text = nv.GetNVByID(MessageID).IDPB;//sửa
            CreateColumns(lvwDanhSach);
            IEnumerable<tblNhanVienHanhChinh> c = nv.GetNVByIDPB(lblPhongBan.Text);
            LoadNVToListView(lvwDanhSach, c);
            cboTimKiem.SelectedIndex = 0;
        }
        // Tạo cột cho lvwDanhSach
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
        //Tạo list view item NV
        ListViewItem TaoItemNV(tblNhanVienHanhChinh n)
        {
            ListViewItem lvwItem;
            lvwItem = new ListViewItem(n.IDNV);
            lvwItem.SubItems.Add(n.HoTen.Trim());
            lvwItem.SubItems.Add(n.GioiTinh.Trim());
            lvwItem.SubItems.Add(String.Format("{0:dd-MM-yyyy}", n.NgaySinh));//định dạng ngày theo dd-MM-yyyy
            lvwItem.SubItems.Add(String.Format("{0:dd-MM-yyyy}", n.NgayBatDau));
            lvwItem.SubItems.Add(n.ChucVu.Trim());
            lvwItem.SubItems.Add(n.TrangThai.Trim());
            lvwItem.Tag = n;
            return lvwItem;
        }
        //Load NV lên listview
        void LoadNVToListView(ListView lvw, IEnumerable<tblNhanVienHanhChinh> dsNV)
        {
            ListViewItem ItemNV;
            foreach (tblNhanVienHanhChinh n in dsNV)
            {
                ItemNV = TaoItemNV(n);
                lvw.Items.Add(ItemNV);
            }
        }
        //Load NV lên text box
        void NVToTextBox(tblNhanVienHanhChinh c)
        {
            txtID.Text = c.IDNV;
            txtTen.Text = c.HoTen.Trim();
            //load nam nữ
            if (c.GioiTinh.Trim().Equals("Nam"))
                radNam.Checked = true;
            else
                radNu.Checked = true;

            dtmNS.Text = c.NgaySinh.ToShortDateString();
            dtmNgayBD.Text = c.NgayBatDau.ToShortDateString();
            //load chức vụ
            if (c.ChucVu.Trim().ToUpper().Equals("NHÂN VIÊN"))
                cboChucVu.SelectedIndex = 0;
            else
                cboChucVu.SelectedIndex = 1;
            //load phòng ban
            if (c.IDPB.Trim().Equals(cboPhongBan.Items[0]))
                cboPhongBan.SelectedIndex = 0;
            else
                cboPhongBan.SelectedIndex = 1;
            txtHSL.Text = c.HeSoLuong.ToString();
            txtPC.Text = c.PhuCap.ToString();
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
            cboPhongBan.Enabled = false;
            cboChucVu.Enabled = false;
            dtmNgayBD.Enabled = false;
            txtHSL.Enabled = false;
            txtPC.Enabled = false;
            cboTrangThai.Enabled = false;
            tblNhanVienHanhChinh n = null;
            if (lvwDanhSach.SelectedItems.Count == 1)
            {
                btnXoa.Enabled = true;
                btnSuaTT.Enabled = true;
                n = (tblNhanVienHanhChinh)lvwDanhSach.SelectedItems[0].Tag;
                NVToTextBox(n);
                btnSuaCV.Enabled = true;
                btnSuaLuong.Enabled = true;
            }
            else if (lvwDanhSach.SelectedItems.Count > 1)
            {
                btnXoa.Enabled = true;
                btnSuaCV.Enabled = false;
                btnSuaTT.Enabled = false;
                btnSuaLuong.Enabled = false;
                txtTen.Enabled = false;
                radNam.Enabled = false;
                radNu.Enabled = false;
                dtmNS.Enabled = false;
                cboPhongBan.Enabled = false;
                cboChucVu.Enabled = false;
                dtmNgayBD.Enabled = false;
                txtHSL.Enabled = false;
                txtPC.Enabled = false;
                cboTrangThai.Enabled = false;
            }
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
            n.TrangThai = cboTrangThai.Text.Trim();
            n.ChucVu = cboChucVu.SelectedItem.ToString();
            n.PhuCap = Convert.ToInt32(txtPC.Text);
            n.HeSoLuong = Convert.ToInt32(txtHSL.Text);
            n.IDPB = cboPhongBan.SelectedItem.ToString();
            return n;
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
                    tblNhanVienHanhChinh n = TaoNhanVien();
                    nv.SuaNV(n);
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            IEnumerable<tblNhanVienHanhChinh> n = nv.GetNVByIDPB(lblPhongBan.Text);
            lvwDanhSach.Items.Clear();
            LoadNVToListView(lvwDanhSach, n);
            btnXoa.Enabled = false;
            btnSuaCV.Enabled = false;
            btnSuaTT.Enabled = false;
            btnSuaLuong.Enabled = false;
            txtTen.Enabled = false;
            radNam.Enabled = false;
            radNu.Enabled = false;
            dtmNS.Enabled = false;
            cboPhongBan.Enabled = false;
            cboChucVu.Enabled = false;
            dtmNgayBD.Enabled = false;
            txtHSL.Enabled = false;
            txtPC.Enabled = false;
            cboTrangThai.Enabled = false;
        }

        private void btnSuaCV_Click(object sender, EventArgs e)
        {
            if (dtmNgayBD.Enabled == false)
            {
                tblNhanVienHanhChinh n = (tblNhanVienHanhChinh)lvwDanhSach.SelectedItems[0].Tag;
                if (n.ChucVu.Trim().ToUpper().Equals("QUẢN LÝ"))
                    cboPhongBan.Enabled = false;
                else
                    cboPhongBan.Enabled = true;
                dtmNgayBD.Enabled = true;
                //cboChucVu.Enabled = true;
                cboTrangThai.Enabled = true;
            }
            else
            {
                DialogResult r = MessageBox.Show("Lưu thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    btnSuaCV.Enabled = false;
                    cboPhongBan.Enabled = false;
                    cboChucVu.Enabled = false;
                    dtmNgayBD.Enabled = false;
                    cboTrangThai.Enabled = false;
                    tblNhanVienHanhChinh n = TaoNhanVien();
                    nv.SuaNV(n);
                }
            }
        }

        private void btnSuaLuong_Click(object sender, EventArgs e)
        {
            if (txtHSL.Enabled == false)
            {
                txtHSL.Enabled = true;
                txtPC.Enabled = true;
            }
            else
            {
                DialogResult r = MessageBox.Show("Lưu thông tin?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    btnSuaLuong.Enabled = false;
                    txtHSL.Enabled = false;
                    txtPC.Enabled = false;
                    tblNhanVienHanhChinh n = TaoNhanVien();
                    nv.SuaNV(n);
                }
            }
        }
        //Autocomplet
        void XuLyHoTroAutocomplete()
        {
            string strTimKiem = txtTimKiem.Text;
            IEnumerable<tblNhanVienHanhChinh> dsNV = nv.GetNVByIDPB(lblPhongBan.Text);// Lấy danh sách tất cả công nhân
            txtTimKiem.AutoCompleteCustomSource.Clear();
            if (cboTimKiem.SelectedIndex == 0) //Nếu chọn tìm theo ID công nhân
            {
                foreach (tblNhanVienHanhChinh n in dsNV)
                    txtTimKiem.AutoCompleteCustomSource.Add(n.IDNV);//Add item autocomplete vào txt tìm kiếm
            }
            else if (cboTimKiem.SelectedIndex == 1)//Nếu chọn tìm theo họ tên
            {
                foreach (tblNhanVienHanhChinh n in dsNV)
                    txtTimKiem.AutoCompleteCustomSource.Add(n.HoTen);//add họ tên vào
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
                IEnumerable<tblNhanVienHanhChinh> dsNV = nv.GetNVTheoIDKhongHoanChinh(txtTimKiem.Text, lblPhongBan.Text);
                lvwDanhSach.Items.Clear();
                LoadNVToListView(lvwDanhSach, dsNV);
            }
            else if (cboTimKiem.SelectedIndex == 1)//Nếu chọn tìm theo họ tên
            {
                IEnumerable<tblNhanVienHanhChinh> dsNV = nv.GetNVTheoTen(txtTimKiem.Text, lblPhongBan.Text);
                lvwDanhSach.Items.Clear();
                LoadNVToListView(lvwDanhSach, dsNV);
            }
            btnXoa.Enabled = false;
            btnSuaCV.Enabled = false;
            btnSuaTT.Enabled = false;
            btnSuaLuong.Enabled = false;
            txtTen.Enabled = false;
            radNam.Enabled = false;
            radNu.Enabled = false;
            dtmNS.Enabled = false;
            cboPhongBan.Enabled = false;
            cboChucVu.Enabled = false;
            dtmNgayBD.Enabled = false;
            txtHSL.Enabled = false;
            txtPC.Enabled = false;
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
                        nv.DeleteNhanVien(nv.GetNVByID(ID));
                        anv.DeleteAccNhanVien(anv.GetAccountNV(ID));
                        foreach (tblLuongNV luong in lnv.GetLuongThuocNV(ID))
                            lnv.DeleteLuongNhanVien(luong);
                    }
                    btnXoa.Enabled = false;
                }
                else
                    btnXoa.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemNV frm = new frmThemNV();
            frm.MessagePB = lblPhongBan.Text;
            frm.ShowDialog();
        }

        private void frmQLNV_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("Bạn có chắc thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.No)
                e.Cancel = true;
        }
    }
}
