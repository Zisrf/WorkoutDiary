using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zisrf.WorkoutDiary.Core.Domain.Entities;

namespace Zisrf.WorkoutDiary.Core.DataAccess.EntityConfigurations;

internal class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
{
    public void Configure(EntityTypeBuilder<Workout> builder)
    {
        builder.HasKey(x => x.Id);

        builder.HasMany(x => x.Activities).WithOne();

        builder.Property(x => x.Id);
        builder.Property(x => x.Date);
        builder.Navigation(x => x.Activities).HasField("_activities");
    }
}