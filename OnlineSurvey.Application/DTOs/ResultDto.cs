namespace OnlineSurvey.Application.DTOs
{
    internal class ResultDto
    {
        public Guid Id { get; set; }
        public InterviewDto Interview { get; set; } = null!;
        public int QuestionId { get; set; }
        public QuestionDto Question { get; set; } =null!;
        public List<string> Results { get; set; } = null!;
        public ResultDto() { }
        public ResultDto(Guid id, List<string> results)
        {
            Id = id;
            Results = results;
        }

    }
}
