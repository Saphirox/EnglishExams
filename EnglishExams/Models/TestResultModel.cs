using System.Collections.Generic;

namespace EnglishExams.Models
{
    /// <summary>
    /// Result of passed tests 
    /// </summary>
    public class TestResultModel
    {
        public string UnitName { get; set; }
        public string LessonName { get; set; }
        
        public ICollection<QuestionResultModel> QuestionResultModels { get; set; }
    }
}