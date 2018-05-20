﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    /// <summary>
    /// Result of passed tests 
    /// </summary>
    public class TestResultModel : ModelBase
    {
        [JsonProperty("questionResult")]
        public ICollection<QuestionResultModel> QuestionResultModels { get; set; }
    }
}