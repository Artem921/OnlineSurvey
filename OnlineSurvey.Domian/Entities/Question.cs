using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Question: Entity
    {
        public int SurveyId { get; set; } 
        public int NumberOfAnswers { get; set; }
        public Survey Survey { get; set; } = null!;
        public string Quaere { get; set; } = null!;
        public  Answer Answer { get; set; } = null!;

        private Question(int id,string quaere,int numberOfAnswers) 
        {     
            Id = id;
            Quaere = quaere; 
            NumberOfAnswers = numberOfAnswers;
        }

        public static Question Create(int id, string quaere, int numberOfAnswers)
        {
            if (id <= 0)
            { 
               throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Question)} не может быть <= 0"); 
            }

            if (string.IsNullOrEmpty(quaere))
            {
                throw new NullReferenceException($"Свойство {nameof(Quaere)} класса {nameof(Question)} не может быть пустым");
            }
            if( numberOfAnswers <=0 )
            {
                throw new ArgumentException($" Свойство{nameof(NumberOfAnswers)} класса {nameof(Question)} не может быть <= 0");
            }
            return new Question(id ,quaere,numberOfAnswers);
            
        }
    }
}
