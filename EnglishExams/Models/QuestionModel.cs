using System.Collections.Generic;

namespace EnglishExams.Models
{
    public class QuestionModel
    {
        public string Text { get; set; }

        public ICollection<OptionModel> Options { get; set; }
    }
}