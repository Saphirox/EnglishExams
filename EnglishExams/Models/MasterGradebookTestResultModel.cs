using System.Collections.Generic;

namespace EnglishExams.Models
{
    public class MasterGradebookTestResultModel
    {
        public string UserName { get; set; }
        public IEnumerable<GradebookTestResultModel> Results { get; set; }
    }
}