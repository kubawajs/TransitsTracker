using System.Collections.Generic;
using System.Threading.Tasks;
using TransitsTracker.Core.Domain;

namespace TransitsTracker.Core.Repositories
{
    public interface ITransitRepository : IRepository
    {
        Task AddAsync(Transit transit);
        Task<IEnumerable<Transit>> GetAllAsync();
        Task<Transit> GetByIdAsync(int id);
    }
}
