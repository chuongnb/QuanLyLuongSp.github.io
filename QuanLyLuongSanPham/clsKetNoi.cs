using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuongSanPham
{
    public class clsKetNoi
    {
        qlLuongSPDataContext dt;
        public qlLuongSPDataContext getDataContext()
        {
            string conect = SystemInformation.UserDomainName.ToString();//lấy data source
            string source = @"Data Source=" + conect + ";Initial Catalog=QLLuongSP;Integrated Security=True";
            // string str = @"Data Source=f1;Initial Catalog=QLLuongSP;Integrated Security=True";
            dt = new qlLuongSPDataContext(source);
            dt.Connection.Open();
            return dt;
        }
    }
}
