namespace Task4.Web.Helpers;

public interface IAuthorizationService
{
    Task<bool> AuthorizeAsync();
}