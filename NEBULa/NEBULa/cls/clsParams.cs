using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBULa.cls
{
    class clsParams
    {
        public static string Title;      //软件名称
        public static string BroadDesc;      //板子测试项指标名称
        public static string WorkPath;     //工作路径

        public static int portNo;     //
        public static int InitValueBroad;     //板子元件检测延时

        public static void InitValue()
        {
            Title = ConfigurationManager.AppSettings.Get("title");
            BroadDesc = ConfigurationManager.AppSettings.Get("BroadDesc");

            WorkPath = System.AppDomain.CurrentDomain.BaseDirectory.Replace("\\", "/");

            string str1 = ConfigurationManager.AppSettings.Get("portNo");
            portNo = Convert.ToInt32(str1);
            
            str1 = ConfigurationManager.AppSettings.Get("InitValueBroad");
            InitValueBroad = Convert.ToInt32(str1);

            clsSqlite.dataBasePath = clsParams.WorkPath + "db/tester_result.sqlite";
        }



    }
}
