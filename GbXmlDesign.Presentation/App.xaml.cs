using GbXmlDesign.Application.Services;
using GbXmlDesign.Presentation.Modules.AppHome;
using GbXmlDesign.Presentation.Modules.AppHome.Views;
using GbXmlDesign.Presentation.Modules.AppHome.Views.Menus;
using GbXmlDesign.Presentation.Modules.AppSettings;
using GbXmlDesign.Presentation.Modules.GbXmlViewer;
using GbXmlDesign.Presentation.Modules.LoadCalc;
using GbXmlDesign.Presentation.Modules.VentCalc;
using GbXmlDesign.Presentation.ViewModels;
using GbXmlDesign.Presentation.Views;
using GbXmlDesign.Presentation.Views.Menus;
using GbXmlDesign.Shared.Constants;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Windows;
using Unity;

namespace GbXmlDesign.Presentation
{

    public partial class App : PrismApplication
    {
        

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IRecentProjectsDataService, RecentProjectsDataService>();

            containerRegistry.RegisterSingleton<IRegionManager, RegionManager>();


        }


        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AppHomeModule>();
            moduleCatalog.AddModule<AppSettingsModule>();
            moduleCatalog.AddModule<GbXmlViewerModule>();
            moduleCatalog.AddModule<LoadCalcModule>();
            moduleCatalog.AddModule<VentCalcModule>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionManager = Container.Resolve<IRegionManager>();

            regionManager.RegisterViewWithRegion(RegionNames.LeftTabRegion, typeof(NavigationMenuView));

            //regionManager.RegisterViewWithRegion(RegionNames.LeftTabRegion, typeof(AppHomeMenuView));
            //regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(AppHomeView));

            regionManager.RequestNavigate(RegionNames.LeftTabRegion, nameof(AppHomeMenuView));
            regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(AppHomeView));
        }

        protected override Window CreateShell()
        {
            var mainWindowViewModel = Container.Resolve<MainWindowViewModel>();
            var mainWindow = new MainWindow { DataContext = mainWindowViewModel };
            return mainWindow;

        }
    }
}
