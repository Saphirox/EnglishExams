using System.Collections.Generic;
using System.Linq;

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

    public static class UserTestModelExtension
    {
        public static IEnumerable<TestListModel> ToTaskList(this IEnumerable<UserTestModel> model)
        {
            var taskListModels = model?.GroupBy(c => c.UnitName).Select(c => 
                new TestListModel
                {
                    LessonsName = c.Select(l => l.LessonName).ToList(),
                    UnitName = c.Key
                });

            return taskListModels;
        }
    }
}