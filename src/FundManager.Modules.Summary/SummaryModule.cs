using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FundManager.Domain;
using FundManager.Domain.Interfaces;
using FundManager.Infrastructure;
using FundManager.Module.Summary.View;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace FundManager.Module.Summary
{
    public class SummaryModule : IModule
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;


        public SummaryModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterInstance<IInstrumentSummaryFactory>(new InstrumentSummaryFactory());
            _regionManager.RegisterViewWithRegion(RegionNames.SummaryRegion, () => _container.Resolve<SummaryView>());
        }
    }
}
