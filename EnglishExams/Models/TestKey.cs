namespace EnglishExams.Models
{
    /// <summary>
    /// Test Key
    /// </summary>
    public class TestKey
    {
        public string UnitName { get; set; }
        public string LessonName { get; set; }

        public override bool Equals(object obj)
        {
            var val = (TestKey)obj;

            return UnitName == val.UnitName && LessonName == val.LessonName;
        }

        public static bool operator==(TestKey key1, TestKey key2)
        {
            return key1.Equals(key2);
        }

        public static bool operator !=(TestKey key1, TestKey key2)
        {
            return !(key1 == key2);
        }
    }
}