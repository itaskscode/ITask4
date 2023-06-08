using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task4.Data.Interfaces;
using Task4.Domain.Enums;

namespace Task4.Web.Helpers;

public class AuthorizationService : IAuthorizationService
{
    private readonly IConfiguration configuration;
    private readonly IUserRepository userRepository;
    private readonly IHttpContextAccessor httpContextAccessor;

    public AuthorizationService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IConfiguration configuration)
    {
        this.configuration = configuration;
        this.userRepository = userRepository;
        this.httpContextAccessor = httpContextAccessor;
    }

    public async Task<bool> AuthorizeAsync()
    {
        string jwtToken = httpContextAccessor.HttpContext.Request.Cookies["token"];
        string secretKey = configuration["JWT:Key"];

        var jwtHandler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false, // Set to true if you want to validate the issuer
            ValidateAudience = false, // Set to true if you want to validate the audience
            ValidateLifetime = true, // Set to true if you want to validate the token's expiration
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
        };

        if (jwtToken is null)
            return false;

        ClaimsPrincipal claimsPrincipal = jwtHandler.ValidateToken(jwtToken, validationParameters, out var validatedToken);

        var claims = claimsPrincipal.Claims;

        var userId = long.Parse(claims.FirstOrDefault(c => c.Type == "Id")?.Value);
        var userPassword = claims.FirstOrDefault(c => c.Type == "Password")?.Value;

        var result = this.userRepository.Exists(u => u.Id == userId && u.Password == userPassword && u.Status == Status.Active);

        return result;
    }
}