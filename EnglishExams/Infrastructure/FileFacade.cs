using System.IO;
using Newtonsoft.Json;

namespace EnglishExams.Infrastructure
{
    public class FileFacade : IFileFacade
    {
        public string CurrentDirectory = Directory.GetCurrentDirectory().Replace("bin\\Debug", string.Empty);

        public void WriteTo<T>(string path, T obj)
        {
            var filePath = Path.Combine(CurrentDirectory, path);

            if (File.Exists(filePath))
            {
                File.WriteAllText(filePath, JsonConvert.SerializeObject(obj));
            }
            else
            {
                File.Create(filePath);
                File.WriteAllText(filePath, JsonConvert.SerializeObject(obj));
            }
        }

        public T ReadFrom<T>(string path) where T: class
        {
            var filePath = Path.Combine(CurrentDirectory, path);

            T result = null;

            if (File.Exists(filePath))
            {
                var text = File.ReadAllText(filePath);

                result = JsonConvert.DeserializeObject<T>(text);
            }
            else
            {
                File.Create(filePath);
            }

            return result;
        }
    }
}