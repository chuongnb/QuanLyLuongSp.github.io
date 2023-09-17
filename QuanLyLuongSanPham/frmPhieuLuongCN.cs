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
    public partial class frmPhieuLuongCN : Form
    {
        public frmPhieuLuongCN()
        {
            InitializeComponent();
        }
        public string _messageAccount;

        public string MessageAccount
        {
            get { return _messageAccount; }
            set { _messageAccount = value; }
        }
        clsCongNhan cn = new clsCongNhan();
        clsLuongCN lcn = new clsLuongCN();
        clsCongDoan cd = new clsCongDoan();
        private void frmPhieuLuongCN_Load(object sender, EventArgs e)
        {
            lblID.Text = MessageAccount;
            tblCongNhan c = cn.GetCNByID(lblID.Text);
            lblTen.Text = c.HoTen;
            int ca1 = 0;
            int ca2 = 0;
            int ca3 = 0;
            int caCT = 0;
            foreach (tblLuongCN l in lcn.GetLCNTheoCa26("1",lblID.Text))
                ca1 += Convert.ToInt32(l.SoLuong);
            foreach (tblLuongCN l in lcn.GetLCNTheoCa26("2",lblID.Text))
                ca2 += Convert.ToInt32(l.SoLuong);
            foreach (tblLuongCN l in lcn.GetLCNTheoCa26("3",lblID.Text))
                ca3 += Convert.ToInt32(l.SoLuong);
            foreach (tblLuongCN l in lcn.GetLCNTheo78(lblID.Text))
                caCT += Convert.ToInt32(l.SoLuong);
            lblCa1.Text = ca1.ToString();
            lblCa2.Text = ca2.ToString();
            lblCa3.Text = ca3.ToString();
            lblCaCT.Text = caCT.ToString();
            int luongcb = 0;
            foreach(tblLuongCN l in lcn.GetLCNThuocCN(lblID.Text))
            {
                int lcd = cd.GetCongDoan(l.IDCD).LuongCD;
                luongcb += Convert.ToInt32(l.SoLuong) * lcd;

                if (l.NgayLam.Value.DayOfWeek == DayOfWeek.Saturday || l.NgayLam.Value.DayOfWeek == DayOfWeek.Sunday)
                    luongcb += (Convert.ToInt32(l.SoLuong) * lcd *2);
                else if (l.Ca == "3")
                    luongcb += (Convert.ToInt32(l.SoLuong) * lcd * 130 / 100);
                else
                    luongcb += (Convert.ToInt32(l.SoLuong) * lcd);
            }
            lblLuong.Text = (luongcb/2).ToString();
            lblBHXH.Text = (Convert.ToInt32(lblLuong.Text) * 8 / 100).ToString();
            lblBHYT.Text = (Convert.ToInt32(lblLuong.Text) * 1 / 100).ToString();
            if (luongcb >= 11000000)
                lblThue.Text = (luongcb * 10 / 100).ToString();
            else
                lblThue.Text = "0";
            lblTong.Text = (Convert.ToInt32(lblLuong.Text) - Convert.ToInt32(lblBHXH.Text) - Convert.ToInt32(lblBHYT.Text) - Convert.ToInt32(lblThue.Text)).ToString();
        }
    }
}
