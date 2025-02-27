using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class ProjectService(ProjectRepository projectRepository)
{
    private readonly ProjectRepository _projectRepository = projectRepository;

    public async Task CreateProjectAsync(ProjectRegistrationForm form)
    {
        var projectEntity = ProjectFactory.Create(form);
        await _projectRepository.CreateAsync(projectEntity!);
    }

    public async Task<IEnumerable<Project?>> GetProjectsAsync()
    {
        var customerEntities = await _projectRepository.GetAllAsync();
        return customerEntities.Select(ProjectFactory.Create);

    }

    public async Task<Project?> GetProjectByIdAsync(int id)
    {
        var projectEntity = await _projectRepository.GetByIdAsync(id);
        return ProjectFactory.Create(projectEntity!);
    }

    public async Task<Project?> GetProjectByProjectNameAsync(string projectName)
    {
        var projectEntity = await _projectRepository.GetProjectByProjectNameAsync(projectName);
        return ProjectFactory.Create(projectEntity!);
    }

    public async Task<bool> UpdateProjectAsync(ProjectRegistrationForm form)
    {
        var projectEntity = ProjectFactory.Create(form);
        return await _projectRepository.UpdateAsync(projectEntity!);
    }

    public async Task<bool> DeleteProjectAsync(int id)
    {
        return await _projectRepository.DeleteAsync(id);
    }


}

   
