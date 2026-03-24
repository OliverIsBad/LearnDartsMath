namespace LearnDartsMath.Api.DTOs;
public class ThrowResultDto
{
    public int DartNumber { get; set; }
    public int ScoredPoints { get; set; }
    public int RemainingScore { get; set; }
    public DateTime CreatedAt { get; set; }
}