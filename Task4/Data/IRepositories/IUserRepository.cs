using System.Linq.Expressions;
using Task4.Domain.Entities;

namespace Task4.Data.IRepositories;

public interface IUserRepository
{
    Task<User> InsertAsync(User user);
    Task<bool> RemoveAsync(Expression<Func<User, bool>> expression);
    Task<User> SelectAsync(Expression<Func<User, bool>> expression);
    IQueryable<User> SelectAll(Expression<Func<User, bool>> expression = null);
    bool Exists(Expression<Func<User, bool>> expression);
    Task SaveAsync();
}
