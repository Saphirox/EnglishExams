using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishExams.Common
{
    public class DbSettings
    {
        public const string CONNECTION_STRING =
            "Server=(localdb)\\MSSQLLocalDB;Database=EnglishExams;Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
