using Microsoft.EntityFrameworkCore;
using Zisrf.WorkoutDiary.Core.Domain.Entities;

namespace Zisrf.WorkoutDiary.Core.DataAccess.Abstractions.Contexts;

public interface IApplicationDbContext
{
    DbSet<Exercise> Exercises { get; }

    DbSet<Activity> Activities { get; }

    DbSet<Workout> Workouts { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}