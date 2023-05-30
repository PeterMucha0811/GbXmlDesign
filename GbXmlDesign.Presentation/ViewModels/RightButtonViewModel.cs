using Prism.Commands;
using Prism.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace GbXmlDesign.Presentation.ViewModels
{
    public class RightButtonViewModel : BindableBase
    {
        private string _imagePath;
        private string _commandParameter;

        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        public string CommandParameter
        {
            get => _commandParameter;
            set => SetProperty(ref _commandParameter, value);
        }

        public ICommand ClickCommand { get; }

        public RightButtonViewModel(Window window)
        {
            // Initialize the command
            ClickCommand = new DelegateCommand(() => OnClick(window));
        }

        private void OnClick(Window window)
        {
            // Handle the button click event here
            // The parameter will contain the button's data/context
            // You can access the properties of the button view model to identify which button was clicked

            switch (CommandParameter)
            {
                case "Minimize":
                    // Minimize the window
                    window.WindowState = WindowState.Minimized;
                    break;

                case "MaximizeRestore":
                    // Toggle between maximize and restore
                    if (window.WindowState == WindowState.Maximized)
                        window.WindowState = WindowState.Normal;
                    else
                        window.WindowState = WindowState.Maximized;
                    break;

                case "Close":
                    // Close the window
                    //window.Close();
                    break;
            }
        }
    }
}
