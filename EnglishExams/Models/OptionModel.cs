using Newtonsoft.Json;

namespace EnglishExams.Models
{
    /// <summary>
    /// Question option for test
    /// </summary>
    public class OptionModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}