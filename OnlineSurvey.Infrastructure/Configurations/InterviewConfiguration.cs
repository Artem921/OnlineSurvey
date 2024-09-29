using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineSurvey.Domian.Entities;

namespace OnlineSurvey.Infrastructure.Configurations
{
    internal class InterviewConfiguration : IEntityTypeConfiguration<Interview>
    {
        public void Configure(EntityTypeBuilder<Interview> builder)
        {
            builder.ToTable("Interview").HasKey(q => q.Id);
            builder.HasMany(i => i.Results)
                .WithOne(r => r.Interview )
                .HasForeignKey(r => r.InterviewId);                
        }
    }
}
