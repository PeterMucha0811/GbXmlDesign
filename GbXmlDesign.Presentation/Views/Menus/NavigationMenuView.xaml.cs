using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GbXmlDesign.Presentation.Views.Menus
{
    public partial class NavigationMenuView : UserControl
    {
        public NavigationMenuView()
        {
            InitializeComponent();
            InitializeData();
        }


        #region Navigation Menu Appearance (Manages Active Tab Highlight)

        // Program Colors
        private SolidColorBrush _defaultColor;
        private SolidColorBrush _activeColor;

        // Dictionary of Button Names & Associated Parent Boarders
        private Dictionary<string, DependencyObject> _tabData;

        // Current Button Name & Boarder as Object
        private string _actTabButtonName;
        DependencyObject _dependencyObject;

        private void InitializeData()
        {
            // Get Resorce Tab Colors
            _defaultColor = (SolidColorBrush)this.Resources["menuBackColor"];
            _activeColor = (SolidColorBrush)this.Resources["menuActiveTabColor"];

            _tabData = new Dictionary<string, DependencyObject>();
            _tabData.Add("AppHomeViewButton", (AppHomeBorder as Border));
            _tabData.Add("GbXmlViewerViewButton", (GbxmlViewerBorder as Border));
            _tabData.Add("VentCalcViewButton", (VentCalcBorder as Border));
            _tabData.Add("LoadCalcViewButton", (LoadCalcBorder as Border));
            _tabData.Add("ExitApplicationButton", (CloseAppBorder as Border));
            _tabData.Add("AppSettingsViewButton", (AppSettingsBorder as Border));

            //// Set Active Tab
            _actTabButtonName = "GbxmlViewerButton";
            _dependencyObject = (GbxmlViewerBorder as Border);
            (_dependencyObject as Border).Background = _activeColor;
        }


        // Tab Visibility Brain
        private void ActiveTab_Click(object sender, RoutedEventArgs e)
        {
            // Get the Name of Button Clicked
            string content = (sender as Button).Name.ToString();

            // If Not the Active Tab
            if (content != _actTabButtonName)
            {
                // Turn Off Previous Tab Background
                (_dependencyObject as Border).Background = _defaultColor;


                // Update Name of new Active Tab
                _actTabButtonName = content;

                // Update Tab as Object
                _dependencyObject = (_tabData[content] as Border);
                (_dependencyObject as Border).Background = _activeColor;

            }
        }
        #endregion
    }
}
