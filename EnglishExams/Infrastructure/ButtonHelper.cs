using System.Windows;

namespace EnglishExams.Infrastructure
{
    public class ButtonHelper
    {
        public static readonly DependencyProperty UnitNameProperty =
            DependencyProperty.RegisterAttached("UnitName",
                typeof(string), typeof(ButtonHelper), new PropertyMetadata(default(string)));

        public static void SetUnitName(UIElement element, double value)
        {
            element.SetValue(UnitNameProperty, value);
        }

        public static double GetUnitName(UIElement element)
        {
            return (double) element.GetValue(UnitNameProperty);
        }
    }
}