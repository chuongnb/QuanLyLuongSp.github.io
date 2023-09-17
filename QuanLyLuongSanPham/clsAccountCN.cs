using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham
{
    public class clsAccountCN : clsKetNoi
    {
        qlLuongSPDataContext dt;
        public clsAccountCN()
        {
            dt = getDataContext();
        }
        //lấy account CN
        public tblAccountCN GetAccountCN(string strIDCN)
        {
            // dt = getDataContext();
            tblAccountCN q = (from n in dt.tblAccountCNs
                              where n.IDCN.Equals(strIDCN)
                              select n).FirstOrDefault();
            return q;
        }
        //Kiểm tra tồn tại account công nhân
        public tblAccountCN CheckIfExistCN(string strIDCN)
        {
            tblAccountCN nvtemp = (from n in dt.tblAccountCNs
                                   where n.IDCN.Equals(strIDCN)//Lấy các phần tử có id = strIDNV
                                   select n).FirstOrDefault();
            if (nvtemp != null)
                return nvtemp;
            else
                return null;
        }
        //Xóa account CN
        public int DeleteAccCongNhan(tblAccountCN acn)
        {
            // dt = getDataContext();
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistCN(acn.IDCN) != null)
                {
                    dt.tblAccountCNs.DeleteOnSubmit(acn);
                    dt.SubmitChanges();
                    dt.Transaction.Commit();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                dt.Transaction.Rollback();
                //throw new Exception("Lỗi không xóa được " + ex.Message);
                return -1;
            }
        }       
        //Thêm account công nhân
        public int insertAccCongNhan(tblAccountCN n)
        {
            // dt = getDataContext();
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistCN(n.IDCN) != null)
                    return 0;
                else
                {
                    dt.tblAccountCNs.InsertOnSubmit(n);
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
        //Sửa Account công nhân
        public bool SuaAccCN(tblAccountCN AccCNSua)
        {
            // dt = getDataContext();
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IQueryable<tblAccountCN> tam = (from n in dt.tblAccountCNs
                                                where n.IDCN.Equals(AccCNSua.IDCN)
                                                select n);
                //tam.First().STT = AccCNSua.STT;
                tam.First().IDCN = AccCNSua.IDCN;
                tam.First().PassCN = AccCNSua.PassCN;
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
