using System.Collections.Generic;

namespace EnglishExams.Models
{
    /// <summary>
    /// Dto for GradebookViewModel
    /// </summary>
    public class GradebookTestResultModel : TestKey
    {
        public double Points { get; set; }
    }
}