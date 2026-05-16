using s3molib;
using System.Diagnostics;

namespace s3mo
{
    internal static class Program
    {
        public const string Version = "0";
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "s3mo.log");

            TextWriter tw = TextWriter.Synchronized(new StreamWriter(logPath) { AutoFlush = true });

            Logger.InfoLoggedEvent += s => tw.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s);
            Logger.DebugLoggedEvent += s => tw.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s);
            Logger.WarningLoggedEvent += s => tw.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s);
            Logger.ErrorLoggedEvent += s => tw.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s);

            string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "s3mo.ini");
            if (!File.Exists(iniPath))
                Application.Run(new StartupForm());

            Settings.ReadSettings();

            Application.Run(new MainForm());

            Settings.WriteSettings();
        }

    }
}