using HousingSinglePageApplicationWEBAPI.Models;

namespace HousingSinglePageApplicationWEBAPI.Interfaces
{
    public interface IPropertyTypeRepository
    {
        Task<IEnumerable<PropertyType>> GetPropertyTypesAsync();
    }
}
