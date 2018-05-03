namespace EnglishExams.Infrastructure
{
    public static class ValidationExtensions
    {
        public static int ValidateNumber(this string value)
        {
            if (int.TryParse(value, out var result) && result > 0)
            {
                 return result;
            }

            MessageError.FieldConsistOnlyDigits.Show();

            return default;
        }
    }
}