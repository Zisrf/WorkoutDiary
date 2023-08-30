using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.Application.Extensions;
using Zisrf.WorkoutDiary.Core.Application.Mapping;
using Zisrf.WorkoutDiary.Core.DataAccess.Abstractions.Contexts;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Application.Services;

internal class ActivityService : IActivityService
{
    private readonly IApplicationDbContext _context;

    public ActivityService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ActivityDto> GetByIdAsync(Guid activityId, CancellationToken cancellationToken = default)
    {
        var activity = await _context.Activities.GetByIdAsync(activityId, cancellationToken);

        return activity.ToDto();
    }

    public async Task UpdateWorkingWeightAsync(
        Guid activityId,
        double newWorkingWeight,
        CancellationToken cancellationToken = default)
    {
        var activity = await _context.Activities.GetByIdAsync(activityId, cancellationToken);

        activity.WorkingWeight = new WorkingWeight(newWorkingWeight);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateRepetitionsCountAsync(
        Guid activityId,
        int newRepetitionsCount,
        CancellationToken cancellationToken = default)
    {
        var activity = await _context.Activities.GetByIdAsync(activityId, cancellationToken);

        activity.RepetitionsCount = new RepetitionsCount(newRepetitionsCount);

        await _context.SaveChangesAsync(cancellationToken);
    }
}