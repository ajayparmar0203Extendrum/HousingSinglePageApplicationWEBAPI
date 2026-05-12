namespace HousingSinglePageApplicationWEBAPI.Data.Repo
{
    public class FurnishingTypeRepository
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
