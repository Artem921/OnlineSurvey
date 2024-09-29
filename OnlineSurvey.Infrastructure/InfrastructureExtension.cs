using Framework.Utils;
using Microsoft.Extensions.DependencyInjection;
using OnlineSurvey.Domian.Abstraction;
using OnlineSurvey.Infrastructure.Repositories;

namespace OnlineSurvey.Infrastructure
{
    internal class InfrastructureExtension : ExtensionBase
    {
        public override void Load(IServiceCollection services)
        {
            services.AddScoped<IInterviewRepository, InterviewRepository>();
            services.AddScoped<ISurveyRepository, SurveyRepository>();
            services.AddScoped<AppDbContext>();
        }
    }
}
