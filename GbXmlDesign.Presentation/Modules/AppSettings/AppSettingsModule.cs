using GbXmlDesign.Presentation.Modules.AppSettings.ViewModels;
using GbXmlDesign.Presentation.Modules.AppSettings.Views;
using GbXmlDesign.Shared.Constants;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace GbXmlDesign.Presentation.Modules.AppSettings
{
    public class AppSettingsModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public AppSettingsModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.AppSettingsView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<AppSettingsView, AppSetttingsViewModel>();

        }
    }
}
