using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    public class QuestionResultModel
    {
        [JsonProperty("questionText")]
        public string Text { get; set; }

        [JsonProperty("questionOptions")]
        public ICollection<string> OptionsName { get; set; }
    }
}