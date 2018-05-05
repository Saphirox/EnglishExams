using System.Collections.Generic;

namespace EnglishExams.Models
{
    /// <summary>
    /// Dto for GradebookViewModel
    /// </summary>
    public class GradebookTestResultModel
    {
        public string UnitName { get; set; }
        public string LessonName { get; set; }
        public double Points { get; set; }
    }
}