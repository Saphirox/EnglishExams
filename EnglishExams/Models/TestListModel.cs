using System.Collections.Generic;

namespace EnglishExams.Models
{
    /// <summary>
    /// Dto for TestListViewModel to view in ListBox
    /// </summary>
    public class TestListModel
    {
        public string UnitName { get; set; }
        public IEnumerable<string> LessonsName { get; set; }
    }
}