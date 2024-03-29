﻿using Microsoft.EntityFrameworkCore;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Dto;
using Zisrf.WorkoutDiary.Core.Application.Contracts.Services;
using Zisrf.WorkoutDiary.Core.Application.Extensions;
using Zisrf.WorkoutDiary.Core.Application.Mapping;
using Zisrf.WorkoutDiary.Core.DataAccess.Abstractions.Contexts;
using Zisrf.WorkoutDiary.Core.Domain.Entities;
using Zisrf.WorkoutDiary.Core.Domain.Extensions;
using Zisrf.WorkoutDiary.Core.Domain.Models;

namespace Zisrf.WorkoutDiary.Core.Application.Services;

internal class ExerciseService : IExerciseService
{
    private readonly IApplicationDbContext _context;

    public ExerciseService(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ExerciseDto> CreateAsync(
        string name,
        string muscleGroup,
        CancellationToken cancellationToken = default)
    {
        var exercise = new Exercise(
            Guid.NewGuid(),
            new ExerciseName(name),
            muscleGroup.ToMuscleGroup());

        _context.Exercises.Add(exercise);

        await _context.SaveChangesAsync(cancellationToken);

        return exercise.ToDto();
    }

    public async Task<IReadOnlyCollection<ExerciseDto>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Exercises
            .Select(x => x.ToDto())
            .ToListAsync(cancellationToken);
    }

    public async Task<ExerciseDto> GetByIdAsync(Guid exerciseId, CancellationToken cancellationToken = default)
    {
        var exercise = await _context.Exercises.GetByIdAsync(exerciseId, cancellationToken);

        return exercise.ToDto();
    }

    public async Task UpdateNameAsync(
        Guid exerciseId,
        string newName,
        CancellationToken cancellationToken = default)
    {
        var exercise = await _context.Exercises.GetByIdAsync(exerciseId, cancellationToken);

        exercise.Name = new ExerciseName(newName);

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateMuscleGroupAsync(
        Guid exerciseId,
        string newMuscleGroup,
        CancellationToken cancellationToken = default)
    {
        var exercise = await _context.Exercises.GetByIdAsync(exerciseId, cancellationToken);

        exercise.MuscleGroup = newMuscleGroup.ToMuscleGroup();

        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task RemoveAsync(Guid exerciseId, CancellationToken cancellationToken = default)
    {
        var exercise = await _context.Exercises.GetByIdAsync(exerciseId, cancellationToken);

        _context.Exercises.Remove(exercise);

        await _context.SaveChangesAsync(cancellationToken);
    }
}