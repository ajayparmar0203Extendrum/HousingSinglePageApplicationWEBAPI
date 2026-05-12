namespace HousingSinglePageApplicationWEBAPI.Data.Repo
{
    public class PropertyTypeRepository
    {
        private readonly DataContext dc;

        public PropertyTypeRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public async Task<IEnumerable<PropertyType>> GetPropertyTypesAsync()
        {
            return await dc.PropertyTypes.ToListAsync();
        }
    }
}
