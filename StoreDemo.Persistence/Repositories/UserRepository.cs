using Microsoft.EntityFrameworkCore;
using StoreDemo.Domain.Entities;
using StoreDemo.Persistence.DbContexts;

namespace StoreDemo.Persistence.Repositories;

public class UserRepository
{
    private readonly StoreDemoDbContext _dbContext;

    public UserRepository(StoreDemoDbContext context)
    {
        _dbContext = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
       
        return user;
    }

    public async Task<User> CreateUser(User user)
    {
        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();
        return user;
    }

    public async Task UpdateUser(int id, User user)
    {
        if (id != user.UserId) throw new Exception("Mismatch user id on update.");

        _dbContext.Entry(user).State = EntityState.Modified;

        try
        {
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_dbContext.Users.Any(u => u.UserId == id)) throw new Exception("User update concurrency error");
            throw;
        }
    }

    public async Task DeleteUser(int id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        if (user == null) throw new Exception($"Failed to load user by id: {id}");

        _dbContext.Users.Remove(user);
        await _dbContext.SaveChangesAsync();
    }
}
