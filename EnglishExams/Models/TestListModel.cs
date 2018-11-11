using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    /// <summary>
    /// Dto for TestListViewModel to view in ListBox
    /// </summary>
    public class TestListModel : IntId
    {
        [JsonProperty("unitName")]
        public string UnitName { get; set; }
        [JsonProperty("lessonsName")]
        public IEnumerable<string> LessonsName { get; set; }

        public static TestListModel From(IEnumerable<UserTestModel> userTests)
        {
            return new TestListModel
            {
                LessonsName = userTests.Select(l => l.LessonName).ToList(),
                UnitName = userTests.First().UnitName
            };
        }
    }
}