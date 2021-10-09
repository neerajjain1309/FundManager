using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundManager.Domain;
using FundManager.Infrastructure;
using FundManager.Module.AddInstrument.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace FundManager.Module.AddInstrument
{
    public class AddInstrumentModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;


        public AddInstrumentModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _regionManager.RegisterViewWithRegion(RegionNames.TopRegion, () => _container.Resolve<AddInstrumentView>());

        }
    }
}
