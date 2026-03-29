using System.Security.Claims;
using LearnDartsMath.Api.Data;
using LearnDartsMath.Api.DTOs;
using LearnDartsMath.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnDartsMath.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TrainingSessionsController : ControllerBase
{
    private readonly AppDbContext _context;

    public TrainingSessionsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> SaveSession(SaveTrainingSessionDto dto)
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
            CurrentScore = dto.FinalScore,
            IsFinished = dto.IsFinished,
            StartedAt = dto.StartedAt,
            FinishedAt = dto.FinishedAt,
            TurnEntries = dto.Turns.Select(t => new TurnEntry
            {
                PreviousScore = t.PreviousScore,
                EnteredScoredPoints = t.EnteredScoredPoints,
                EnteredRemainingScore = t.EnteredRemainingScore,
                CorrectRemainingScore = t.CorrectRemainingScore,
                IsScoreValid = t.IsScoreValid,
                IsRemainingCorrect = t.IsRemainingCorrect,
                IsCorrect = t.IsCorrect,
                CreatedAt = t.CreatedAt
            }).ToList()
        };

        _context.TrainingSessions.Add(session);
        await _context.SaveChangesAsync();

        return Ok(new { sessionId = session.Id });
    }

    [HttpGet]
    public async Task<ActionResult> GetSessions()
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim);

        var sessions = await _context.TrainingSessions
            .Where(ts => ts.UserId == userId)
            .OrderByDescending(ts => ts.StartedAt)
            .Select(ts => new
            {
                ts.Id,
                ts.Mode,
                ts.StartScore,
                ts.CurrentScore,
                ts.IsFinished,
                ts.StartedAt,
                ts.FinishedAt
            })
            .ToListAsync();

        return Ok(sessions);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetSessionById(int id)
    {
        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userIdClaim is null)
            return Unauthorized();

        var userId = int.Parse(userIdClaim);

        var session = await _context.TrainingSessions
            .Include(ts => ts.TurnEntries)
            .FirstOrDefaultAsync(ts => ts.Id == id && ts.UserId == userId);

        if (session is null)
            return NotFound();

        return Ok(new
        {
            session.Id,
            session.Mode,
            session.StartScore,
            session.CurrentScore,
            session.IsFinished,
            session.StartedAt,
            session.FinishedAt,
            Turns = session.TurnEntries
                .OrderBy(t => t.CreatedAt)
                .Select(t => new
                {
                    t.Id,
                    t.PreviousScore,
                    t.EnteredScoredPoints,
                    t.EnteredRemainingScore,
                    t.CorrectRemainingScore,
                    t.IsScoreValid,
                    t.IsRemainingCorrect,
                    t.IsCorrect,
                    t.CreatedAt
                })
        });
    }
}