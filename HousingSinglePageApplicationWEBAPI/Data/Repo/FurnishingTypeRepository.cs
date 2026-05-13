using HousingSinglePageApplicationWEBAPI.Interfaces;
using HousingSinglePageApplicationWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HousingSinglePageApplicationWEBAPI.Data.Repo
{
    public class FurnishingTypeRepository : IFurnishingTypeRepository
    {
        private readonly DataContext dc;

        public FurnishingTypeRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<FurnishingType>> GetFurnishingTypesAsync()
        {
            return await dc.FurnishingTypes.ToListAsync();
        }
    }
}
