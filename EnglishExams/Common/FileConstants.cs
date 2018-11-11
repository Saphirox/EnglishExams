using System.IO;

namespace EnglishExams.Common
{
    /// <summary>
    /// Resouces file where store application data
    /// </summary>
    public class FileConstants
    {
        public static readonly string PERSONAL_DATA = Path.Combine("Files", "persona-data.json");
        public static readonly string PERSONAL_DATA_PATH = 
            Path.Combine(
                Directory.GetCurrentDirectory().Replace("bin\\Debug", string.Empty)
                .Replace("bin\\Release", string.Empty), "Files", "persona-data.json");
    }
}