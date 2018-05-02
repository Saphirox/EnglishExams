using System.Collections.Generic;

namespace EnglishExams.Models
{
    public class TestResultDescriptionModel
    {
        public string QuestionName { get; set; }
        public bool IsCorrect { get; set; }
        public string QuestionPoints { get; set; }
        public string CorrectResult { get; set; }
        public string UserResult { get; set; }
        public string QuestionNumber { get; set; }
    }
}