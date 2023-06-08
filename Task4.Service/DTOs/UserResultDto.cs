using Task4.Domain.Enums;

namespace Task4.Service.DTOs;

public class UserResultDto
{
    public long Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public Status Status { get; set; }
    public DateTime LastLoginTime { get; set; }
}