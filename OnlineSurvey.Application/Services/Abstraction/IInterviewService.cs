using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.Services.Abstraction
{
    internal interface IInterviewService
    {
        public Task AddAsync(InterviewDto interview);
        public Task<int> UpdateAsync(string interviewId, int surveyId, int questionId, string quaere, List<string> results);
        public Task<InterviewDto?> GetByIdAsync(string id);
    }
}
