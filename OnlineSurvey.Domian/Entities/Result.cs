using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Result: Entity
    {
        public Interview Interview { get; set; } = null!;
        public string InterviewId { get; set; }
        public Dictionary<string, List<string>> Results { get; set; } = null!;

        public Result() { }
        private Result(int id) 
        {
            Id = id;
        }

        public static Result Create(int id)
        {
            if (id <= 0) { throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Result)} не может быть <= 0"); }

            return new Result(id);
        }
    }
}
