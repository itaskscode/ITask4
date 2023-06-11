using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Task4.Service.ViewModels;

public class UserLoginViewModel
{
    [EmailAddress]
    public string Email { get; set; }
    [PasswordPropertyText]
    public string Password { get; set; }
}
