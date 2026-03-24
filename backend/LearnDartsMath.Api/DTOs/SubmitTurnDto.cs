using System.ComponentModel.DataAnnotations;

namespace LearnDartsMath.Api.DTOs;

public class SubmitTurnDto
{
    [Range(1, int.MaxValue)]
    public int TrainingSessionId { get; set; }

    [Range(0, 180)]
    public int EnteredScoredPoints { get; set; }

    [Range(0, 1000)]
    public int EnteredRemainingScore { get; set; }
}