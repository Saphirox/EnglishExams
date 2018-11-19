using System.Collections.Generic;
using System.Threading.Tasks;
using EnglishExams.Models;

namespace EnglishExams.Services
{
    public interface ITestResultService
    {
        // TODO: Refactor me
        void AddResultToUser(TestKey key, Dictionary<string, ICollection<string>> answers);

        Task<IEnumerable<GradebookTestResultModel>> GetGradebook();

        IList<TestResultDescriptionModel> GetResults(TestKey key);

        IEnumerable<MasterGradebookTestResultModel> GetMasterGradebook();
    }
}