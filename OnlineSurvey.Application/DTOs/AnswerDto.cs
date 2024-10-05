namespace OnlineSurvey.Application.DTOs
{
    internal class AnswerDto
    {
        public int Id { get; set; }
        public string QuestionId { get; set; } 
        public  List<string> Replys { get; set; }
    }
}
