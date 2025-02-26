using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProductRepository(DataContext context)
{
    private readonly DataContext _context = context;

    // Create
    public async Task<ProductEntity> CreateAsync(ProductEntity entity)
    {
        _context.Products.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    // Read
    public async Task<IEnumerable<ProductEntity>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<ProductEntity?> GetByIdAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    // Update
    public async Task<bool> UpdateAsync(ProductEntity entity)
    {
        var existingEntity = await _context.Products.FindAsync(entity.Id);
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
        var entity = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _context.Products.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
}
