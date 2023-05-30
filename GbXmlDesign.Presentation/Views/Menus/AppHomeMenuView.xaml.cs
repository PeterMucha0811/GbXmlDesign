using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GbXmlDesign.Presentation.Views.Menus
{
    /// <summary>
    /// Interaction logic for AppHomeMenuView
    /// </summary>
    public partial class AppHomeMenuView : UserControl
    {
        public AppHomeMenuView()
        {
            InitializeComponent();
        }



        private void ClrPcker_Background_SelectedColorChanged(object sender, RoutedPropertyChangedEventArgs<Color> e)
        {
            //TextBox.Text = ("#" + ClrPcker_Background.SelectedColor.R.ToString() + ClrPcker_Background.SelectedColor.G.ToString() + ClrPcker_Background.SelectedColor.B.ToString());
        }
    }
}
