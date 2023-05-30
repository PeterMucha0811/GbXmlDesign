using GbXmlDesign.Presentation.Modules.VentCalc.ViewModels;
using GbXmlDesign.Presentation.Modules.VentCalc.Views;
using GbXmlDesign.Shared.Constants;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;


namespace GbXmlDesign.Presentation.Modules.VentCalc
{
    public class VentCalcModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public VentCalcModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.VentCalcView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<VentCalcView, VentCalcViewModel>();

        }
    }
}