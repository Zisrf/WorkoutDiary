using Microsoft.EntityFrameworkCore;
using Zisrf.WorkoutDiary.Core.DataAccess.Abstractions.Contexts;
using Zisrf.WorkoutDiary.Core.DataAccess.Tools;
using Zisrf.WorkoutDiary.Core.Domain.Entities;

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
}