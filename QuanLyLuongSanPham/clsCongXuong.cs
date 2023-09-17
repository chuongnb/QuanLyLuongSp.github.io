using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuongSanPham
{
    public class clsCongXuong : clsKetNoi
    {
        qlLuongSPDataContext dt;
        public clsCongXuong()
        {
            dt = getDataContext();
        }
        //lấy all công xưởng
        public IEnumerable<tblCongXuong> GetAllCongXuong()
        {
            IEnumerable<tblCongXuong> q = from n in dt.tblCongXuongs
                                          select n;
            return q;
        }
    }
}
