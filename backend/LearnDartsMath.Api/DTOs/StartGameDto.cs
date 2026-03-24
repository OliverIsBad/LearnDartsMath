using System.ComponentModel.DataAnnotations;

namespace LearnDartsMath.Api.DTOs;

public class StartGameDto
{
    [Range(1, 1001)]
    public int StartScore { get; set; } = 501;

    [Required]
    [MaxLength(50)]
    public string Mode { get; set; } = "x01";
}