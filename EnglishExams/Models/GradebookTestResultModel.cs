using System.Collections.Generic;

namespace EnglishExams.Models
{
    public class GradebookTestResultModel
    {
        public string UnitName { get; set; }

        public ICollection<LessonResultModel> Lessons { get; set; }
    }

    public class LessonResultModel
    {
        public string LessonNameAndPoint { get; set; }
    }
}