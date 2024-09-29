namespace OnlineSurvey.Application.DTOs
{
    internal class QuestionDto
    {
        public int Id { get; set; }
        public string Quaere { get; set; } = null!;
        public AnswerDto Answer { get; set; } = null!;
    }
}
