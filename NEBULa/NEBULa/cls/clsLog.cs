using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBULa.cls
{
    class clsLog
    {
        public static string writeLog(string produceName)
        {
            return "\r\n" + string.Format("[{0}]  {1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"), produceName);
        }

        public static void saveLog(string source, string file)
        {
            string str1 = "Log/" + file+ DateTime.Now.ToString("yyyyMMdd HHmmss") + ".txt";
            StreamWriter streamWriter = new StreamWriter(clsParams.WorkPath + str1, true);
            streamWriter.Write(source);
            streamWriter.Close();
        }
    }
}
