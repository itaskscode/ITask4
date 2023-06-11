using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Task4.Data.DbContexts;
using Task4.Data.IRepositories;
using Task4.Domain.Entities;

namespace Task4.Data.Repositories;

public class UserRepository : IUserRepository
{
    private AppDbContext dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> RemoveAsync(Expression<Func<User, bool>> expression)
    {
        var user = await this.dbContext.Users.FirstOrDefaultAsync(expression);
        if (user is null)
            return false;

        this.dbContext.Users.Remove(user);
        return true;
    }

    public async Task<User> InsertAsync(User user)
        => (await this.dbContext.Users.AddAsync(user)).Entity;

    public IQueryable<User> SelectAll(Expression<Func<User, bool>> expression = null)
        => expression is null ? this.dbContext.Users : this.dbContext.Users.Where(expression);

    public async Task<User> SelectAsync(Expression<Func<User, bool>> expression)
        => await this.dbContext.Users.FirstOrDefaultAsync(expression);

    public async Task SaveAsync()
        => await this.dbContext.SaveChangesAsync();

    public bool Exists(Expression<Func<User, bool>> expression)
        => this.dbContext.Users.Any(expression);
}