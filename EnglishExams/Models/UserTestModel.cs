using System.Collections.Generic;

namespace EnglishExams.Models
{
    public class UserTestModel
    {
        public string UnitName { get; set; }
        
        public string LessonName { get; set; }
        
        public int Duration { get; set; }
        
        public int NumberOfQuestions { get; set; }
        
        public int NumberOfPoints { get; set; }

        public ICollection<QuestionModel> QuestionModels { get; set; }
    }
}