using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.Services.Abstraction
{
    internal interface IInterviewService
    {
        public Task AddAsync(InterviewDto interview);
        public Task UpdateAsync(string interviewId,int questionId, string quaere, List<string> results);
        public Task DeleteAsync(string id);
        public Task<InterviewDto?> GetByIdAsync(string id);
        public Task<List<Interview>?> GetAllAsync();
    }
}
