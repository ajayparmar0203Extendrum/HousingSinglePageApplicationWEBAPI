using HousingSinglePageApplicationWEBAPI.Models;

namespace HousingSinglePageApplicationWEBAPI.Interfaces
{
    public interface IFurnishingTypeRepository
    {
        Task<IEnumerable<FurnishingType>> GetFurnishingTypesAsync();
    }
}
