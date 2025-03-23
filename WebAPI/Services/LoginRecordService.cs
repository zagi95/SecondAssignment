using WebAPI.Dtos;
using WebAPI.Mapper;
using WebAPI.Repositories;

namespace WebAPI.Services;

public class LoginRecordService
{
    private readonly ILoginRecordRepository _repository;

    public LoginRecordService(ILoginRecordRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<LoginRecordDto>?> GetAllAsync()
    {
        var records = await _repository.GetAllAsync();
        return records.Select(LoginRecordMapper.ToDto).ToList();
    }
}