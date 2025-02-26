using Business.Dtos;
using Business.Factories;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class UserService(UserRepository userRepository)
{
    private readonly UserRepository _userRepository = userRepository;

    public async Task CreateUserAsync(UserRegistrationForm form)
    {
        var userEntity = UserFactory.Create(form);
        await _userRepository.CreateAsync(userEntity!);
    }

    public async Task<IEnumerable<User?>> GetUserAsync()
    {
        var userEntities = await _userRepository.GetAllAsync();
        return userEntities.Select(UserFactory.Create);

    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        var userEntity = await _userRepository.GetByIdAsync(id);
        return UserFactory.Create(userEntity!);
    }


    public async Task<bool> UpdateUserAsync(UserRegistrationForm form)
    {
        var userEntity = UserFactory.Create(form);
        return await _userRepository.UpdateAsync(userEntity!);
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _userRepository.DeleteAsync(id);
    }



}
