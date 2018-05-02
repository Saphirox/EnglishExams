namespace EnglishExams.Models
{
    /// <summary>
    /// Dto to view on TestResultViewModel
    /// </summary>
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