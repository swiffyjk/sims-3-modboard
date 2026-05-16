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
            StreamWriter w = new StreamWriter(logPath);
            Logger.InfoLoggedEvent += s => w.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s); w.Flush(); w.BaseStream.Flush();
            Logger.DebugLoggedEvent += s => w.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s); w.Flush(); w.BaseStream.Flush();
            Logger.WarningLoggedEvent += s => w.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s); w.Flush(); w.BaseStream.Flush();
            Logger.ErrorLoggedEvent += s => w.WriteLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + s); w.Flush(); w.BaseStream.Flush();

            string iniPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "s3mo.ini");
            if (!File.Exists(iniPath))
                Application.Run(new StartupForm());

            Settings.ReadSettings();

            Application.Run(new MainForm());

            Settings.WriteSettings();

            w.Flush();
            w.BaseStream.Close();
        }

    }
}