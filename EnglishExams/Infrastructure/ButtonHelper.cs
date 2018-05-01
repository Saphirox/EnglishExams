using System.Windows;

namespace EnglishExams.Infrastructure
{
    public class ButtonHelper
    {
        public static readonly DependencyProperty UnitNameProperty =
            DependencyProperty.RegisterAttached("UnitName",
                typeof(string), typeof(ButtonHelper), new PropertyMetadata(default(string)));

        public static void SetUnitName(UIElement element, string value)
        {
            element.SetValue(UnitNameProperty, value);
        }

        public static string GetUnitName(UIElement element)
        {
            return (string) element.GetValue(UnitNameProperty);
        }
    }
}