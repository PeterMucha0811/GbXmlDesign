using GbXmlDesign.Presentation.Commands;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace GbXmlDesign.Presentation.ViewModels.Menus
{
    public class NavigationMenuViewModel : BindableBase
    {
        public DelegateCommand<string> NavigateCommand { get; private set; }

        public NavigationMenuViewModel(IRegionManager regionManager)
        {
            var navigateCommand = new NavigateCommand(regionManager);
            NavigateCommand = navigateCommand.Command;

            ExitApplicationCommand = new DelegateCommand(ExitApplication);
        }

        public NavigationMenuViewModel()
        {

        }

        public ICommand ExitApplicationCommand { get; private set; }
        private void ExitApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
