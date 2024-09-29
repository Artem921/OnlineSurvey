namespace OnlineSurvey.Application.DTOs
{
    internal class ResultDto
    {
        public int Id { get; set; }
        public Dictionary<string, List<string>> Results { get; set; }
        public ResultDto() 
        { 
            Results = new Dictionary<string, List<string>>();
        }

    }
}
