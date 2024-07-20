using Microsoft.Extensions.Caching.Memory;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class ProfileService : IProfileService
{
    private readonly IProfileDAL _profileDAL;
    private readonly IMemoryCache _cache;

    public ProfileService(
        IProfileDAL profileDAL,
        IMemoryCache cache
    )
    {
        _profileDAL = profileDAL;
        _cache = cache;
    }

    public async Task<Profile?> Retrieve(Guid id, bool trackChanges = false)
    {
        List<Profile> profilesList = (await _cache.GetOrCreateAsync("Profiles", async entry =>
        {
            entry.SlidingExpiration = TimeSpan.FromMinutes(30);
            return await _profileDAL.RetrieveAll(trackChanges: false);
        })).ToList();
        return profilesList.Find(p => p.Id == id);
    }
}
