using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Services
{
    public interface ITestResultService
    {
        // TODO: Refactor me
        void AddResultToUser(TestKey key, Dictionary<string, ICollection<string>> answers);

        IEnumerable<GradebookTestResultModel> GetGradebook();

        // TODO: Refactor me
        IList<TestResultDescriptionModel> GetResults(TestKey key);
    }
}