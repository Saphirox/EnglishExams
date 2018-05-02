using System.Collections.Generic;

namespace EnglishExams.Infrastructure
{
    public static class TinyCache
    {
        private static readonly Dictionary<object, object> cache =  
            new Dictionary<object, object>();
        
        public static void Set<TK, TV>(TK key, TV value) 
            where TK: class
            where TV: class
        {
            cache.Add(key, value);
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