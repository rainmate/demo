using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBULa.cls
{
    class clsDataAdapter
    {
        public static DataTable IMX_Element(List<string> lstHeader, List<string> lstValue)
        {
            DataTable dt = new DataTable();
            foreach (string item in lstHeader)
            {
                if ("结果" == item)
                {
                    dt.Columns.Add(item, typeof(byte[]));
                }
                else
                {
                    dt.Columns.Add(item, typeof(string));
                }

            }
            foreach (string item in lstValue)
            {
                dt.Rows.Add(item, item + "测试", item, File.ReadAllBytes(@clsParams.WorkPath + "res/no.jpg"), item, "", "");

            }
            return dt;
        }
    }
}
