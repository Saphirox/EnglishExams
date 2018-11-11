using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    /// <summary>
    /// Test question
    /// </summary>
    public class QuestionModel : IntId
    {
        public QuestionModel()
        {
            Options = new List<OptionModel>();
        }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("options")]
        public virtual ICollection<OptionModel> Options { get; set; }
    }
}