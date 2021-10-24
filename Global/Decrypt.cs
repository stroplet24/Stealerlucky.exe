using Ionic.Zlib;
using System;
using System.IO;

namespace GetLucky
{
    class Decrypt
    {
        public static string Get(string str)
        {
            var value = Convert.FromBase64String(str);
            string resultString = string.Empty;
            if (value != null && value.Length > 0)
            {
                using (MemoryStream stream = new MemoryStream(value))
                using (GZipStream zip = new GZipStream(stream, CompressionMode.Decompress))
                using (StreamReader reader = new StreamReader(zip))
                {
                    resultString = reader.ReadToEnd();
                }
            }
            return resultString;
        }
    }
}
