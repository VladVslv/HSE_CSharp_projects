using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad_
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex1)
            {
                try
                {
                    MessageBox.Show(ex1.Message + "\n\nВсе настройки были сброшены.");
                    MySettings.Default.Reset();
                    if (Directory.Exists("VersionsOFFiles"))
                    {
                        (new DirectoryInfo("VersionsOFFiles")).Delete(true);
                    }
                    Application.Run(new MainForm());
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(ex2.Message+"\n\nНепредвиденная ошибка.");
                }
            }
        }
    }
}
