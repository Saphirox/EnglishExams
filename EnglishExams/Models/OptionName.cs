using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishExams.Models
{
    public class OptionName : IntId
    {
        public string Name { get; set; }

        public QuestionResultModel QuestionResultModel { get; set; }
        public int QuestionResultModelId { get; set; }

        public static OptionName CreateNew(string arg)
        {
            return new OptionName
            {
                Name = arg
            };
        }

        public static implicit operator string(OptionName name)
        {
            return name.Name;
        }
    }
}
