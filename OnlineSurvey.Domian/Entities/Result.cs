using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Result: Entity
    {
        public Guid Id { get; set; }
        public string InterviewId { get; set; } = string.Empty;
        public int QuestionId { get; set; } 
        public Interview Interview { get; set; } = null!;
        public Question Question { get; set; }
        public List<string> Results { get; set; } = null!;
        public Result() { }
        private Result(Guid id, List<string> results)
        {
            Id = id;
            Results = results;
        }

        public static Result Create(Guid id, string quaere, List<string> results)
        {
            if (id == Guid.Empty) { throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Result)} не может быть <= 0"); }

            if (results.Count == 0)
            {
                throw new NullReferenceException($"Список  {nameof(Results)} класса {nameof(Result)} не может быть пустым");
            }
            return new Result(id, results);
        }
    }
}
