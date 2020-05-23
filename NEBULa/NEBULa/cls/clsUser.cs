using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBULa.cls
{
    class clsUser
    {
        public static string useID; //编号
        public static string useName; //姓名
        public static string Password; //密码
        public static string TestDate; //测试日期


        public static void InitValue()
        {
            useID = "";
            useName = "";
            Password = "";
            TestDate = "";
        }
    }


}
