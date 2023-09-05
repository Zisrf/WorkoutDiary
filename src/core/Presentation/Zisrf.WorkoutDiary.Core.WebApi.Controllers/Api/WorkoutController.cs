using Microsoft.AspNetCore.Mvc;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.WebApi.Abstractions.Requests.Workouts;

namespace Zisrf.WorkoutDiary.Core.WebApi.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class WorkoutController : ControllerBase
{
    private readonly IWorkoutService _workoutService;

    public WorkoutController(IWorkoutService workoutService)
    {
        _workoutService = workoutService;
    }

    private CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    public async Task<ActionResult<WorkoutDto>> CreateAsync([FromBody] CreateWorkoutRequest request)
    {
        var workout = await _workoutService.CreateAsync(request.Date, CancellationToken);

        return Ok(workout);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<WorkoutDto>>> GetAsync()
    {
        var workouts = await _workoutService.GetAsync(CancellationToken);

        return Ok(workouts);
    }

    [HttpGet("{workoutId:guid}")]
    public async Task<ActionResult<WorkoutDto>> GetByIdAsync(Guid workoutId)
    {
        var workout = await _workoutService.GetByIdAsync(workoutId, CancellationToken);

        return Ok(workout);
    }

    [HttpGet("{workoutId:guid}/activities")]
    public async Task<ActionResult<IReadOnlyCollection<ActivityDto>>> GetActivitiesAsync(Guid workoutId)
    {
        var activities = await _workoutService.GetActivitiesAsync(workoutId, CancellationToken);

        return Ok(activities);
    }

    [HttpGet("{workoutId:guid}/involved-muscle-groups")]
    public async Task<ActionResult<IReadOnlyCollection<ActivityDto>>> GetInvolvedMuscleGroupsAsync(Guid workoutId)
    {
        var muscleGroups = await _workoutService.GetInvolvedMuscleGroupsAsync(workoutId, CancellationToken);

        return Ok(muscleGroups);
    }

    [HttpGet("{workoutId:guid}/not-involved-muscle-groups")]
    public async Task<ActionResult<IReadOnlyCollection<ActivityDto>>> GetNotInvolvedMuscleGroupsAsync(Guid workoutId)
    {
        var muscleGroups = await _workoutService.GetNotInvolvedMuscleGroupsAsync(workoutId, CancellationToken);

        return Ok(muscleGroups);
    }

    [HttpPut("{workoutId:guid}/update-date")]
    public async Task<IActionResult> UpdateDateAsync(Guid workoutId, [FromBody] UpdateWorkoutDateRequest request)
    {
        await _workoutService.UpdateDateAsync(workoutId, request.NewDate, CancellationToken);

        return Ok();
    }

    [HttpPut("{workoutId:guid}/add-activity")]
    public async Task<ActionResult<ActivityDto>> AddActivityAsync(Guid workoutId, [FromBody] AddActivityRequest request)
    {
        var activity = await _workoutService.AddActivityAsync(
            workoutId,
            request.ExerciseId,
            request.WorkingWeight,
            request.RepetitionsCount,
            CancellationToken);

        return Ok(activity);
    }

    [HttpPut("{workoutId:guid}/update-activity-order")]
    public async Task<IActionResult> UpdateActivityOrderAsync(
        Guid workoutId,
        [FromBody] UpdateActivityOrderRequest request)
    {
        await _workoutService.UpdateActivityOrderAsync(
            workoutId,
            request.ActivityId,
            request.NewOrder,
            CancellationToken);

        return Ok();
    }

    [HttpPut("{workoutId:guid}/remove-activity")]
    public async Task<IActionResult> RemoveActivityAsync(Guid workoutId, [FromBody] RemoveActivityRequest request)
    {
        await _workoutService.RemoveActivityAsync(
            workoutId,
            request.ActivityId,
            CancellationToken);

        return Ok();
    }

    [HttpDelete("{workoutId:guid}")]
    public async Task<IActionResult> RemoveAsync(Guid workoutId)
    {
        await _workoutService.RemoveAsync(workoutId, CancellationToken);

        return Ok();
    }
}