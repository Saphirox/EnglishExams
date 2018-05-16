using System.Collections.Generic;
using EnglishExams.Infrastructure;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    /// <summary>
    /// User identity
    /// </summary>
    public class UserModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("tests")]
        public ICollection<UserTestModel> UserTestModels { get; set; }

        [JsonProperty("results")]
        public ICollection<TestResultModel> TestResults { get; set; }

        public Roles Role { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != this.GetType())
                return false;

            var entity = (UserModel) obj;

            var isEqual = 
                Password == entity.Password &&
                UserName == entity.UserName;

            return isEqual;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}