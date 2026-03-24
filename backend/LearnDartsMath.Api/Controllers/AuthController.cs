using LearnDartsMath.Api.Data;
using LearnDartsMath.Api.DTOs;
using LearnDartsMath.Api.Models;
using LearnDartsMath.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnDartsMath.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly PasswordService _passwordService;
    private readonly TokenService _tokenService;

    public AuthController(
        AppDbContext context,
        PasswordService passwordService,
        TokenService tokenService)
    {
        _context = context;
        _passwordService = passwordService;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<AuthResponseDto>> Register(RegisterDto dto)
    {
        var usernameExists = await _context.Users.AnyAsync(u => u.Username == dto.Username);
        if (usernameExists)
        {
            return BadRequest(new { message = "Username is already taken." });
        }

        var emailExists = await _context.Users.AnyAsync(u => u.Email == dto.Email);
        if (emailExists)
        {
            return BadRequest(new { message = "Email is already in use." });
        }

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email
        };

        user.PasswordHash = _passwordService.HashPassword(user, dto.Password);

        var profile = new PlayerProfile
        {
            User = user,
            DisplayName = dto.DisplayName
        };

        _context.Users.Add(user);
        _context.PlayerProfiles.Add(profile);

        await _context.SaveChangesAsync();

        var token = _tokenService.CreateToken(user);

        var response = new AuthResponseDto
        {
            Token = token,
            Username = user.Username,
            Email = user.Email,
            DisplayName = profile.DisplayName
        };

        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<ActionResult<AuthResponseDto>> Login(LoginDto dto)
    {
        var user = await _context.Users
            .Include(u => u.PlayerProfile)
            .FirstOrDefaultAsync(u =>
                u.Username == dto.UsernameOrEmail ||
                u.Email == dto.UsernameOrEmail);

        if (user is null)
        {
            return Unauthorized(new { message = "Invalid username/email or password." });
        }

        var passwordValid = _passwordService.VerifyPassword(user, dto.Password);
        if (!passwordValid)
        {
            return Unauthorized(new { message = "Invalid username/email or password." });
        }

        var token = _tokenService.CreateToken(user);

        var response = new AuthResponseDto
        {
            Token = token,
            Username = user.Username,
            Email = user.Email,
            DisplayName = user.PlayerProfile?.DisplayName ?? user.Username
        };

        return Ok(response);
    }
}