namespace EnglishExams.Models
{
    public class ModelBase
    {
        public TestKey Key { get; set; }

        public override bool Equals(object obj)
        {
            return obj is ModelBase entity ?
                entity.Key == Key : false;
        }

        public override int GetHashCode()
        {
            int hash = 271;
            hash = (hash * 7) + Key.GetHashCode();
            return hash;
        }
    }
}