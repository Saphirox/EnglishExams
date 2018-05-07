using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    /// <summary>
    /// Dto for TestListViewModel to view in ListBox
    /// </summary>
    public class TestListModel
    {
        [JsonProperty("unitName")]
        public string UnitName { get; set; }
        [JsonProperty("lessonsName")]
        public IEnumerable<string> LessonsName { get; set; }
    }
}