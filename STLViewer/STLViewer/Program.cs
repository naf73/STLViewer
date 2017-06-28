using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;

namespace STLViewer
{
    static class Program
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                bool createdNew = true;
                using (Mutex mutex = new Mutex(true, "STLViewer", out createdNew))
                {
                    if (createdNew)
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new FormMain(args));
            }
                    else
                    {
                Process current = Process.GetCurrentProcess();

                foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                {
                    if (process.Id != current.Id)
                    {
                        SetForegroundWindow(process.MainWindowHandle);
                        MessageBox.Show(FormMain.Language.Error("repeat_start_application"), "STLViewer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    }
                }
            }
        }
    }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Source + Environment.NewLine + ex.Message + Environment.NewLine + ex.StackTrace, "STLViewer", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
