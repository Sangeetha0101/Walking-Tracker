using IndiaWalks.Models.Domain;

namespace IndiaWalks.Repositories
{
    public interface IwalkRepository
    {
        Task<Walk>CreateAsync(Walk walk);
        Task<List<Walk>>GetAllAsync(int PageNumber=1,int pageSize=100);
        Task<Walk?>GetByIdAsync(Guid id);
        Task<Walk?>UpdateByIdAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);
    }
}
