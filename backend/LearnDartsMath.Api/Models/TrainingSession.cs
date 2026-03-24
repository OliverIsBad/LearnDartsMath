
namespace LearnDartsMath.Api.Models;
public class TrainingSession
{
    public int Id { get; set; }

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    public DateTime? FinishedAt { get; set; }

    public string Mode { get; set; } = "x01";
    public int StartScore { get; set; } = 501;
    public int CurrentScore { get; set; } = 501;
    public bool IsFinished { get; set; }

    public ICollection<TurnEntry> TurnEntries { get; set; } = new List<TurnEntry>();
}