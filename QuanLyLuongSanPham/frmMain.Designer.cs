namespace QuanLyLuongSanPham
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.mnuMainHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainHeThongThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainChucNang = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainChucNangTinhLuong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainNhanSu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainNhanSuQuanLyNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainNhanSuQuanLyCongNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainNguoiDung = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainNguoiDungQLTK = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMainHeThongDoiMK = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblTaiKhoan = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblQuyen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblPhienLamViec = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.mnuMain.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Font = new System.Drawing.Font("Arial", 10F);
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainHeThong,
            this.mnuMainChucNang,
            this.mnuMainNhanSu,
            this.mnuMainNguoiDung});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.mnuMain.Size = new System.Drawing.Size(971, 24);
            this.mnuMain.TabIndex = 2;
            this.mnuMain.Text = "menuStrip1";
            // 
            // mnuMainHeThong
            // 
            this.mnuMainHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainHeThongThoat});
            this.mnuMainHeThong.Image = global::QuanLyLuongSanPham.Properties.Resources.tải_xuống;
            this.mnuMainHeThong.Name = "mnuMainHeThong";
            this.mnuMainHeThong.Size = new System.Drawing.Size(93, 20);
            this.mnuMainHeThong.Text = "Hệ thống";
            // 
            // mnuMainHeThongThoat
            // 
            this.mnuMainHeThongThoat.Image = global::QuanLyLuongSanPham.Properties.Resources.istockphoto_518467688_1024x1024;
            this.mnuMainHeThongThoat.Name = "mnuMainHeThongThoat";
            this.mnuMainHeThongThoat.Size = new System.Drawing.Size(113, 22);
            this.mnuMainHeThongThoat.Text = "Thoát";
            this.mnuMainHeThongThoat.Click += new System.EventHandler(this.mnuMainHeThongThoat_Click);
            // 
            // mnuMainChucNang
            // 
            this.mnuMainChucNang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainChucNangTinhLuong});
            this.mnuMainChucNang.Image = global::QuanLyLuongSanPham.Properties.Resources._3592847_general_office_repair_repair_tool_screwdriver_tools_wrench_107766;
            this.mnuMainChucNang.Name = "mnuMainChucNang";
            this.mnuMainChucNang.Size = new System.Drawing.Size(106, 20);
            this.mnuMainChucNang.Text = "Chức năng";
            // 
            // mnuMainChucNangTinhLuong
            // 
            this.mnuMainChucNangTinhLuong.Image = global::QuanLyLuongSanPham.Properties.Resources.images;
            this.mnuMainChucNangTinhLuong.Name = "mnuMainChucNangTinhLuong";
            this.mnuMainChucNangTinhLuong.Size = new System.Drawing.Size(146, 22);
            this.mnuMainChucNangTinhLuong.Text = "Tính lương";
            this.mnuMainChucNangTinhLuong.Click += new System.EventHandler(this.mnuMainChucNangTinhLuong_Click);
            // 
            // mnuMainNhanSu
            // 
            this.mnuMainNhanSu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainNhanSuQuanLyNhanVien,
            this.mnuMainNhanSuQuanLyCongNhan});
            this.mnuMainNhanSu.Image = global::QuanLyLuongSanPham.Properties.Resources.members_icon_898594396;
            this.mnuMainNhanSu.Name = "mnuMainNhanSu";
            this.mnuMainNhanSu.Size = new System.Drawing.Size(89, 20);
            this.mnuMainNhanSu.Text = "Nhân sự";
            // 
            // mnuMainNhanSuQuanLyNhanVien
            // 
            this.mnuMainNhanSuQuanLyNhanVien.Image = global::QuanLyLuongSanPham.Properties.Resources.bootloader_users_person_people_60801;
            this.mnuMainNhanSuQuanLyNhanVien.Name = "mnuMainNhanSuQuanLyNhanVien";
            this.mnuMainNhanSuQuanLyNhanVien.Size = new System.Drawing.Size(196, 22);
            this.mnuMainNhanSuQuanLyNhanVien.Text = "Quản lý nhân viên";
            this.mnuMainNhanSuQuanLyNhanVien.Click += new System.EventHandler(this.mnuMainNhanSuQuanLyNhanVien_Click);
            // 
            // mnuMainNhanSuQuanLyCongNhan
            // 
            this.mnuMainNhanSuQuanLyCongNhan.Image = global::QuanLyLuongSanPham.Properties.Resources.engineer_vector_icon_png_247858;
            this.mnuMainNhanSuQuanLyCongNhan.Name = "mnuMainNhanSuQuanLyCongNhan";
            this.mnuMainNhanSuQuanLyCongNhan.Size = new System.Drawing.Size(196, 22);
            this.mnuMainNhanSuQuanLyCongNhan.Text = "Quản lý công nhân";
            this.mnuMainNhanSuQuanLyCongNhan.Click += new System.EventHandler(this.mnuMainNhanSuQuanLyCongNhan_Click);
            // 
            // mnuMainNguoiDung
            // 
            this.mnuMainNguoiDung.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMainNguoiDungQLTK,
            this.mnuMainHeThongDoiMK});
            this.mnuMainNguoiDung.Image = global::QuanLyLuongSanPham.Properties.Resources.Profile;
            this.mnuMainNguoiDung.Name = "mnuMainNguoiDung";
            this.mnuMainNguoiDung.Size = new System.Drawing.Size(110, 20);
            this.mnuMainNguoiDung.Text = "Người dùng";
            // 
            // mnuMainNguoiDungQLTK
            // 
            this.mnuMainNguoiDungQLTK.Image = global::QuanLyLuongSanPham.Properties.Resources._1024px_User_icon_2_svg;
            this.mnuMainNguoiDungQLTK.Name = "mnuMainNguoiDungQLTK";
            this.mnuMainNguoiDungQLTK.Size = new System.Drawing.Size(187, 22);
            this.mnuMainNguoiDungQLTK.Text = "Quản lý tài khoản";
            this.mnuMainNguoiDungQLTK.Click += new System.EventHandler(this.mnuMainNguoiDungQLTK_Click);
            // 
            // mnuMainHeThongDoiMK
            // 
            this.mnuMainHeThongDoiMK.Image = global::QuanLyLuongSanPham.Properties.Resources._1269515091_keepassx1;
            this.mnuMainHeThongDoiMK.Name = "mnuMainHeThongDoiMK";
            this.mnuMainHeThongDoiMK.Size = new System.Drawing.Size(187, 22);
            this.mnuMainHeThongDoiMK.Text = "Đổi mật khẩu";
            this.mnuMainHeThongDoiMK.Click += new System.EventHandler(this.mnuMainHeThongDoiMK_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(971, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblTaiKhoan,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel8,
            this.lblID,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel7,
            this.lblQuyen,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel4,
            this.lblPhienLamViec,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 524);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(971, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(56, 17);
            this.toolStripStatusLabel1.Text = "Xin chào:";
            // 
            // lblTaiKhoan
            // 
            this.lblTaiKhoan.ForeColor = System.Drawing.Color.Red;
            this.lblTaiKhoan.Name = "lblTaiKhoan";
            this.lblTaiKhoan.Size = new System.Drawing.Size(22, 17);
            this.lblTaiKhoan.Text = "???";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel9.Text = "|";
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(21, 17);
            this.toolStripStatusLabel8.Text = "ID:";
            // 
            // lblID
            // 
            this.lblID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(22, 17);
            this.lblID.Text = "???";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(45, 17);
            this.toolStripStatusLabel7.Text = "Quyền:";
            // 
            // lblQuyen
            // 
            this.lblQuyen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Size = new System.Drawing.Size(22, 17);
            this.lblQuyen.Text = "???";
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel6.Text = "|";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(87, 17);
            this.toolStripStatusLabel4.Text = "Phiên làm việc:";
            // 
            // lblPhienLamViec
            // 
            this.lblPhienLamViec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblPhienLamViec.Name = "lblPhienLamViec";
            this.lblPhienLamViec.Size = new System.Drawing.Size(65, 17);
            this.lblPhienLamViec.Text = "07/11/2021";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(10, 17);
            this.toolStripStatusLabel2.Text = "|";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(228, 17);
            this.toolStripStatusLabel5.Text = "Phần mềm quản lý lương sản phẩm - v1.0";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(971, 546);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý lương sản phẩm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem mnuMainHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuMainHeThongThoat;
        private System.Windows.Forms.ToolStripMenuItem mnuMainChucNang;
        private System.Windows.Forms.ToolStripMenuItem mnuMainNhanSu;
        private System.Windows.Forms.ToolStripMenuItem mnuMainNguoiDung;
        private System.Windows.Forms.ToolStripMenuItem mnuMainChucNangTinhLuong;
        private System.Windows.Forms.ToolStripMenuItem mnuMainNhanSuQuanLyNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mnuMainNguoiDungQLTK;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        public System.Windows.Forms.ToolStripStatusLabel lblTaiKhoan;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        public System.Windows.Forms.ToolStripStatusLabel lblQuyen;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        public System.Windows.Forms.ToolStripStatusLabel lblPhienLamViec;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolStripMenuItem mnuMainNhanSuQuanLyCongNhan;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.ToolStripStatusLabel lblID;
        private System.Windows.Forms.ToolStripMenuItem mnuMainHeThongDoiMK;
    }
}

