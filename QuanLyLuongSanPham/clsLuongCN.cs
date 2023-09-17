using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham
{
    public class clsLuongCN : clsKetNoi
    {
        qlLuongSPDataContext dt;
        public clsLuongCN()
        {
            dt = getDataContext();
        }

        public IEnumerable<tblLuongCN> GetLCNThuocCN(string strIDCN)
        {
            // dt = getDataContext();
            IEnumerable<tblLuongCN> q = from n in dt.tblLuongCNs
                                        where n.IDCN.Equals(strIDCN)
                                        select n;
            return q;
        }
        public IEnumerable<tblLuongCN> GetLCNTheoCa26(string strCa, string strID)
        {
            IEnumerable<tblLuongCN> q = from n in dt.tblLuongCNs
                                        where n.Ca.Trim().Equals(strCa) && (n.NgayLam.Value.DayOfWeek != DayOfWeek.Saturday)
                                        && (n.NgayLam.Value.DayOfWeek != DayOfWeek.Sunday)
                                        && (n.IDCN.ToUpper().Equals(strID))
                                        select n;
            return q;
        }
        public IEnumerable<tblLuongCN> GetLCNTheo78(string strID)
        {
            IEnumerable<tblLuongCN> q = from n in dt.tblLuongCNs
                                        where ((n.NgayLam.Value.DayOfWeek == DayOfWeek.Saturday)
                                        || (n.NgayLam.Value.DayOfWeek == DayOfWeek.Sunday))
                                        && (n.IDCN.ToUpper().Equals(strID))
                                        select n;
            return q;
        }
        public tblLuongCN GetLCNThuocSTT(string strSTT)
        {
            // dt = getDataContext();
            tblLuongCN q = (from n in dt.tblLuongCNs
                            where n.STT.Equals(strSTT)
                            select n).First();
            return q;
        }
        public IEnumerable<tblLuongCN> GetLCN()
        {
            // dt = getDataContext();
            IEnumerable<tblLuongCN> q = from n in dt.tblLuongCNs
                                        select n;
            return q;
        }
        //Kiểm tra tồn tại lương nhân viên
        public tblLuongCN CheckIfExistCN(string strIDCN)
        {
            tblLuongCN nvtemp = (from n in dt.tblLuongCNs
                                 where n.IDCN.Equals(strIDCN)//Lấy các phần tử có id = strIDNV
                                 select n).FirstOrDefault();
            if (nvtemp != null)
                return nvtemp;
            else
                return null;
        }
        //Xóa lương công nhân
        public int DeleteLuongCongNhan(tblLuongCN lcn)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistCN(lcn.IDCN) != null)
                {
                    dt.tblLuongCNs.DeleteOnSubmit(lcn);
                    dt.SubmitChanges();
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
        //Kiểm tra tồn tại lương nhân viên
        public tblLuongCN CheckIfExistSTT(string strSTT)
        {
            tblLuongCN nvtemp = (from n in dt.tblLuongCNs
                                 where n.STT.Equals(strSTT)//Lấy các phần tử có id = strIDNV
                                 select n).FirstOrDefault();
            if (nvtemp != null)
                return nvtemp;
            else
                return null;
        }
        //Thêm lương công nhân
        public int insertLuongCongNhan(tblLuongCN n)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistCN(n.STT) != null)
                    return 0;
                else
                {
                    dt.tblLuongCNs.InsertOnSubmit(n);
                    dt.SubmitChanges();
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
        //Sửa lương Nhân viên
        public bool SuaLuongCN(tblLuongCN cnSua)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IQueryable<tblLuongCN> tam = (from n in dt.tblLuongCNs
                                              where n.STT.Equals(cnSua.STT)
                                              select n);
                tam.First().IDCN = cnSua.IDCN;
                tam.First().IDCD = cnSua.IDCD;
                tam.First().SoLuong = cnSua.SoLuong;
                tam.First().Ca = cnSua.Ca;
                tam.First().NgayLam = cnSua.NgayLam;
                dt.SubmitChanges();
                dt.Transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                throw new Exception("Lỗi không sữa được " + ex.Message);
            }
        }
    }
}
