using System;
using GalaSoft.MvvmLight.Messaging;

namespace EnglishExams.Infrastructure
{
    public static class RedirectDecorator
    {
        public static void ToViewModel(Type type)
        {
            Messenger.Default.Send(new ChangePage(type));
        }

        public static void Register<T>(T currentType, Action<ChangePage> changePage)
        {
            Messenger.Default.Register(currentType, changePage);
        }
    }
}