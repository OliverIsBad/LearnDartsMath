using System.ComponentModel.DataAnnotations;

namespace LearnDartsMath.Api.DTOs;

public class ThrowDto
{
    [Range(1, int.MaxValue)]
    public int TrainingSessionId { get; set; }

    [Range(1, 3)]
    public int DartNumber { get; set; }

    [Range(0, 60)]
    public int ScoredPoints { get; set; }
}