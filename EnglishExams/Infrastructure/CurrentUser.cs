using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Infrastructure
{
    public static class CurrentUser
    {
        private static UserModel instance;

        public static UserModel Instance
        {
            get => instance;
            set
            {
                instance = value;

                if (instance.UserTestModels is null)
                    instance.UserTestModels = new List<UserTestModel>();
            }
        }

        public static bool IsAuthenticated()
        {
            return Instance != null;
        }
    }
}