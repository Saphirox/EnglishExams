using System.Collections.Generic;

namespace EnglishExams.Models
{
    /// <summary>
    /// Dto for GradebookViewModel
    /// </summary>
    public class GradebookTestResultModel : TestKey
    {
        public double Points { get; set; }

        public static class Factory
        {
            public static GradebookTestResultModel CreateNew(TestKey key, int point)
            {
                return new GradebookTestResultModel
                {
                    UnitName = key.UnitName,
                    LessonName = key.LessonName,
                    Points = point
                };
            }
    }
    }
}