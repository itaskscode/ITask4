using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Task4.Data.Interfaces;
using Task4.Domain.Entities;
using Task4.Domain.Enums;
using Task4.Service.DTOs;
using Task4.Service.Interfaces;

namespace Task4.Service.Services;

public class UserService : IUserService
{
    private readonly IMapper mapper;
    private readonly IUserRepository userRepository;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        this.mapper = mapper;
        this.userRepository = userRepository;
    }

    public async Task<UserResultDto> AddAsync(UserCreationDto dto)
    {
        var existingEntity = await this.userRepository.SelectAsync(u => u.Email == dto.Email);

        if (existingEntity is not null)
            return null;

        var user = mapper.Map<User>(dto);

        var createdUser = await this.userRepository.InsertAsync(user);

        var resultUser = mapper.Map<UserResultDto>(createdUser);

        await this.userRepository.SaveAsync();
        return resultUser;
    }

    public async Task<UserResultDto> BlockAsync(long id)
    {
        var user = await this.userRepository.SelectAsync(u => u.Id == id);

        if (user is null)
            return null;

        user.Status = Status.Blocked;
        user.UpdatedAt = DateTime.UtcNow;

        var resultUser = mapper.Map<UserResultDto>(user);

        await this.userRepository.SaveAsync();
        return resultUser;
    }

    public async Task<UserResultDto> UnblockAsync(long id)
    {
        var user = await this.userRepository.SelectAsync(u => u.Id == id);

        if (user is null)
            return null;

        user.Status = Status.Active;
        user.UpdatedAt = DateTime.UtcNow;

        var resultUser = mapper.Map<UserResultDto>(user);

        await this.userRepository.SaveAsync();
        return resultUser;
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var result = await this.userRepository.RemoveAsync(u => u.Id == id);

        await this.userRepository.SaveAsync();

        return result;
    }

    public async Task<IEnumerable<UserResultDto>> GetAllAsync()
    {
        var users = await this.userRepository.SelectAll().OrderBy(u => u.Id).ToListAsync();

        return mapper.Map<IEnumerable<UserResultDto>>(users);
    }
}