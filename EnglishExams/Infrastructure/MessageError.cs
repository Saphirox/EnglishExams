using System.Windows;
using EnglishExams.Resources;

namespace EnglishExams.Infrastructure
{
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
    }
}