using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    /// <summary>
    /// Test result after passing a test
    /// </summary>
    public class QuestionResultModel : IntId
    {
        public QuestionResultModel()
        {
            OptionsName = new List<string>();
        }

        [JsonProperty("questionText")]
        public string Text { get; set; }

        [JsonProperty("questionOptions")]
        public ICollection<string> OptionsName { get; set; }
    }
}