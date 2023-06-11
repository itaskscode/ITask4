using Task4.Service.ViewModels;

namespace Task4.Service.IServices;

public interface IAuthenticationService
{
    Task<string> AuthenticateAsync(UserLoginViewModel model);
}