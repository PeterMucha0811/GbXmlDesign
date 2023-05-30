using GbXmlDesign.Presentation.Commands;
using GbXmlDesign.Presentation.Modules.AppHome.Views;
using GbXmlDesign.Presentation.Modules.AppHome.Views.Menus;
using GbXmlDesign.Presentation.Modules.GbXmlViewer.Views;
using GbXmlDesign.Presentation.Views;
using GbXmlDesign.Presentation.Views.Menus;
using GbXmlDesign.Shared.Constants;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace GbXmlDesign.Presentation.ViewModels
{
    public class LeftButtonViewModel : BindableBase
    {
        private string _imagePath;
        private string _imagePathMaximized;
        private string _commandParameter;
        private bool _atHome = true;
        private readonly IRegionManager _regionManager;

        public LeftButtonViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            // Initialize the command
            ClickCommand = new DelegateCommand<object>(OnClick);
        }

        public ICommand ClickCommand { get; }

        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        public string ImagePathMaximized
        {
            get => _imagePathMaximized;
            set => SetProperty(ref _imagePathMaximized, value);
        }

        public string CommandParameter
        {
            get => _commandParameter;
            set => SetProperty(ref _commandParameter, value);
        }

        public bool AtHome
        {
            get => _atHome;
            set => SetProperty(ref _atHome, value);
        }

        private void OnClick(object parameter)
        {
            switch (CommandParameter)
            {
                case "Home":
                    if (AtHome)
                    {
                        _regionManager.RequestNavigate(RegionNames.LeftTabRegion, nameof(NavigationMenuView));
                        _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(GbXmlViewerView));
                    }
                    else
                    {
                        _regionManager.RequestNavigate(RegionNames.LeftTabRegion, nameof(AppHomeMenuView));
                        _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(AppHomeView));
                    }

                    AtHome = !AtHome;
                    break;

                case "Open":
                    // DO SOMETHING HERE...
                    break;

                case "Undo":
                    // DO SOMETHING HERE...
                    break;

                case "Redo":
                    // DO SOMETHING HERE...
                    break;
            }
        }
    }
}
