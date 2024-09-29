using Mapster;
using OnlineSurvey.Api.Models;
using OnlineSurvey.Application.DTOs;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Api.Mapping
{
    internal class RegisterMapper : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<SurveyModel, SurveyDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<QuestionModel, QuestionDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<AnswerModel, AnswerDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<InterviewModel, InterviewDto>()
                .RequireDestinationMemberSource(true);
            config.NewConfig<ResultModel, ResultDto>()
                .RequireDestinationMemberSource(true);
        }
    }
}
