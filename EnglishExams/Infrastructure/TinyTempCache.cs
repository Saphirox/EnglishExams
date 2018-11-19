using System.Collections.Generic;

namespace EnglishExams.Infrastructure
{
    /// <summary>
    /// Custom realiazion of temporary store for element
    /// When you retrived element, element remove from cache
    /// </summary>
    public static class TinyTempCache
    {
        private static readonly Dictionary<object, object> cache =  
            new Dictionary<object, object>();
        
        public static void Set<TK, TV>(TK key, TV value) 
            where TK: class
            where TV: class
        {
            cache[key] = value;
        }

        public static TV Get<TK, TV>(TK key) 
            where TK: class
            where TV: class
        {
            if (cache.TryGetValue(key, out var value))
            {
                cache.Remove(key);

                return value as TV;
            }

            return null;
        }
    }
}