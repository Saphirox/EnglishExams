using System.Collections.Generic;

namespace EnglishExams.Models
{
    /// <summary>
    /// Dto for GradebookViewModel
    /// </summary>
    public class GradebookTestResultModel
    {
        public string UnitName { get; set; }

        public ICollection<LessonResultModel> Lessons { get; set; }
    }

    /// <summary>
    /// Helper for GradebookTestResultModel
    /// </summary>
    public class LessonResultModel
    {
        public string LessonNameAndPoint { get; set; }
    }
}