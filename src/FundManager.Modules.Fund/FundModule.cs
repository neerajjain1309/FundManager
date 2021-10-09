using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundManager.Domain;
using FundManager.Domain.Interfaces;
using FundManager.Infrastructure;
using FundManager.Module.Fund.Views;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace FundManager.Module.Fund
{
    public class FundModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;


        public FundModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterInstance<IInstrumentFactory>(new InstrumentFactory());
            _regionManager.RegisterViewWithRegion(RegionNames.MainRegion, () => _container.Resolve<FundView>());
            
        }
    }
}
