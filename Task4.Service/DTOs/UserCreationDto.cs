using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Task4.Service.DTOs;

public class UserCreationDto
{
    [Required]
    public string Name { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    [PasswordPropertyText]
    public string Password { get; set; }
}