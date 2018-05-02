using System.Windows;

namespace EnglishExams.Infrastructure
{
    /// <summary>
    /// Attached property which used to pass params to code behind
    /// </summary>
    public class CheckboxAttachedProperty
    {
        public static readonly DependencyProperty ValueNameProperty =
            DependencyProperty.RegisterAttached("ValueName",
                typeof(string), typeof(CheckboxAttachedProperty), new PropertyMetadata(default(string)));

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
               typeof(string), typeof(CheckboxAttachedProperty), new PropertyMetadata(default(string)));

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