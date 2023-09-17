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
    public partial class frmPhieuLuong : Form
    {
        public frmPhieuLuong()
        {
            InitializeComponent();
        }
        public string _messageAccount;
        public string MessageAccount
        {
            get { return _messageAccount; }
            set { _messageAccount = value; }
        }
        clsNhanVien nv = new clsNhanVien();
        clsLuongNV lnv = new clsLuongNV();

        private void frmPhieuLuong_Load(object sender, EventArgs e)
        {
            lblHeader.Text = "PHIẾU LƯƠNG THÁNG"; // + (DateTime.Now.Month - 1).ToString() + "/" + (DateTime.Now.Year).ToString();
            lblID.Text = MessageAccount;
            string strThang=(DateTime.Now.Month - 2).ToString() + "/" + (DateTime.Now.Year).ToString();
            tblNhanVienHanhChinh n = nv.GetNVByID(lblID.Text);
            lblTen.Text = n.HoTen;
            lblHSL.Text = n.HeSoLuong.ToString();
            lblPC.Text = n.PhuCap.ToString();
            foreach(tblLuongNV l in lnv.GetLuongThuocNV(lblID.Text))
            {
                if (l.ThangLam.Trim().ToUpper().Equals(strThang.ToUpper()))
                {
                    lblSGL.Text = l.SoNgayLam.ToString();
                    lblTCL.Text = l.TangCaNgayLe.ToString();
                    lblTCN.Text = l.TangCaNgayNghi.ToString();
                    lblTCT.Text = l.TangCaThuong.ToString();
                }
            }
            int HSL = Convert.ToInt32(lblHSL.Text);
            int PC = Convert.ToInt32(lblPC.Text);
            int SNL = Convert.ToInt32(lblSGL.Text);
            int TCL = Convert.ToInt32(lblTCL.Text);
            int TCN = Convert.ToInt32(lblTCN.Text);
            int TCT = Convert.ToInt32(lblTCT.Text);

            double luong = Math.Round(HSL / 30 * SNL + TCL * HSL / 720 * 3 + TCN * HSL / 720 * 2 + TCT * HSL / 720 * 1.5,0);//sửa
            lblLuong.Text = luong.ToString();//sửa

            lblBHXH.Text = (Convert.ToInt32(lblLuong.Text) * 8 / 100).ToString();
            lblBHYT.Text = (Convert.ToInt32(lblLuong.Text) * 1 / 100).ToString();
            if (Convert.ToInt32(lblLuong.Text) > 11000000)
                lblThue.Text = (Convert.ToInt32(lblLuong.Text) * 10 / 100).ToString();
            else
                lblThue.Text = "0";
            lblTong.Text = (Convert.ToInt32(lblLuong.Text) - Convert.ToInt32(lblBHYT.Text) - Convert.ToInt32(lblBHXH.Text) - Convert.ToInt32(lblThue.Text)).ToString();
        }
    }
}
