﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace EnglishExams.Models
{
    public class UserModel
    {
        [JsonProperty("userName")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("tests")]
        public ICollection<UserTestModel> UserTestModels { get; set; }

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