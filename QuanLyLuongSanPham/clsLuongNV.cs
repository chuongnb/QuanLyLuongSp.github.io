using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham
{
    public class clsLuongNV : clsKetNoi
    {
        qlLuongSPDataContext dt;

        // Hẳn là lấy data ra xài nhỉ :)
        public clsLuongNV()
        {
            dt = getDataContext();
        }

        public IEnumerable<tblLuongNV> GetLNV()
        {
            IEnumerable<tblLuongNV> q = from n in dt.tblLuongNVs
                                        select n;
            return q;
        }
        //lấy lương theo stt
        public tblLuongNV GetLuongNVTheoSTT(string strSTT)
        {
            tblLuongNV q = (from n in dt.tblLuongNVs //trong bảng lương nhân viên
                            where n.STT.Equals(strSTT)
                            select n).First();
            return q;
        }
        //lấy lương nv
        public IEnumerable<tblLuongNV> GetLuongNVTheoThang(string strThang)
        {
            IEnumerable<tblLuongNV> q = from n in dt.tblLuongNVs //trong bảng lương nhân viên
                                        where n.ThangLam.Trim().Equals(strThang)
                                        select n;
            return q;
        }
        public tblLuongNV GetLuongNVTheoID(string strID)
        {
            tblLuongNV q = (from n in dt.tblLuongNVs //trong bảng lương nhân viên
                            where n.IDNV.Trim().ToUpper().Equals(strID)
                            select n).First();
            return q;
        }
        // Lấy lương HC thuộc nhân viên
        public IEnumerable<tblLuongNV> GetLuongThuocNV(string strIDNV)
        {
            //dt = getDataContext();
            IEnumerable<tblLuongNV> q = from n in dt.tblLuongNVs //trong bảng lương nhân viên
                                        where n.IDNV.Equals(strIDNV)//với id = id cần lấy thông tin
                                        select n;
            return q;
        }
        //Kiểm tra tồn tại lương nhân viên
        public tblLuongNV CheckIfExistNV(string strIDNV)
        {
            tblLuongNV nvtemp = (from n in dt.tblLuongNVs
                                 where n.IDNV.Equals(strIDNV)//Lấy các phần tử có id = strIDNV
                                 select n).FirstOrDefault();
            if (nvtemp != null)
                return nvtemp;
            else
                return null;
        }
        //Xóa lương nhân viên
        public int DeleteLuongNhanVien(tblLuongNV lnv)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistNV(lnv.IDNV) != null)
                {
                    dt.tblLuongNVs.DeleteOnSubmit(lnv);
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
                //return -1;
            }
        }
        public tblLuongNV CheckIfExistSTT(string strSTT)
        {
            tblLuongNV nvtemp = (from n in dt.tblLuongNVs
                                 where n.STT.Equals(strSTT)//Lấy các phần tử có id = strIDNV
                                 select n).FirstOrDefault();
            if (nvtemp != null)
                return nvtemp;
            else
                return null;
        }
        //Thêm lương nhân viên
        public int insertLuongNhanVien(tblLuongNV n)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                if (CheckIfExistNV(n.STT) != null)
                    return 0;
                else
                {
                    dt.tblLuongNVs.InsertOnSubmit(n);
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
        public bool SuaLuongNV(tblLuongNV nvSua)
        {
            System.Data.Common.DbTransaction myTran = dt.Connection.BeginTransaction();
            try
            {
                dt.Transaction = myTran;
                IQueryable<tblLuongNV> tam = (from n in dt.tblLuongNVs
                                              where n.STT.Equals(nvSua.STT)
                                              select n);
                tam.First().IDNV = nvSua.IDNV;
                tam.First().SoNgayLam = nvSua.SoNgayLam;
                tam.First().ThangLam = nvSua.ThangLam;
                tam.First().TangCaNgayLe = nvSua.TangCaNgayLe;
                tam.First().TangCaNgayNghi = nvSua.TangCaNgayNghi;
                tam.First().TangCaThuong = nvSua.TangCaThuong;
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
