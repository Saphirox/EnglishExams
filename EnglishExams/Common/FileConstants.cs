using System.IO;

namespace EnglishExams.Common
{
    /// <summary>
    /// Resouces file where store application data
    /// </summary>
    public class FileConstants
    {
        public static readonly string PERSONAL_DATA = Path.Combine("Files", "persona-data.json");
    }
}