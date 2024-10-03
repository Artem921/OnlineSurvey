using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Answer: Entity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public IEnumerable<string> Replys { get; set; }
        public Answer() { }
        private Answer(int id, int questionId, IEnumerable<string> replys)
        {
            Id = id;
            QuestionId = questionId;
            Replys = replys;
        }

        public static Answer Create(int id, int questionId, IEnumerable<string> replys)
        {
            if (id <= 0)
            {
                throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Answer)} не может быть <= 0");
            }

            if (questionId <= 0)
            {
                throw new ArgumentNullException($"Свойство{nameof(QuestionId)} класса  {nameof(Answer)} не может быть <= 0");
            }
            if (replys is null)
            {
                throw new ArgumentNullException($" Свойство{nameof(Replys)} класса {nameof(Answer)} не может быть пустым");
            }
            return new Answer(id, questionId, replys);
        }
    }
}
