using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Infrastructure
{
    public interface ITestResultService
    {
        // TODO: Refactor me
        void AddResultToUser(TestDescription key, Dictionary<string, ICollection<string>> answers);

        // TODO: Refactor me
        IList<TestResultDescriptionModel> GetResults(TestDescription key);
    }
}