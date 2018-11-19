using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnglishExams.Common;

namespace EnglishExams.Infrastructure
{
    public class DbContextFactory : IDbContextFactory<EnglishExamsDbContext>
    {
        public EnglishExamsDbContext Create()
        {
            return new EnglishExamsDbContext(DbSettings.CONNECTION_STRING);
        }
    }
}
