using System.Windows;
using EnglishExams.Resources;

namespace EnglishExams.Infrastructure
{

    /// <summary>
    /// Facade on errors for code reusing
    /// </summary>
    public class MessageError
    {
        public static class FieldConsistOnlyDigits
        {
            public static void Show()
            {
                MessageBox.Show(ErrorResources.FieldMustBeConsistOnlyDigits, ErrorResources.Error);
            }
        }
        
        public static class InvalidIdentityForm
        {
            public static void Show()
            {
                MessageBox.Show(ErrorResources.InvalidIdentityForm, ErrorResources.Error);
            }
        }

        public static class TimeOfTestExpired
        {
            public static void Show()
            {
                MessageBox.Show(CommonResources.TestTimeExpired, CommonResources.TimeRunOut);
            }
        }

        public static class FirstAndSecondOptionIsRequired
        {
            public static void Show()
            {
                MessageBox.Show(ErrorResources.FirstAndSecondOptionIsRequired, ErrorResources.Error);
            }
        }

        public static class AllFieldsIsRequired
        {
            public static void Show()
            {
                MessageBox.Show(ErrorResources.AllFieldsIsRequired, ErrorResources.Error);
            }
        }

        public static class TeacherNotFound
        {
            public static void Show()
            {
                MessageBox.Show(ErrorResources.TeacherNotFound, ErrorResources.Error);
            }
        }

        public static void Show(string message)
        {
            MessageBox.Show(message, ErrorResources.Error);
        }

        public static void Show(string message, params object[] messageParams)
        { 
            MessageBox.Show(string.Format(message, messageParams), ErrorResources.Error);
        }
    }
}