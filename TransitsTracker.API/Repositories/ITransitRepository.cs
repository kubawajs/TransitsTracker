using System.Threading.Tasks;
using TransitsTracker.API.Models;

namespace TransitsTracker.API.Repositories
{
    public interface ITransitRepository : IRepository
    {
        Task AddAsync(Transit transit);
    }
}
