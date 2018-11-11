using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    /// <summary>
    /// Result of passed tests 
    /// </summary>
    public class TestResultModel : TestKey
    {
        [JsonProperty("questionResult")]
        public virtual ICollection<QuestionResultModel> QuestionResultModels { get; set; }

        public virtual UserModel UserModel { get; set; }

        public static TestResultModel CreateNew(TestKey key, ICollection<QuestionResultModel> questions)
        {
            return new TestResultModel()
            {
                LessonName = key.LessonName,
                UnitName = key.UnitName,
                QuestionResultModels = questions
            };
        }
    }
}