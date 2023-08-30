using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zisrf.WorkoutDiary.Core.Domain.Entities;

namespace Zisrf.WorkoutDiary.Core.DataAccess.EntityConfigurations;

internal class ActivityConfiguration : IEntityTypeConfiguration<Activity>
{
    public void Configure(EntityTypeBuilder<Activity> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Exercise).WithMany();

        builder.Property(x => x.Id);
        builder.Navigation(x => x.Exercise);
        builder.Property(x => x.WorkingWeight);
        builder.Property(x => x.RepetitionsCount);
    }
}