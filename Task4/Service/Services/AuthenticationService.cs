using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Task4.Data.IRepositories;
using Task4.Domain.Entities;
using Task4.Domain.Enums;
using Task4.Service.IServices;
using Task4.Service.ViewModels;

namespace Task4.Service.Services;


public class AuthenticationService : IAuthenticationService
{
    private readonly IConfiguration configuration;
    private readonly IUserRepository userRepository;

    public AuthenticationService(IUserRepository userRepository, IConfiguration configuration)
    {
        this.configuration = configuration;
        this.userRepository = userRepository;
    }

    public async Task<string> AuthenticateAsync(UserLoginViewModel model)
    {
        var user = await userRepository
            .SelectAsync(u => u.Email == model.Email && u.Password == model.Password);

        if (user is null)
            return null;

        if (user.Status == Status.Blocked)
            return "b";

        user.LastLoginTime = DateTime.UtcNow;
        await userRepository.SaveAsync();

        return GenerateToken(user);
    }

    private string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                 new Claim("Id", user.Id.ToString()),
                 new Claim("Password", user.Password)
            }),
            Audience = configuration["JWT:Audience"],
            Issuer = configuration["JWT:Issuer"],
            IssuedAt = DateTime.UtcNow,
            Expires = DateTime.UtcNow.AddMinutes(double.Parse(configuration["JWT:Expire"])),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}