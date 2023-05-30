using GbXmlDesign.Presentation.Modules.LoadCalc.ViewModels;
using GbXmlDesign.Presentation.Modules.LoadCalc.Views;
using GbXmlDesign.Shared.Constants;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;


namespace GbXmlDesign.Presentation.Modules.LoadCalc
{
    public class LoadCalcModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public LoadCalcModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.LoadCalcView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<LoadCalcView, LoadCalcViewModel>();

        }
    }
}