using Task4.Domain.Entities;
using Task4.Domain.Enums;
using Task4.Service.DTOs;

namespace Task4.Service.Interfaces;

public interface IUserService
{
    Task<UserResultDto> AddAsync(UserCreationDto dto);
    Task<UserResultDto> BlockAsync(long id);
    Task<UserResultDto> UnblockAsync(long id);
    Task<bool> DeleteAsync(long id);
    Task<IEnumerable<UserResultDto>> GetAllAsync();
}