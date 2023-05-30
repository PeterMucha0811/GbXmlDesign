using Prism.Commands;
using Prism.Regions;

namespace GbXmlDesign.Presentation.Commands
{
    public class NavigateCommand
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> Command { get; private set; }

        public NavigateCommand(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            Command = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
                _regionManager.RequestNavigate("ContentRegion", navigatePath);
        }
    }
}
