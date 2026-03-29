namespace LearnDartsMath.Api.DTOs;

public class SaveTrainingSessionDto
{
    public string Mode { get; set; } = "x01";
    public int StartScore { get; set; }
    public int FinalScore { get; set; }
    public bool IsFinished { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }

    public List<SaveTurnEntryDto> Turns { get; set; } = new();
}