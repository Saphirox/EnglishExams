using System.Windows;

namespace EnglishExams.Infrastructure
{
    public class CheckboxHelper
    {
        public static readonly DependencyProperty ValueNameProperty =
            DependencyProperty.RegisterAttached("ValueName",
                typeof(string), typeof(CheckboxHelper), new PropertyMetadata(default(string)));

        public static void SetValueName(UIElement element, string value)
        {
            element.SetValue(ValueNameProperty, value);
        }

        public static string GetValueName(UIElement element)
        {
            return (string)element.GetValue(ValueNameProperty);
        }

        public static readonly DependencyProperty KeyNameProperty =
           DependencyProperty.RegisterAttached("KeyName",
               typeof(string), typeof(CheckboxHelper), new PropertyMetadata(default(string)));

        public static void SetKeyName(UIElement element, string value)
        {
            element.SetValue(KeyNameProperty, value);
        }

        public static string GetKeyName(UIElement element)
        {
            return (string)element.GetValue(KeyNameProperty);
        }
    }
}