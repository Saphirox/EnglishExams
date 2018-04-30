using System.IO;
using EnglishExams.Common;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    public class UserModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}