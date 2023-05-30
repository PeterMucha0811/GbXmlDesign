using GbXmlDesign.Core.Events;
using GbXmlDesign.Shared.Constants;
using Prism.Commands;
using Prism.Events;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace GbXmlDesign.Presentation.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        private readonly IEventAggregator _eventAggregator;
        private IDialogService _dialogService;
        private readonly IContainerProvider _containerProvider;

        public MainWindowViewModel(IRegionManager regionManager,
            IEventAggregator eventAggregator,
            IDialogService dialogService,
            IContainerProvider containerProvider)
        {
            _regionManager = regionManager;
            _eventAggregator = eventAggregator;
            _dialogService = dialogService;
            _containerProvider = containerProvider;


            //NavigateCommand = new DelegateCommand<string>(Navigate);
            ExitApplicationCommand = new DelegateCommand(ExitApplication);


            // //  Register for StatusBar Events  // //
            _eventAggregator.GetEvent<StatusBarUpdateEvent>().Subscribe(UpdateStatusBar, ThreadOption.UIThread, false, null);

            if (StatusBarMessage == null)
            {
                StatusBarMessage = "Ready to do stuff!!";
            }

            InitializeTitleBarButtons();
        }


        private void UpdateStatusBar(string statusBarMessage)
        {
            StatusBarMessage = statusBarMessage;
        }


        private string _statusBarMessage;
        public string StatusBarMessage
        {
            get => _statusBarMessage;
            set => SetProperty<string>(ref _statusBarMessage, value);
        }

        public ICommand ExitApplicationCommand { get; private set; }
        private void ExitApplication()
        {
            System.Windows.Application.Current.Shutdown();
        }


        public DelegateCommand<string> NavigateCommand { get; private set; }

        private void Navigate(string navigationPath)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegion, navigationPath);
        }


        public MainWindowViewModel()
        {

        }

        private ObservableCollection<LeftButtonViewModel> _titleBarButtons_Left;
        private ObservableCollection<RightButtonViewModel> _titleBarButtons_Right;

        public ObservableCollection<LeftButtonViewModel> TitleBarButtons_Left
        {
            get { return _titleBarButtons_Left; }
            set { SetProperty(ref _titleBarButtons_Left, value); }
        }

        public ObservableCollection<RightButtonViewModel> TitleBarButtons_Right
        {
            get { return _titleBarButtons_Right; }
            set { SetProperty(ref _titleBarButtons_Right, value); }
        }
        private readonly Window window1;

        public MainWindowViewModel(Window window)
        {
            window1 = window;

            //InitializeLeftTitleBarButtons(_regionManager);
            //InitializeRightTitleBarButtons(window);
        }

        //private void InitializeLeftTitleBarButtons(IRegionManager regionManager)
        //{
        //    TitleBarButtons_Left.Add(new LeftButtonViewModel(regionManager) { ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-home.png", CommandParameter = "Home" });
        //    TitleBarButtons_Left.Add(new LeftButtonViewModel(regionManager) { ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-open.png", CommandParameter = "Open" });
        //    TitleBarButtons_Left.Add(new LeftButtonViewModel(regionManager) { ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-save.png", CommandParameter = "Save" });
        //    TitleBarButtons_Left.Add(new LeftButtonViewModel(regionManager) { ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-undo.png", CommandParameter = "Undo" });
        //    TitleBarButtons_Left.Add(new LeftButtonViewModel(regionManager) { ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-redo.png", CommandParameter = "Redo" });
        //}

        //private void InitializeRightTitleBarButtons(Window window)
        //{

        //    TitleBarButtons_Right.Add(new RightButtonViewModel(window) { ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/window-minimize.png", CommandParameter = "Minimize" });
        //    TitleBarButtons_Right.Add(new RightButtonViewModel(window) { ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/window-maximize.png", CommandParameter = "MaximizeRestore" });
        //    TitleBarButtons_Right.Add(new RightButtonViewModel(window) { ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/window-close.png", CommandParameter = "Close" });
        //}



        private void InitializeTitleBarButtons()
        {
            TitleBarButtons_Left = new ObservableCollection<LeftButtonViewModel>
            {
                new LeftButtonViewModel(_regionManager)
                {
                    ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-home.png",
                    CommandParameter = "Home"
                },
                new LeftButtonViewModel(_regionManager)
                {
                    ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-open.png",
                    CommandParameter = "Open"
                },
                new LeftButtonViewModel(_regionManager)
                {
                    ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-save.png",
                    CommandParameter = "Save"
                },
                new LeftButtonViewModel(_regionManager)
                {
                    ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-undo.png",
                    CommandParameter = "Undo"
                },
                new LeftButtonViewModel(_regionManager)
                {
                    ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/app-redo.png",
                    CommandParameter = "Redo"
                }
            };

            TitleBarButtons_Right = new ObservableCollection<RightButtonViewModel>
            {
                new RightButtonViewModel(window1)
                {
                    ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/window-minimize.png",
                    CommandParameter = "Minimize"
                },
                new RightButtonViewModel(window1)
                {
                    ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/window-maximize.png",
                    CommandParameter = "MaximizeRestore"
                },
                new RightButtonViewModel(window1)
                {
                    ImagePath = "pack://application:,,,/GbXmlDesign.Presentation;component/Resources/Images/Interface/window-close.png",
                    CommandParameter = "Close"
                }
            };
        }
    }
}
