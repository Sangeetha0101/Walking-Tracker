using IndiaWalks.Models.Domain;

namespace IndiaWalks.Repositories
{
    public interface IRegionRepository
    {
       Task< List<Region>> GetAllAsync();

        Task<Region?> GetRegionByIdAsync(Guid Id);

      Task<Region>  CreateAsync( Region region );
      
        Task<Region?> UpdateAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);
    }
}
