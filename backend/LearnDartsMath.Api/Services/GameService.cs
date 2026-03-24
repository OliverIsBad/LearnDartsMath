namespace LearnDartsMath.Api.Services;

public class GameService
{
    public bool IsScoreValid(int score)
    {
        return score >= 0 && score <= 180;
    }

    public int CalculateRemainingScore(int previousScore, int scoredPoints)
    {
        return previousScore - scoredPoints;
    }

    public bool IsRemainingCorrect(int enteredRemainingScore, int correctRemainingScore)
    {
        return enteredRemainingScore == correctRemainingScore;
    }
}