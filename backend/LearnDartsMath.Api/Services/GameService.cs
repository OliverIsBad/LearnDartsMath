using LearnDartsMath.Api.Models;

namespace LearnDartsMath.Api.Services;

public class GameService
{
    public int CalculateRemainingScore(int currentScore, int scoredPoints)
    {
        var newScore = currentScore - scoredPoints;

        if (newScore < 0)
        {
            return currentScore;
        }

        return newScore;
    }

    public bool IsFinished(int remainingScore)
    {
        return remainingScore == 0;
    }
}