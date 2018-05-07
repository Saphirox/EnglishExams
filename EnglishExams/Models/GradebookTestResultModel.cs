using System.Collections.Generic;

namespace EnglishExams.Models
{
    /// <summary>
    /// Dto for GradebookViewModel
    /// </summary>
    public class GradebookTestResultModel
    {
        public TestKey Key { get; set; }
        public double Points { get; set; }
    }
}