using Microsoft.AspNetCore.Mvc;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.WebApi.Abstractions.Requests.Activities;

namespace Zisrf.WorkoutDiary.Core.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;

    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }

    private CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpGet("{activityId:guid}")]
    public async Task<ActionResult<ActivityDto>> GetByIdAsync(Guid activityId)
    {
        var activity = await _activityService.GetByIdAsync(activityId, CancellationToken);

        return Ok(activity);
    }

    [HttpPut("{activityId:guid}/update-working-weight")]
    public async Task<IActionResult> UpdateWorkingWeightAsync(
        Guid activityId,
        [FromBody] UpdateActivityWorkingWeightRequest request)
    {
        await _activityService.UpdateWorkingWeightAsync(
            activityId,
            request.NewWorkingWeight,
            CancellationToken);

        return Ok();
    }

    [HttpPut("{activityId:guid}/update-repetitions-count")]
    public async Task<IActionResult> UpdateRepetitionsCountAsync(
        Guid activityId,
        [FromBody] UpdateActivityRepetitionsCountRequest request)
    {
        await _activityService.UpdateRepetitionsCountAsync(
            activityId,
            request.NewRepetitionsCount,
            CancellationToken);

        return Ok();
    }
}