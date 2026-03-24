namespace LearnDartsMath.Api.Models;

public class TrainingSession
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    public string Mode { get; set; } = string.Empty;

    public int StartScore { get; set; }
    public int CurrentScore { get; set; }
    public bool IsFinished { get; set; }

    public ICollection<ThrowEntry> ThrowEntries { get; set; } = new List<ThrowEntry>();
}