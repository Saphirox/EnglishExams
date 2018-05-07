using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Infrastructure
{
    /// <summary>
    /// User identity (Entity per application session)
    /// </summary>
    public static class CurrentUser
    {
        private static UserModel _instance;

        public static UserModel Instance
        {
            get => _instance;
            set
            {
                if (value is null)
                {
                    return;
                }

                _instance = value;

                if (_instance.UserTestModels is null)
                    _instance.UserTestModels = new List<UserTestModel>();

                if (_instance.TestResults is null)
                    _instance.TestResults = new List<TestResultModel>();
            }
        }

        /// <summary>
        /// Return true if user instance exist
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthenticated()
        {
            return Instance != null;
        }
    }
}