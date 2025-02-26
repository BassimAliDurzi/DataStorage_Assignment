using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class CustomerRepository(DataContext context)
{
    private readonly DataContext _context = context;


    // Create
    public async Task<CustomerEntity> CreateAsync(CustomerEntity entity)
    {
       _context.Customers.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    // Read
    public async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customers.ToListAsync();
    }

    public async Task<CustomerEntity?> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task<CustomerEntity?> GetByCustomerNameAsync(string customerName)
    {
        return await _context.Customers.FindAsync(customerName);
    }

    // Update
    public async Task<bool> UpdateAsync(CustomerEntity entity)
    {
        var existingEntity = await _context.Customers.FindAsync(entity.Id);
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
        var entity = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _context.Customers.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

}
