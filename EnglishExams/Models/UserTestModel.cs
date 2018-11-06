using System.Collections.Generic;
using System.Linq;

namespace EnglishExams.Models
{
    /// <summary>
    /// Custom created test by current user
    /// </summary>
    public class UserTestModel : TestKey
    {
        public UserTestModel()
        {
            QuestionModels = new List<QuestionModel>();
        }

        public int Duration { get; set; }
        
        public int NumberOfQuestions { get; set; }
        
        public int NumberOfPoints { get; set; }

        public ICollection<QuestionModel> QuestionModels { get; set; }

        public UserModel UserModel { get; set; }

        public bool Permuted { get; set; }

        public static IEnumerable<TestListModel> ToTaskList(IEnumerable<UserTestModel> model)
        {
            var taskListModels = model?.GroupBy(c => c.UnitName).Select(TestListModel.From);

            return taskListModels;
        }
    }
}