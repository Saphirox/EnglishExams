using System.IO;
using Newtonsoft.Json;

namespace EnglishExams.Infrastructure
{

    /// <inheritdoc />
    /// <summary>
    /// Wrapper for file system to simplify using system storage
    /// </summary>
    public class FileWrapper : IFileWrapper
    {
        public readonly string CurrentDirectory = Directory.GetCurrentDirectory().Replace("bin\\Debug", string.Empty);

        /// <summary>
        /// Write to file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path">Path depend on current directory</param>
        /// <param name="obj">Object to serialize</param>
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

        /// <summary>
        /// Read data from file
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <returns></returns>
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