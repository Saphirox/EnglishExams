using Newtonsoft.Json;

namespace EnglishExams.Models
{
    public class OptionModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("isCorrect")]
        public bool IsCorrect { get; set; }
    }
}