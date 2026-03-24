namespace LearnDartsMath.Api.Models;

public class TurnEntry
{
    public int Id { get; set; }

    public int TrainingSessionId { get; set; }
    public TrainingSession TrainingSession { get; set; } = null!;

    public int PreviousScore { get; set; }
    public int EnteredScoredPoints { get; set; }
    public int EnteredRemainingScore { get; set; }

    public int CorrectRemainingScore { get; set; }

    public bool IsScoreValid { get; set; }
    public bool IsRemainingCorrect { get; set; }
    public bool IsCorrect { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}