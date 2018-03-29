using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.Core.Domain;

namespace TransitsTracker.API.Services
{
    public interface ITransitService
    {
        Task AddAsync(Transit transit);
        Task<IEnumerable<Transit>> GetAllAsync();
        Task<Transit> GetByIdAsync(int id);
    }
}
