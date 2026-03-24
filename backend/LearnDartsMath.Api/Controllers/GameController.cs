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
            IsFinished = false
        };

        _context.TrainingSessions.Add(session);
        await _context.SaveChangesAsync();

        var result = new GameStateDto
        {
            TrainingSessionId = session.Id,
            StartScore = session.StartScore,
            CurrentScore = session.CurrentScore,
            IsFinished = session.IsFinished,
            Mode = session.Mode,
            Throws = new List<ThrowResultDto>()
        };

        return Ok(result);
    }

    [HttpPost("throw")]
    public async Task<ActionResult<GameStateDto>> AddThrow(ThrowDto dto)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim);

        var session = await _context.TrainingSessions
            .Include(ts => ts.ThrowEntries)
            .FirstOrDefaultAsync(ts => ts.Id == dto.TrainingSessionId && ts.UserId == userId);

        if (session is null)
            return NotFound(new { message = "Training session not found." });

        if (session.IsFinished)
            return BadRequest(new { message = "Game is already finished." });

        var remainingScore = _gameService.CalculateRemainingScore(session.CurrentScore, dto.ScoredPoints);

        var throwEntry = new ThrowEntry
        {
            TrainingSessionId = session.Id,
            DartNumber = dto.DartNumber,
            ScoredPoints = dto.ScoredPoints,
            RemainingScore = remainingScore
        };

        session.CurrentScore = remainingScore;
        session.IsFinished = _gameService.IsFinished(remainingScore);

        _context.ThrowEntries.Add(throwEntry);
        await _context.SaveChangesAsync();

        var result = new GameStateDto
        {
            TrainingSessionId = session.Id,
            StartScore = session.StartScore,
            CurrentScore = session.CurrentScore,
            IsFinished = session.IsFinished,
            Mode = session.Mode,
            Throws = session.ThrowEntries
                .Append(throwEntry)
                .OrderBy(t => t.CreatedAt)
                .Select(t => new ThrowResultDto
                {
                    DartNumber = t.DartNumber,
                    ScoredPoints = t.ScoredPoints,
                    RemainingScore = t.RemainingScore,
                    CreatedAt = t.CreatedAt
                })
                .ToList()
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
            .Include(ts => ts.ThrowEntries.OrderBy(te => te.CreatedAt))
            .FirstOrDefaultAsync(ts => ts.Id == sessionId && ts.UserId == userId);

        if (session is null)
            return NotFound();

        var result = new GameStateDto
        {
            TrainingSessionId = session.Id,
            StartScore = session.StartScore,
            CurrentScore = session.CurrentScore,
            IsFinished = session.IsFinished,
            Mode = session.Mode,
            Throws = session.ThrowEntries
                .Select(t => new ThrowResultDto
                {
                    DartNumber = t.DartNumber,
                    ScoredPoints = t.ScoredPoints,
                    RemainingScore = t.RemainingScore,
                    CreatedAt = t.CreatedAt
                })
                .ToList()
        };

        return Ok(result);
    }
}