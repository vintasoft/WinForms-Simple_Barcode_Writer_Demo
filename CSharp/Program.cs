using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace SimpleBarcodeWriterDemo
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        /// <summary>
        /// Handles the UnhandledException event of the AppDomain.CurrentDomain.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            System.ComponentModel.LicenseException licenseException = GetLicenseException(e.ExceptionObject);
            if (licenseException != null)
            {
                // show information about licensing exception
                MessageBox.Show(string.Format("{0}: {1}", licenseException.GetType().Name, licenseException.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // open article with information about usage of evaluation license
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                process.StartInfo.FileName = "https://www.vintasoft.com/docs/vsbarcode-dotnet/Licensing-Barcode-Evaluation.html";
                process.StartInfo.UseShellExecute = true;
                process.Start();
            }
        }

        /// <summary>
        /// Returns the license exception from specified exception.
        /// </summary>
        /// <param name="exceptionObject">The exception object.</param>
        /// <returns>Instance of <see cref="LicenseException"/>.</returns>
        private static LicenseException GetLicenseException(object exceptionObject)
        {
            Exception ex = exceptionObject as Exception;
            if (ex == null)
                return null;
            if (ex is LicenseException)
                return (LicenseException)exceptionObject;
            if (ex.InnerException != null)
                return GetLicenseException(ex.InnerException);
            return null;
        }
    }
}
