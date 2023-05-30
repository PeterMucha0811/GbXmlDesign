using GbXmlDesign.Core.Events;
using Prism;
using Prism.Events;
using Prism.Mvvm;
using System;

namespace GbXmlDesign.Presentation.Modules.LoadCalc.ViewModels
{
    public class LoadCalcViewModel : BindableBase, IActiveAware
    {
        private readonly IEventAggregator _eventAggregator;

        public LoadCalcViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private void UpdateStatusBarMethod()
        {
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Publish("Load Calculation Module is Active");
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
