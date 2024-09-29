using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Infrastructure.Configurations
{
    internal class ResultConfiguration : IEntityTypeConfiguration<Result>
    {

        public void Configure(EntityTypeBuilder<Result> builder)
        {
            builder.ToTable("Results");
            builder.Property(r => r.Results)
                .HasConversion(
                c => JsonConvert.SerializeObject(c),
                c => JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(c));
          
        }
    }
}
