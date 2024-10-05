namespace OnlineSurvey.Application.DTOs
{
    internal class QuestionDto
    {
        public int Id { get; set; }
        public int SurveyId { get; set; }
        public string Quaere { get; set; } 
        public AnswerDto Answer { get; set; } 
    }
}
