namespace OnlineSurvey.Application.Services.Abstraction
{
    internal interface IInterviewService
    {
        public Task<int> AddAsync(string interviewId, int surveyId, int questionId, List<string> results);
        public Task<int> UpdateAsync(string interviewId, int surveyId, int questionId, List<string> results);
    }
}
