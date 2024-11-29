using IndiaWalks.Data;
using IndiaWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IndiaWalks.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly IndiaWalksDBContext dBContext;

        public SQLRegionRepository(IndiaWalksDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<Region> CreateAsync(Region regions)
        {
            await dBContext.Regions.AddAsync(regions);
            await dBContext.SaveChangesAsync();
            return regions;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingRegion = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            dBContext.Regions.Remove(existingRegion);
            await dBContext.SaveChangesAsync();
            return existingRegion;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dBContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetRegionByIdAsync(Guid Id)
        {
            return await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dBContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            {
                if (existingRegion == null)
                {
                    return null;
                }
                existingRegion.Code = region.Code;
                existingRegion.Name = region.Name;
                existingRegion.RegionImageUrl = region.RegionImageUrl;

                await dBContext.SaveChangesAsync();
                return region;
            }
        }
    }
}
