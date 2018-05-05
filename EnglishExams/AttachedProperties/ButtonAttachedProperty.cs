using System.Windows;

namespace EnglishExams.Infrastructure
{
    /// <summary>
    /// Attached property which used to pass params to code behind
    /// </summary>
    public class ButtonAttachedProperty
    {
        public static readonly DependencyProperty UnitNameProperty =
            DependencyProperty.RegisterAttached("UnitName",
                typeof(string), typeof(ButtonAttachedProperty), new PropertyMetadata(default(string)));

        public static void SetUnitName(UIElement element, string value)
        {
            element.SetValue(UnitNameProperty, value);
        }

        public static string GetUnitName(UIElement element)
        {
            return (string) element.GetValue(UnitNameProperty);
        }

        public static readonly DependencyProperty LessonNameProperty =
            DependencyProperty.RegisterAttached("LessonName",
                typeof(string), typeof(ButtonAttachedProperty), new PropertyMetadata(default(string)));

        public static void SetLessonName(UIElement element, string value)
        {
            element.SetValue(LessonNameProperty, value);
        }

        public static string GetLessonName(UIElement element)
        {
            return (string)element.GetValue(LessonNameProperty);
        }
    }
}