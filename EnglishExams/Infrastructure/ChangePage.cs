using System;

namespace EnglishExams.Infrastructure
{
    /// <summary>
    /// Data transferm object for passing data to MainViewModel 
    /// </summary>
    public class ChangePage
    {
        public Type CurrentViewModel { get; }

        public ChangePage(Type сurrentViewModel)
        {
            CurrentViewModel = сurrentViewModel;
        }     
    }
}