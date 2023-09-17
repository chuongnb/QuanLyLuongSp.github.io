using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham
{
    public class clsPhongBan : clsKetNoi
    {
        qlLuongSPDataContext dt;
        public clsPhongBan()
        {
            dt = getDataContext();
        }
        public IEnumerable<tblPhongBan> GetAllPhongBan()
        {
            IEnumerable<tblPhongBan> q = from n in dt.tblPhongBans
                                         select n;
            return q;
        }
    }
}
