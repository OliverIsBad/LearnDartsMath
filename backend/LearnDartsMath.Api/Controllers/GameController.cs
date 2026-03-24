using System.Security.Claims;
using LearnDartsMath.Api.Data;
using LearnDartsMath.Api.DTOs;
using LearnDartsMath.Api.Models;
using LearnDartsMath.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnDartsMath.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class GameController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly GameService _gameService;

    public GameController(AppDbContext context, GameService gameService)
    {
        _context = context;
        _gameService = gameService;
    }

    [HttpPost("start")]
    public async Task<ActionResult<GameStateDto>> StartGame(StartGameDto dto)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim);

        var session = new TrainingSession
        {
            UserId = userId,
            Mode = dto.Mode,
            StartScore = dto.StartScore,
            CurrentScore = dto.StartScore,
            IsFinished = false,
            StartedAt = DateTime.UtcNow
        };

        _context.TrainingSessions.Add(session);
        await _context.SaveChangesAsync();

        var result = new GameStateDto
        {
            TrainingSessionId = session.Id,
            StartScore = session.StartScore,
            CurrentScore = session.CurrentScore,
            IsFinished = session.IsFinished,
            Mode = session.Mode
        };

        return Ok(result);
    }

    [HttpPost("submit-turn")]
    public async Task<ActionResult<TurnResultDto>> SubmitTurn(SubmitTurnDto dto)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim);

        var session = await _context.TrainingSessions
            .Include(ts => ts.TurnEntries)
            .FirstOrDefaultAsync(ts => ts.Id == dto.TrainingSessionId && ts.UserId == userId);

        if (session is null)
            return NotFound(new { message = "Training session not found." });

        if (session.IsFinished)
            return BadRequest(new { message = "Session is already finished." });

        var previousScore = session.CurrentScore;
        var isScoreValid = _gameService.IsScoreValid(dto.EnteredScoredPoints);
        var correctRemainingScore = _gameService.CalculateRemainingScore(previousScore, dto.EnteredScoredPoints);
        var isRemainingCorrect = _gameService.IsRemainingCorrect(dto.EnteredRemainingScore, correctRemainingScore);

        var isCorrect = isScoreValid && isRemainingCorrect && correctRemainingScore >= 0;

        if (isCorrect)
        {
            session.CurrentScore = correctRemainingScore;

            if (session.CurrentScore == 0)
            {
                session.IsFinished = true;
                session.FinishedAt = DateTime.UtcNow;
            }
        }

        var turnEntry = new TurnEntry
        {
            TrainingSessionId = session.Id,
            PreviousScore = previousScore,
            EnteredScoredPoints = dto.EnteredScoredPoints,
            EnteredRemainingScore = dto.EnteredRemainingScore,
            CorrectRemainingScore = correctRemainingScore,
            IsScoreValid = isScoreValid,
            IsRemainingCorrect = isRemainingCorrect,
            IsCorrect = isCorrect,
            CreatedAt = DateTime.UtcNow
        };

        _context.TurnEntries.Add(turnEntry);
        await _context.SaveChangesAsync();

        var result = new TurnResultDto
        {
            PreviousScore = previousScore,
            EnteredScoredPoints = dto.EnteredScoredPoints,
            EnteredRemainingScore = dto.EnteredRemainingScore,
            CorrectRemainingScore = correctRemainingScore,
            IsScoreValid = isScoreValid,
            IsRemainingCorrect = isRemainingCorrect,
            IsCorrect = isCorrect,
            NewCurrentScore = session.CurrentScore
        };

        return Ok(result);
    }

    [HttpGet("{sessionId}")]
    public async Task<ActionResult<GameStateDto>> GetGameState(int sessionId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim);

        var session = await _context.TrainingSessions
            .FirstOrDefaultAsync(ts => ts.Id == sessionId && ts.UserId == userId);

        if (session is null)
            return NotFound();

        var result = new GameStateDto
        {
            TrainingSessionId = session.Id,
            StartScore = session.StartScore,
            CurrentScore = session.CurrentScore,
            IsFinished = session.IsFinished,
            Mode = session.Mode
        };

        return Ok(result);
    }

    [HttpGet("{sessionId}/turns")]
    public async Task<ActionResult<IEnumerable<TurnHistoryDto>>> GetTurns(int sessionId)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim);

        var sessionExists = await _context.TrainingSessions
            .AnyAsync(ts => ts.Id == sessionId && ts.UserId == userId);

        if (!sessionExists)
            return NotFound();

        var turns = await _context.TurnEntries
            .Where(t => t.TrainingSessionId == sessionId)
            .OrderBy(t => t.CreatedAt)
            .Select(t => new TurnHistoryDto
            {
                PreviousScore = t.PreviousScore,
                EnteredScoredPoints = t.EnteredScoredPoints,
                EnteredRemainingScore = t.EnteredRemainingScore,
                CorrectRemainingScore = t.CorrectRemainingScore,
                IsCorrect = t.IsCorrect,
                CreatedAt = t.CreatedAt
            })
            .ToListAsync();

        return Ok(turns);
    }
}