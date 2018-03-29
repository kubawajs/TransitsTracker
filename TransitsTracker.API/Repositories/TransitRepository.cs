using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Database;
using TransitsTracker.Core.Domain;
using TransitsTracker.Core.Repositories;

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

        public async Task<IEnumerable<Transit>> GetAllAsync()
            => await Task.FromResult(_context.Transits.Include(t => t.SourceAddress)
                                                      .Include(t => t.DestinationAddress).ToList());

        public async Task<Transit> GetByIdAsync(int id)
            => await Task.FromResult(await _context.Transits
                                                   .Include(t => t.SourceAddress)
                                                   .Include(t => t.DestinationAddress)
                                                   .FirstOrDefaultAsync(t => t.Id == id));
    }
}
