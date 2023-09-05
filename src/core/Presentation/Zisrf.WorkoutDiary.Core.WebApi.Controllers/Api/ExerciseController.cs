using Microsoft.AspNetCore.Mvc;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.WebApi.Abstractions.Requests.Exercises;

namespace Zisrf.WorkoutDiary.Core.WebApi.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class ExerciseController : ControllerBase
{
    private readonly IExerciseService _exerciseService;

    public ExerciseController(IExerciseService exerciseService)
    {
        _exerciseService = exerciseService;
    }

    private CancellationToken CancellationToken => HttpContext.RequestAborted;

    [HttpPost]
    public async Task<ActionResult<ExerciseDto>> CreateAsync([FromBody] CreateExerciseRequest request)
    {
        var exercise = await _exerciseService.CreateAsync(
            request.Name,
            request.MuscleGroup,
            CancellationToken);

        return Ok(exercise);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyCollection<ExerciseDto>>> GetAsync()
    {
        var exercises = await _exerciseService.GetAsync(CancellationToken);

        return Ok(exercises);
    }

    [HttpGet("{exerciseId:guid}")]
    public async Task<ActionResult<ExerciseDto>> GetByIdAsync(Guid exerciseId)
    {
        var exercise = await _exerciseService.GetByIdAsync(exerciseId, CancellationToken);

        return Ok(exercise);
    }

    [HttpPut("{exerciseId:guid}/update-name")]
    public async Task<IActionResult> UpdateNameAsync(
        Guid exerciseId,
        [FromBody] UpdateExerciseNameRequest request)
    {
        await _exerciseService.UpdateNameAsync(
            exerciseId,
            request.NewName,
            CancellationToken);

        return Ok();
    }

    [HttpPut("{exerciseId:guid}/update-muscle-group")]
    public async Task<IActionResult> UpdateMuscleGroupAsync(
        Guid exerciseId,
        [FromBody] UpdateExerciseMuscleGroupRequest request)
    {
        await _exerciseService.UpdateMuscleGroupAsync(
            exerciseId,
            request.NewMuscleGroup,
            CancellationToken);

        return Ok();
    }

    [HttpDelete("{exerciseId:guid}")]
    public async Task<IActionResult> RemoveAsync(Guid exerciseId)
    {
        await _exerciseService.RemoveAsync(exerciseId, CancellationToken);

        return Ok();
    }
}