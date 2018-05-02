using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Infrastructure
{
    public static class CurrentUser
    {
        private static UserModel _instance;

        public static UserModel Instance
        {
            get => _instance;
            set
            {
                _instance = value;

                if (_instance.UserTestModels is null)
                    _instance.UserTestModels = new List<UserTestModel>();

                if (_instance.TestResults is null)
                    _instance.TestResults = new List<TestResultModel>();
            }
        }

        public static bool IsAuthenticated()
        {
            return Instance != null;
        }
    }
}