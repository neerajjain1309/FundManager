using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FundManager.App.Views;
using FundManager.Module.AddInstrument;
using FundManager.Module.Fund;
using FundManager.Module.Summary;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;

namespace FundManager.App
{
    public class FundManagerBootstrapper : UnityBootstrapper
    {
        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            var moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(AddInstrumentModule));
            moduleCatalog.AddModule(typeof(SummaryModule));
            moduleCatalog.AddModule(typeof(FundModule));
        }

        protected override DependencyObject CreateShell()
        {
            var view = Container.TryResolve<ShellView>();
            return view;
        }


    }
}
