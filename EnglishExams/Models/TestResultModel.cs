using System.Collections.Generic;

namespace EnglishExams.Models
{
    public class TestResultModel
    {
        public string UnitName { get; set; }
        public string LessonName { get; set; }
        
        public ICollection<QuestionResultModel> QuestionResultModels { get; set; }
    }
}