namespace EnglishExams.Infrastructure
{
    public interface IFileWrapper
    {
        void WriteTo<T>(string path, T obj);
        T ReadFrom<T>(string path) where T : class;
    }
}