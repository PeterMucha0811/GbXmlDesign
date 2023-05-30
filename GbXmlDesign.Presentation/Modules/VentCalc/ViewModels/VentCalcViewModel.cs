using GbXmlDesign.Core.Events;
using Prism;
using Prism.Events;
using Prism.Mvvm;
using System;

namespace GbXmlDesign.Presentation.Modules.VentCalc.ViewModels
{
    public class VentCalcViewModel : BindableBase, IActiveAware
    {
        private readonly IEventAggregator _eventAggregator;

        public VentCalcViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
        }

        private void UpdateStatusBarMethod()
        {
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Publish("Ventilation Calculation Module is Active");
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
