using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEBULa.cls
{
    class clsMfgTool
    {
        public static void startMfgTool(string FullPath)
        {
            System.Diagnostics.Process.Start(@FullPath);
        }
    }
}
