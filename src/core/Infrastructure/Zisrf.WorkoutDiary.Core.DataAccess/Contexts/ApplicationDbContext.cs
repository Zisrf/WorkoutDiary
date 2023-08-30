using Microsoft.EntityFrameworkCore;
using Zisrf.WorkoutDiary.Core.DataAccess.Abstractions.Contexts;
using Zisrf.WorkoutDiary.Core.DataAccess.Tools;
using Zisrf.WorkoutDiary.Core.DataAccess.ValueConverters;
using Zisrf.WorkoutDiary.Core.Domain.Entities;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.DataAccess.Contexts;

internal class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Exercise> Exercises { get; init; } = null!;

    public DbSet<Activity> Activities { get; init; } = null!;

    public DbSet<Workout> Workouts { get; init; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IAssemblyMarker).Assembly);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<ExerciseName>().HaveConversion<ExerciseNameConverter>();

        configurationBuilder.Properties<WorkingWeight>().HaveConversion<WorkingWeightConverter>();
        configurationBuilder.Properties<RepetitionsCount>().HaveConversion<RepetitionsCountConverter>();
    }
}