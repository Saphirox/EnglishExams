namespace EnglishExams.Infrastructure
{
    public interface IFileFacade
    {
        void WriteTo<T>(string path, T obj);
        T ReadFrom<T>(string path) where T : class;
    }
}