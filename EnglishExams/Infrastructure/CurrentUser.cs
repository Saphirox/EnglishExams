using System;
using System.Collections.Generic;
using EnglishExams.Models;
using GalaSoft.MvvmLight.Messaging;

namespace EnglishExams.Infrastructure
{
    /// <summary>
    /// User identity (Entity per application session)
    /// </summary>
    public static class CurrentUser
    {
        private static UserModel _instance;

        private static bool isDirtyData;

        static CurrentUser()
        {
            Messenger.Default.Unregister<UserModel>(_instance, Interceptor);
            Messenger.Default.Register<UserModel>(_instance, Interceptor);
        }

        public static UserModel Instance
        {
            get { return _instance; }
            set
            {
                if (value is null)
                {
                    _instance = null;
                    return;
                }

                _instance = value;

                if (_instance.UserTestModels is null)
                    _instance.UserTestModels = new List<UserTestModel>();

                if (_instance.TestResults is null)
                    _instance.TestResults = new List<TestResultModel>();
            }
        }

        private static void Interceptor(UserModel userModel)
        {
            Instance = userModel;
        }

        /// <summary>
        /// Return true if user instance exist
        /// </summary>
        /// <returns></returns>
        public static bool IsAuthenticated()
        {
            return Instance != null;
        }

        internal static bool FindUser(UserModel arg)
        {
            return _instance.Id == arg.Id;
        }
    }
}