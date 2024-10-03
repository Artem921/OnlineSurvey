using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Domian.Abstraction
{
    internal interface IInterviewRepository
    {
        public Task AddAsync(Interview interview);
        public Task UpdateAsync(Interview interview);
    }
}
