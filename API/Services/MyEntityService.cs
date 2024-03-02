using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class MyEntityService : IMyEntityService
{
    private readonly ILoggerService _logger;
    private readonly IMyEntityDAL _myEntityDAL;
    private readonly IMapper _mapper;

    public MyEntityService(
        ILoggerService logger,
        IMyEntityDAL myEntityDAL,
        IMapper mapper
        )
    {
        _logger = logger;
        _myEntityDAL = myEntityDAL;
        _mapper = mapper;
    }

    public async Task<int> Create(MyEntityForCreationDTO myEntityDTO)
    {
        MyEntity myEntity = _mapper.Map<MyEntity>(myEntityDTO);
        myEntity.CreatedAt = DateTime.Now;
        myEntity.UpdatedAt = DateTime.Now;
        return await _myEntityDAL.Create(myEntity);
    }

    public async Task Update(int idMyEntity, MyEntityForUpdateDTO myEntityDTO)
    {
        MyEntity myEntity = await GetRecordAndCheckExistence(idMyEntity);
        _mapper.Map(myEntityDTO, myEntity);
        myEntity.UpdatedAt = DateTime.Now;
        await _myEntityDAL.Update(myEntity);
    }

    public async Task Delete(int idMyEntity)
    {
        MyEntity myEntity = await GetRecordAndCheckExistence(idMyEntity);
        await _myEntityDAL.Delete(myEntity);
    }

    public async Task<MyEntityDTO?> Retrieve(int idMyEntity) => _mapper.Map<MyEntityDTO>(await _myEntityDAL.Retrieve(idMyEntity));

    public async Task<List<MyEntityDTO>> RetrieveAll() => _mapper.Map<List<MyEntityDTO>>(await _myEntityDAL.RetrieveAll());

    private async Task<MyEntity> GetRecordAndCheckExistence(int idMyEntity)
    {
        MyEntity myEntity = await _myEntityDAL.Retrieve(idMyEntity);
        if (myEntity is null)
            throw new EntityNotFoundException();
        return myEntity;
    }
}