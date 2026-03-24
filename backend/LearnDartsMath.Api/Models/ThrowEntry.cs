namespace LearnDartsMath.Api.Models;

public class ThrowEntry
{
    public int Id { get; set; }

    public int TrainingSessionId { get; set; }
    public TrainingSession TrainingSession { get; set; } = null!;

    public int DartNumber { get; set; }
    public int ScoredPoints { get; set; }
    public int RemainingScore { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}