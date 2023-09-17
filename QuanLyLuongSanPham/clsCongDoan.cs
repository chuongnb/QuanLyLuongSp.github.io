using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham
{
    public class clsCongDoan : clsKetNoi
    {
        qlLuongSPDataContext dt;
        public clsCongDoan()
        {
            dt = getDataContext();
        }
        //lấy công đoạn
        public tblCongDoan GetCongDoan(string strIDCD)
        {
            //dt = getDataContext();
            tblCongDoan q = (from n in dt.tblCongDoans
                              where n.IDCD.Equals(strIDCD)
                              select n).FirstOrDefault();
            return q;
        }
    }
}
