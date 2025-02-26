using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class StatusTypeService(StatusTypeRepository statusTypeRepository)
{
    private readonly StatusTypeRepository _statusTypeRepository = statusTypeRepository;

    public async Task CreateStatusTypeAsync(StatusTypeForm form)
    {
        var statusTypeEntity = StatusTypeFactory.Create(form);
        await _statusTypeRepository.CreateAsync(statusTypeEntity!);
    }

    public async Task<IEnumerable<StatusType?>> GetProductAsync()
    {
        var statusTypeEntities = await _statusTypeRepository.GetAllAsync();
        return statusTypeEntities.Select(StatusTypeFactory.Create);

    }

    public async Task<StatusType?> GetStatusTypeByIdAsync(int id)
    {
        var statusTypeEntity = await _statusTypeRepository.GetByIdAsync(id);
        return StatusTypeFactory.Create(statusTypeEntity!);
    }


    public async Task<bool> UpdateStatusTypeAsync(StatusTypeForm form)
    {
        var statusTypeEntity = StatusTypeFactory.Create(form);
        return await _statusTypeRepository.UpdateAsync(statusTypeEntity!);
    }

    public async Task<bool> DeleteProductAsync(int id)
    {
        return await _statusTypeRepository.DeleteAsync(id);
    }
}
