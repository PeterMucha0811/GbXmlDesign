using GbXmlDesign.Core.Events;
using Prism.Events;
using Prism.Mvvm;
using Prism;
using System;

namespace GbXmlDesign.Presentation.Modules.AppHome.ViewModels
{
    public class AppHomeMenuViewModel : BindableBase, IActiveAware
    {
        private readonly IEventAggregator _eventAggregator;

        public AppHomeMenuViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;

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

    }
}