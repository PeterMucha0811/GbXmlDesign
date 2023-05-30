using GbXmlDesign.Core.Events;
using Prism;
using Prism.Events;
using Prism.Mvvm;
using System;

namespace GbXmlDesign.Presentation.Modules.AppSettings.ViewModels
{
    public class AppSetttingsViewModel : BindableBase, IActiveAware
    {
        private readonly IEventAggregator _eventAggregator;

        public AppSetttingsViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private void UpdateStatusBarMethod()
        {
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Publish("Application Settings Module is Active");
        }


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
    }
}
