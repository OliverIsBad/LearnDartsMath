namespace LearnDartsMath.Api.DTOs;

public class TurnHistoryDto
{
    public int PreviousScore { get; set; }
    public int EnteredScoredPoints { get; set; }
    public int EnteredRemainingScore { get; set; }
    public int CorrectRemainingScore { get; set; }
    public bool IsCorrect { get; set; }
    public DateTime CreatedAt { get; set; }
}