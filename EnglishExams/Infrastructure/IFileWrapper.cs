namespace EnglishExams.Infrastructure
{
    /// <summary>
    /// Wrapper for file system to simplify using system storage
    /// </summary>
    public interface IFileWrapper
    {
        void WriteTo<T>(string path, T obj);
        T ReadFrom<T>(string path) where T : class;
    }
}