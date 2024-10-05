namespace OnlineSurvey.Application.DTOs
{
    internal class ResultDto
    {
        public Guid Id { get; set; }
        public int QuestionId { get; set; }
        public string? InterviewId { get; set; }
        public List<string> Results { get; set; }
        public ResultDto() { }
        public ResultDto(Guid id, string interviewId, int questionId, List<string> results)
        {
            Id = id;
            QuestionId = questionId;
            InterviewId = interviewId;
            Results = results;
        }

    }
}
