using GbXmlDesign.Presentation.Modules.GbXmlViewer.ViewModels;
using GbXmlDesign.Presentation.Modules.GbXmlViewer.Views;
using GbXmlDesign.Shared.Constants;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;


namespace GbXmlDesign.Presentation.Modules.GbXmlViewer
{
    public class GbXmlViewerModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public GbXmlViewerModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, ViewNames.GbXmlViewerView);
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GbXmlViewerView, GbXmlViewerViewModel>();

        }
    }
}
