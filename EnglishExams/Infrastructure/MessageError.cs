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
    }
}