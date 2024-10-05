using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Answer: Entity
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; } = null!;
        /// <summary>
        /// Список вариантов ответов
        /// </summary>
        public List<string> Replys { get; set; } = null!;
        private Answer(int id, int questionId, List<string> replys)
        {
            Id = id;
            QuestionId = questionId;
            Replys = replys;
        }

        public static Answer Create(int id, int questionId, List<string> replys)
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
