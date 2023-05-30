using System.Windows;
using System.Windows.Controls;

namespace GbXmlDesign.Presentation.Selectors
{
    public class NullTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NullTemplate { get; set; }
        public DataTemplate NormalTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item == null)
                return NullTemplate;
            else
                return NormalTemplate;
        }
    }
}