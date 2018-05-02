using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    public class QuestionModel
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("options")]
        public ICollection<OptionModel> Options { get; set; }
    }
}