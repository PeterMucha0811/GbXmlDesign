using GbXmlDesign.Presentation.ViewModels;
using GbXmlDesign.Application.Services;
using GbXmlDesign.Shared.Constants;
using GbXmlDesign.Core.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism;
using System;
using System.Collections.ObjectModel;

namespace GbXmlDesign.Presentation.Modules.AppHome.ViewModels
{
    public class AppHomeViewModel : BindableBase, IActiveAware
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRecentProjectsDataService _recentProjectsDataService;

        public ObservableCollection<ProjectViewModel> RecentProjects { get; } = new ObservableCollection<ProjectViewModel>();
        public DelegateCommand<ProjectViewModel> LoadProjectCommand { get; }


        public AppHomeViewModel(IEventAggregator eventAggregator,
            IRecentProjectsDataService recentProjectsDataService)
        {
            _eventAggregator = eventAggregator;
            _recentProjectsDataService = recentProjectsDataService;

            // Load the recent projects
            LoadRecentProjects();

            // Initialize the command to load a project
            LoadProjectCommand = new DelegateCommand<ProjectViewModel>(OnLoadProject);
        }


        private void UpdateStatusBarMethod()
        {
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Publish("Application Home Module is Active");
        }


        #region IActiveAware Members

        private bool _isActive;
        public bool IsActive
        {
            get => _isActive;
            set
            {
                SetProperty(ref _isActive, value);
                OnIsActiveChanged();
            }
        }

        public event EventHandler IsActiveChanged;

        private void OnIsActiveChanged()
        {
            IsActiveChanged?.Invoke(this, EventArgs.Empty);

            if (IsActive)
            {
                UpdateStatusBarMethod();
            }
        }
        #endregion


        #region Call Application Services to Load Recent Projects.

        private void LoadRecentProjects()
        {
            var recentProjectsModel = _recentProjectsDataService.LoadRecentProjects();

            foreach (var project in recentProjectsModel.RecentProjects)
            {
                RecentProjects.Add(new ProjectViewModel { ProjectModel = project });
            }

            // Fill the rest of the list with nulls
            while (RecentProjects.Count < HardCodedValues.RecentProjectsVisible)
            {
                RecentProjects.Add(null);
            }
        }

        private void OnLoadProject(ProjectViewModel projectViewModel)
        {
            // TODO: Implement the logic to load a project
        }
        #endregion

    }
}
