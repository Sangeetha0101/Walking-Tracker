using DocumentFormat.OpenXml.Wordprocessing;
using IndiaWalks.Data;
using IndiaWalks.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace IndiaWalks.Repositories
{
    public class SQLWalkRepository : IwalkRepository
    {
        private readonly IndiaWalksDBContext dbContext;

        public SQLWalkRepository(IndiaWalksDBContext dbContext)  
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.ID == id);
            if (existingWalk == null)
            {
                return null;
            }
            dbContext.Walks.Remove(existingWalk);
            await dbContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<List<Walk>> GetAllAsync(int PageNumber = 1, int pageSize = 100)
        {
            // Use lambda expressions for Include to avoid string-based navigation
            var skipResults = (PageNumber - 1) * pageSize;
            return await dbContext.Walks.Include(w => w.Difficulty).Include(w => w.Region).ToListAsync();

           
        }
           

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks.Include(w => w.Difficulty).Include(w => w.Region)
                .FirstOrDefaultAsync(x => x.ID == id);
        }

        public async Task<Walk?> UpdateByIdAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walks.FirstOrDefaultAsync(x => x.ID == id);
            if (existingWalk == null)
            {
                return null;
            }

            // Update properties
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKM = walk.LengthInKM;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;            
            existingWalk.RegionID = walk.RegionID;
            existingWalk.DifficultyID = walk.DifficultyID;

            await dbContext.SaveChangesAsync();
            return existingWalk;
        }
    }
}
