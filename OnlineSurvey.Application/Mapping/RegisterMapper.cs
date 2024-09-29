using Mapster;
using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Application.Mapping
{
    internal class RegisterMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Survey, SurveyDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<Question, QuestionDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<Answer, AnswerDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<Interview, InterviewDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<Result, ResultDto>()
                .RequireDestinationMemberSource(true);
        }
    }
}
