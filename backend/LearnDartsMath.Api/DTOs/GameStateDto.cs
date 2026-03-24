namespace LearnDartsMath.Api.DTOs;

public class GameStateDto
{
    public int TrainingSessionId { get; set; }
    public int StartScore { get; set; }
    public int CurrentScore { get; set; }
    public bool IsFinished { get; set; }
    public string Mode { get; set; } = string.Empty;
    public List<ThrowResultDto> Throws { get; set; } = new();
}

