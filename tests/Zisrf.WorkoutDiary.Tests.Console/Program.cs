using Zisrf.WorkoutDiary.Core.Domain.Models;

var s = "biceps";

var muscleGroup = Enum.Parse<MuscleGroup>(s);

Console.WriteLine(muscleGroup.ToString());