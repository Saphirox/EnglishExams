using System.Collections.Generic;

namespace EnglishExams.Models
{
    public class TestListModel
    {
        public string UnitName { get; set; }
        public IEnumerable<string> LessonsName { get; set; }
    }
}