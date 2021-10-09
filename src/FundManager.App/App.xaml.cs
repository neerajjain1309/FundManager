using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FundManager.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

#if (DEBUG)
            RunInDebugMode();
#else
            RunInReleaseMode();
#endif
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }

        private static void RunInDebugMode()
        {
            var bootstrapper = new FundManagerBootstrapper();
            bootstrapper.Run();
        }

        private static void RunInReleaseMode()
        {
            AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
            try
            {
                var bootstrapper = new FundManagerBootstrapper();
                bootstrapper.Run();
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private static void HandleException(Exception ex)
        {
            if (ex == null)
                return;

            MessageBox.Show("An unhandled exception occurred, and the application is terminating");
            Environment.Exit(1);
        }
    }
}
