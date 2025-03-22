using WebAPI.Dtos;
using WebAPI.Mapper;
using WebAPI.Repositories;

namespace WebAPI.Services;

public class LoginService
{
    private readonly ILoginRecordRepository _repository;

    public LoginService(ILoginRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<LoginRecordDto>> GetAllAsync()
    {
        var records = await _repository.GetAllAsync();
        return records.Select(LoginRecordMapper.ToDto).ToList();
    }
}