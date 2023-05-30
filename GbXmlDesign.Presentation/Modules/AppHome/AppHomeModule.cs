using GbXmlDesign.Presentation.Modules.AppHome.ViewModels;
using GbXmlDesign.Presentation.Modules.AppHome.Views;
using GbXmlDesign.Presentation.Modules.AppHome.Views.Menus;
using GbXmlDesign.Shared.Constants;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;


namespace GbXmlDesign.Presentation.Modules.AppHome
{
    public class AppHomeModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public AppHomeModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.AppHomeView);
            _regionManager.RequestNavigate(RegionNames.LeftTabRegion, ViewNames.AppHomeMenuView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AppHomeView, AppHomeViewModel>();
            containerRegistry.RegisterForNavigation<AppHomeMenuView, AppHomeMenuViewModel>();

        }
    }
}
