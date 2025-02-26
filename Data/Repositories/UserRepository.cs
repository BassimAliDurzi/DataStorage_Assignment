using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class UserRepository(DataContext context)
{
    private readonly DataContext _context = context;

    // Create
    public async Task<UserEntity> CreateAsync(UserEntity entity)
    {
        _context.Users.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    // Read
    public async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserEntity?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    // Update
    public async Task<bool> UpdateAsync(UserEntity entity)
    {
        var existingEntity = await _context.Users.FindAsync(entity.Id);
        if (existingEntity == null)
        {
            return false;
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    // Delete
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}