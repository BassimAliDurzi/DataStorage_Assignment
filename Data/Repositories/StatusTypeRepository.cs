using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class StatusTypeRepository(DataContext context)
{
    private readonly DataContext _context = context;

    // Create
    public async Task<StatusTypeEntity> CreateAsync(StatusTypeEntity entity)
    {
        _context.StatusTypes.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    // Read
    public async Task<IEnumerable<StatusTypeEntity>> GetAllAsync()
    {
        return await _context.StatusTypes.ToListAsync();
    }

    public async Task<StatusTypeEntity?> GetByIdAsync(int id)
    {
        return await _context.StatusTypes.FindAsync(id);
    }

    // Update
    public async Task<bool> UpdateAsync(StatusTypeEntity entity)
    {
        var existingEntity = await _context.StatusTypes.FindAsync(entity.Id);
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
        var entity = await _context.StatusTypes.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _context.StatusTypes.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
