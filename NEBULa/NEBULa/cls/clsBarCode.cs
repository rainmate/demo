using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NEBULa.cls
{
    class clsBarCode
    {
        public static bool CheckTxt(string source)
        {
            Regex regAll = new Regex("^H\\d{5} \\d{5}$");
            if (!regAll.IsMatch(source))
            {
                return false;
            }
            return true;
        }
    }
}
