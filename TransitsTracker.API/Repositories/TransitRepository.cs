using System.Threading.Tasks;
using TransitsTracker.API.Database;
using TransitsTracker.API.Models;

namespace TransitsTracker.API.Repositories
{
    public class TransitRepository : ITransitRepository
    {
        private readonly TransitsTrackerContext _context;

        public TransitRepository(TransitsTrackerContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transit transit)
        {
            await _context.Transits.AddAsync(transit);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
