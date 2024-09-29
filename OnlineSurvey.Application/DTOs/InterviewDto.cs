namespace OnlineSurvey.Application.DTOs
{
    internal class InterviewDto
    {
        public string Id { get; set; }
        public int SurveyId { get; set; }
        public List<ResultDto> Results { get; set; } = null!;
    }
}
