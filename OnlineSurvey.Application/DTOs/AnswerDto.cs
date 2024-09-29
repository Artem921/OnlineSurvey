namespace OnlineSurvey.Application.DTOs
{
    internal class AnswerDto
    {
        public int Id { get; set; }
        public string QuestionId { get; set; } = string.Empty;
        public IEnumerable<string> Replys { get; set; }
    }
}
