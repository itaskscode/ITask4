using Task4.Service.ViewModels;

namespace Task4.Service.Interfaces;

public interface IAuthenticationService
{
    Task<string> AuthenticateAsync(UserLoginViewModel model);
}