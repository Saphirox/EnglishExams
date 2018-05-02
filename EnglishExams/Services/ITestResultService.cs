using System.Collections.Generic;
using EnglishExams.Models;

namespace EnglishExams.Services
{
    public interface ITestResultService
    {
        // TODO: Refactor me
        void AddResultToUser(TestDescription key, Dictionary<string, ICollection<string>> answers);

        IList<GradebookTestResultModel> GetGradebook();

        // TODO: Refactor me
        IList<TestResultDescriptionModel> GetResults(TestDescription key);
    }
}