namespace Task4.Service.IServices;


public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync();
}