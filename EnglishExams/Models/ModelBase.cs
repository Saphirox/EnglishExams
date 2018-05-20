namespace EnglishExams.Models
{
    public class ModelBase
    {
        public TestKey Key { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            var entity = (ModelBase)obj;

            return entity.Key == Key;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}