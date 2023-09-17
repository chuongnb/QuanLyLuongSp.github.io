using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham
{
    public class clsAccountNV : clsKetNoi
    {
        qlLuongSPDataContext dt;
        public clsAccountNV()
        {
            dt = getDataContext();
        }
        //lấy account NV
        public tblAccountNV GetAccountNV(string strIDNV)
        {
            //dt = getDataContext();
            tblAccountNV q = (from n in dt.tblAccountNVs
                              where n.IDNV.Equals(strIDNV)
                              select n).FirstOrDefault();
            return q;
        }
        //Kiểm tra tồn tại account nhân viên
        public tblAccountNV CheckIfExistNV(string strIDNV)
        {
            tblAccountNV nvtemp = (from n in dt.tblAccountNVs
                                   where n.IDNV.Equals(strIDNV)//Lấy các phần tử có id = strIDNV
                                   select n).FirstOrDefault();
            if (nvtemp != null)
                return nvtemp;
            else
                return null;
        }        
        //Xóa account NV
        public int DeleteAccNhanVien(tblAccountNV anv)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistNV(anv.IDNV) != null)
                {
                    dt.tblAccountNVs.DeleteOnSubmit(anv);
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
        //Thêm account nhân viên
        public int insertAccNhanVien(tblAccountNV n)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistNV(n.IDNV) != null)
                    return 0;
                else
                {
                    dt.tblAccountNVs.InsertOnSubmit(n);
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
        //Sửa Account Nhân viên
        public bool SuaAccNV(tblAccountNV AccNVSua)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IQueryable<tblAccountNV> tam = (from n in dt.tblAccountNVs
                                                where n.IDNV.Equals(AccNVSua.IDNV)
                                                select n);
                //tam.First().STT = AccCNSua.STT;
                tam.First().IDNV = AccNVSua.IDNV;
                tam.First().PassNV = AccNVSua.PassNV;
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
