using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    /// <summary>
    /// Result of passed tests 
    /// </summary>
    public class TestResultModel
    {
        public TestKey Key { get; set; }
        
        [JsonProperty("questionResult")]
        public ICollection<QuestionResultModel> QuestionResultModels { get; set; }
    }
}