﻿namespace EnglishExams.Models
{
    /// <summary>
    /// Test Key
    /// </summary>
    public class TestKey : IntId
    {
        public string UnitName { get; set; }
        public string LessonName { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is TestKey val))
                return false;

            return UnitName == val.UnitName && LessonName == val.LessonName;
        }

        public override int GetHashCode()
        {
            int hash = 271;
            hash = (hash * 7) ^ LessonName.GetHashCode();
            hash = (hash * 7) ^ UnitName.GetHashCode();
            return hash;
        }

        public static bool operator==(TestKey key1, TestKey key2)
        {
            return key1.Equals(key2);
        }

        public static bool operator !=(TestKey key1, TestKey key2)
        {
            return !(key1 == key2);
        }

        internal static TestKey From(string unitName, string lessonName)
        {
            return  new TestKey()
            {
                UnitName = unitName,
                LessonName = lessonName
            };
        }
    }
}