using System.Collections.Generic;
using System.Linq;
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
            OptionsName = new List<OptionName>();
        }

        [JsonProperty("questionText")]
        public string Text { get; set; }

        [JsonProperty("questionOptions")]
        public virtual ICollection<OptionName> OptionsName { get; set; }

        public TestResultModel TestResult { get; set; }
        public int TestResultId { get; set; }

        public static QuestionResultModel CreateNew(string text, IEnumerable<string> options)
        {
            return new QuestionResultModel
            {
                Text = text,
                OptionsName = options.Select(OptionName.CreateNew).ToList()
            };
        }
    }
}