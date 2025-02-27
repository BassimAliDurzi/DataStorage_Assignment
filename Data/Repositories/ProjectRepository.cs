using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context)
{
    private readonly DataContext _context = context;

    // Create
    public async Task<ProjectEntity> CreateAsync(ProjectEntity entity)
    {
        _context.Projects.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    // Read
    public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<ProjectEntity?> GetByIdAsync(int id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task<ProjectEntity?> GetProjectByProjectNameAsync(string projectTitle)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Title == projectTitle);
    }

    // Update
    public async Task<bool> UpdateAsync(ProjectEntity entity)
    {
        var existingEntity = await _context.Projects.FindAsync(entity.Id);
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
        var entity = await _context.Projects.FirstOrDefaultAsync(x => x.Id == id);
        if (entity != null)
        {
            _context.Projects.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

}
