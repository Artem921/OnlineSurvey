namespace OnlineSurvey.Domian.Entities
{
    internal class Result
    {
        public Guid? Id { get; set; }
        public string? InterviewId { get; set; } 
        public Interview? Interview { get; set; }
        /// <summary>
        /// список выбраных вариантов ответов на вопрос
        /// </summary>
        public List<string> Results { get; set; } = null!;
        public int QuestionId { get; set; }
        public Result() { }
        private Result(Guid id, string interviewId,int questionId, List<string> results)
        {
            Id = id;
            InterviewId = interviewId;
            Results = results;
            QuestionId = questionId;
        }

        public static Result Create(Guid id, string interviewId, int questionId, List<string> results)
        {
            if (id == Guid.Empty) { throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Result)} не может быть пустым"); }

            if (string.IsNullOrEmpty(interviewId))
            {
                throw new NullReferenceException($"Свойство {nameof(InterviewId)} класса {nameof(Result)} не может быть пустым");
            }
            if (questionId == 0)
            {
                throw new NullReferenceException($"Свойство {nameof(InterviewId)} класса {nameof(Result)} не может быть пустым");
            }
            if (results is null)
            {
                throw new NullReferenceException($"Список  {nameof(Results)} класса {nameof(Result)} не может быть пустым");
            }
            return new Result(id,interviewId, questionId,results);
        }
    }
}
