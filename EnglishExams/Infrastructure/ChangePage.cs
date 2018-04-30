using System;

namespace EnglishExams.Infrastructure
{
    public class ChangePage
    {
        public Type CurrentViewModel { get; }

        public ChangePage(Type сurrentViewModel)
        {
            CurrentViewModel = сurrentViewModel;
        }     
    }
}