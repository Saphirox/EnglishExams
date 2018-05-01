using System.Collections;
using System.Collections.Generic;

namespace EnglishExams.Models
{
    public class TaskListModel
    {
        public string UnitName { get; set; }
        public IEnumerable<string> LessonsName { get; set; }
    }
}