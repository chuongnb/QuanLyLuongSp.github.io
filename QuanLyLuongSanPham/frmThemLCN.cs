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
    public partial class frmThemLCN : Form
    {
        public frmThemLCN()
        {
            InitializeComponent();
        }
        clsCongNhan cn = new clsCongNhan();
        clsLuongCN lcn = new clsLuongCN();
        //Autocomplet
        void XuLyHoTroAutocomplete()
        {
            IEnumerable<tblCongNhan> dsCN = cn.GetAllCongNhan();
            txtID.AutoCompleteCustomSource.Clear();
            foreach (tblCongNhan c in dsCN)
                txtID.AutoCompleteCustomSource.Add(c.IDCN);//Add item autocomplete vào txt tìm kiếm
        }

        private void frmThemLCN_Load(object sender, EventArgs e)
        {
            XuLyHoTroAutocomplete();
            lblSTT.Text = (lcn.GetLCN().Count()+1).ToString();
            dtmNgayLam.Text = (DateTime.Now.Day - 1 + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year);
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.Text.Count() == 5)
            {
                tblCongNhan c = cn.GetCNByID(txtID.Text);
                txtTen.Text = c.HoTen;
                txtPhuCap.Text = c.PhuCap.ToString();
            }
        }
        tblLuongCN TaoLCN()
        {
            tblLuongCN l = new tblLuongCN();
            l.STT = lblSTT.Text.Trim();
            l.IDCN = txtID.Text;
            l.IDCD = cboCongDoan.Text;
            l.NgayLam = Convert.ToDateTime(dtmNgayLam.Text);
            if (txtSoLuong.Text != "")
                l.SoLuong = Convert.ToInt32(txtSoLuong.Text);
            else
                l.SoLuong = 0;
            l.Ca = cboCa.Text;
            return l;
        }

        private void btnOK_Click(object sender, EventArgs e)
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
                    r = MessageBox.Show("Thêm?", "Thông báo",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)//nếu yes
                    {
                        tblLuongCN l = TaoLCN();//tạo item 
                        lcn.insertLuongCongNhan(l);
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
