using OnlineSurvey.Domian.Entities.Base;

namespace OnlineSurvey.Domian.Entities
{
    internal class Question: Entity
    {
        public int SurveyId { get; set; }
        public Survey? Survey { get; set; } 
        public string? Quaere { get; set; }
        public Answer? Answer { get; set; } 

        private Question(int id,int surveyId,string quaere) 
        {     
            Id = id;
            Quaere = quaere; 
            SurveyId = surveyId;
        }

        public static Question Create(int id, int surveyId, string quaere)
        {
            if (id <= 0)
            { 
               throw new ArgumentNullException($" Свойство{nameof(Id)} класса {nameof(Question)} не может быть <= 0"); 
            }
            if (surveyId <= 0)
            {
                throw new ArgumentNullException($" Свойство{nameof(SurveyId)} класса {nameof(Question)} не может быть <= 0");
            }
            if (string.IsNullOrEmpty(quaere))
            {
                throw new NullReferenceException($"Свойство {nameof(Quaere)} класса {nameof(Question)} не может быть пустым");
            }
   
            return new Question(id , surveyId,quaere);
            
        }
    }
}
