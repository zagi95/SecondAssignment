using WebAPI.Dtos;
using WebAPI.Mapper;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserRecordDto>?> GetUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(UserMapper.ToUserRecordDto).ToList();

    }

    public async Task<UserRecordDto?> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        return UserMapper.ToUserRecordDto(user);
    } 

    public async Task<UserRecordDto> AddUserAsync(UserRegistrationDto userRegistrationDto)
    {
         var createdUser = await _userRepository.AddUserAsync(
             UserMapper.FromUserRegistrationDto(userRegistrationDto));
         return UserMapper.ToUserRecordDto(createdUser);
    }

    public async Task<UserRecordDto?> UpdateUserAsync(long id, UserRegistrationDto userRegistrationDto)
    {
        Console.WriteLine(UserMapper.FromUserRegistrationDto(id, userRegistrationDto).Id);
        var updatedUser = await _userRepository.UpdateUserAsync(
            UserMapper.FromUserRegistrationDto(id, userRegistrationDto));
        return updatedUser == null ? null : UserMapper.ToUserRecordDto(updatedUser);
    }

    public async Task<bool> DeleteUserAsync(int id) => await _userRepository.DeleteUserAsync(id);
}