using System.Collections.Generic;
using System.Linq;

namespace EnglishExams.Models
{
    /// <summary>
    /// Custom created test by current user
    /// </summary>
    public class UserTestModel
    {
        public UserTestModel()
        {
            Key = new TestKey();
        }

        public TestKey Key { get; set; }

        public int Duration { get; set; }
        
        public int NumberOfQuestions { get; set; }
        
        public int NumberOfPoints { get; set; }

        public ICollection<QuestionModel> QuestionModels { get; set; }
    }

    public static class UserTestModelExtension
    {
        public static IEnumerable<TestListModel> ToTaskList(this IEnumerable<UserTestModel> model)
        {
            var taskListModels = model?.GroupBy(c => c.Key.UnitName).Select(c => 
                new TestListModel
                {
                    LessonsName = c.Select(l => l.Key.LessonName).ToList(),
                    UnitName = c.Key
                });

            return taskListModels;
        }
    }
}