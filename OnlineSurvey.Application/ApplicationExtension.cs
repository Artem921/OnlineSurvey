using Framework.Utils;
using Microsoft.Extensions.DependencyInjection;
using OnlineSurvey.Application.Mapping;
using OnlineSurvey.Application.Services.Abstraction;
using OnlineSurvey.Application.Services;

namespace OnlineSurvey.Application
{
    public class ApplicationExtension : ExtensionBase
    {
        public override void Load(IServiceCollection services)
        {
            services.AddInfrastructureMapping();
            services.AddScoped<IInterviewService, InterviewService>();
            services.AddScoped<ISurveyService, SurveyService>();

        }
    }
}
