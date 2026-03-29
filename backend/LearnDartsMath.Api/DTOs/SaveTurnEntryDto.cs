namespace LearnDartsMath.Api.DTOs;

public class SaveTurnEntryDto
{
    public int PreviousScore { get; set; }
    public int EnteredScoredPoints { get; set; }
    public int EnteredRemainingScore { get; set; }
    public int CorrectRemainingScore { get; set; }

    public bool IsScoreValid { get; set; }
    public bool IsRemainingCorrect { get; set; }
    public bool IsCorrect { get; set; }

    public DateTime CreatedAt { get; set; }
}