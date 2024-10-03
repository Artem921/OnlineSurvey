namespace OnlineSurvey.Application.Services.Abstraction
{
    internal interface IInterviewService
    {
        public Task<int> AddAsync(string interviewId, int questionId, List<string> results);
        public Task<int> UpdateAsync(string interviewId, int questionId, List<string> results);
    }
}
