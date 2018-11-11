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

        public static ChangePage CreateAndPassData<T, K>(Type сurrentViewModel, T key, K value) where T : class where K: class
        {
            TinyTempCache.Set(key, value);
            return new ChangePage(сurrentViewModel); 
        }

        public static ChangePage CreateAndPassDataWithTypeKey<T>(Type сurrentViewModel, T key) where T : class
        {
            TinyTempCache.Set(key.GetType(), key);
            return new ChangePage(сurrentViewModel);
        }
    }
}