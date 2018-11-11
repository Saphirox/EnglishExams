using System;
using GalaSoft.MvvmLight.Messaging;

namespace EnglishExams.Infrastructure
{
    /// <summary>\
    /// Router -> using diffrent ViewModel as Type 
    /// application redirect to appropriate view
    /// 
    /// Messenger.Default is realization of Observable pattern
    /// </summary>
    public static class RedirectDecorator
    {
        /// <summary>
        /// Redirect to page of type
        /// </summary>
        /// <param name="type">ViewModelBase</param>
        public static void ToViewModel(Type type)
        {
            Messenger.Default.Send(new ChangePage(type));
        }

        public static void ToViewModel(ChangePage type)
        {
            Messenger.Default.Send(type);
        }

        /// <summary>
        /// Register to catch 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="currentType"></param>
        /// <param name="changePage"></param>
        public static void Register<T>(T currentType, Action<ChangePage> changePage)
        {
            Messenger.Default.Register(currentType, changePage);
        }
    }
}