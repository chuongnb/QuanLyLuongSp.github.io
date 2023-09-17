using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham
{
    public class clsCongNhan : clsKetNoi
    {
        qlLuongSPDataContext dt;

        // Hẳn là lấy data ra xài nhỉ :)
        public clsCongNhan()
        {
            dt = getDataContext();
        }

        // Lấy tất cả công nhân trong table CongNhan
        public IEnumerable<tblCongNhan> GetAllCongNhan()
        {
            dt = getDataContext();
            IEnumerable<tblCongNhan> q = from n in dt.tblCongNhans
                                         select n;
            return q;
        }
        // Lấy công nhân theo ID
        public tblCongNhan GetCNByID(string strIDCN)
        {
            tblCongNhan q = (from n in dt.tblCongNhans //Trong bảng nhân viên hành chính
                             where n.IDCN.Equals(strIDCN)// với điều kiện ID = ID cần lấy
                             select n).FirstOrDefault();// Lấy thằng đầu tiên đủ điều kiện
            return q;
        }
        //Lấy công nhân theo công xưởng
        public IEnumerable<tblCongNhan> GetCNByIDCX(string strIDCX)
        {
            IEnumerable<tblCongNhan> q = from n in dt.tblCongNhans
                                         where n.IDCX.Equals(strIDCX)
                                         select n;
            return q;
        }
        //Tìm kiếm công nhân theo id chứa id cần tìm
        public IEnumerable<tblCongNhan> GetCNTheoIDKhongHoanThien(string strIDTim,string strIDCX)
        {
            IEnumerable<tblCongNhan> q = from n in dt.tblCongNhans
                                         where n.IDCN.Substring(0, strIDTim.Length).Equals(strIDTim) && n.IDCX.Equals(strIDCX)
                                         select n;
            return q;
        }
        //Lấy công nhân theo tên
        public IEnumerable<tblCongNhan> GetCNTheoTen(string strTen,string strIDCX)
        {
            IEnumerable<tblCongNhan> q = from n in dt.tblCongNhans
                                         where n.HoTen.Substring(0, strTen.Length).Equals(strTen) && n.IDCX.Equals(strIDCX)
                                         select n;
            return q;
        }
        //Kiểm tra tồn tại công nhân
        public tblCongNhan CheckIfExistCN(string strIDCN)
        {
            tblCongNhan cntemp = (from n in dt.tblCongNhans
                                  where n.IDCN.Equals(strIDCN)
                                  select n).FirstOrDefault();
            if (cntemp != null)
                return cntemp;
            else
                return null;
        }

        //Xóa công nhân
        public int DeleteCongNhan(tblCongNhan cn)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistCN(cn.IDCN) != null)
                {
                    dt.tblCongNhans.DeleteOnSubmit(cn);//xóa cn trong table cong nhan
                    dt.SubmitChanges();//submit sửa database
                    dt.Transaction.Commit();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không xóa được " + ex.Message);
            }
        }

        //Sửa công nhân
        public bool SuaCN(tblCongNhan cnSua)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                tblCongNhan tam = (from n in dt.tblCongNhans
                                   where n.IDCN.Equals(cnSua.IDCN)
                                   select n).First();
                //tam.First().IDCN = cnSua.IDCN;
                tam.HoTen = cnSua.HoTen;
                tam.GioiTinh = cnSua.GioiTinh;
                tam.NgaySinh = cnSua.NgaySinh;
                tam.NgayBatDau = cnSua.NgayBatDau;
                tam.TrangThai = cnSua.TrangThai;
                tam.ChucVu = cnSua.ChucVu;
                tam.PhuCap = cnSua.PhuCap;
                tam.IDCX = cnSua.IDCX;
                dt.SubmitChanges();//sửa database
                dt.Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không sữa được " + ex.Message);
            }
        }

        //Thêm công nhân
        public int insertCongNhan(tblCongNhan n)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistCN(n.IDCN) != null)
                    return 0;
                else
                {
                    dt.tblCongNhans.InsertOnSubmit(n);//thêm công nhân vào table cong nhan
                    dt.SubmitChanges();//submit thay đổi
                    dt.Transaction.Commit();
                    return 1;
                }
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không thêm được " + ex.Message);
            }
        }
    }
}
