using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Contexts;
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
            _context.Transits.Add(transit);
            await Task.CompletedTask;
        }
    }
}
