namespace OnlineSurvey.Application.DTOs
{
    internal class InterviewDto
    {
        public string Id { get; set; } 
        public List<ResultDto> Results { get; set; } 
        public InterviewDto() { }
        public InterviewDto(string id)
        {
            Id = id;
            Results = new List<ResultDto>();
        }

    }
}
