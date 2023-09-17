using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace QuanLyLuongSanPham
{
    public static class clsCheck
    {
        public static Boolean IDNVCheck(this String s)
        {
            return Regex.Match(s, @"^([Nn][Vv][0-9][0-9][0-9])$").Success;
        }
        public static Boolean IDCNCheck(this String s)
        {
            return Regex.Match(s, @"^([Cc][nN][0-9][0-9][0-9])$").Success;
        }
    }
}
