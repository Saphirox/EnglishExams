using System.Collections.Generic;

namespace EnglishExams.Models
{
    public class QuestionResultModel
    {
        public string Text { get; set; }

        public ICollection<string> OptionsName { get; set; }
    }
}