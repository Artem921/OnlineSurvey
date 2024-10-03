namespace OnlineSurvey.Application.DTOs
{
    internal class QuestionDto
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public SurveyDto Survey { get; set; } = null!;
        public string Quaere { get; set; } = null!;
        public AnswerDto Answer { get; set; } = null!;
        public ResultDto Result { get; set; } = null!;
    }
}
