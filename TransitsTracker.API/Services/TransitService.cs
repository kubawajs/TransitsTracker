using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Models;
using TransitsTracker.API.Repositories;

namespace TransitsTracker.API.Services
{
    public class TransitService : ITransitService
    {
        private readonly ITransitRepository _repository;

        public TransitService(ITransitRepository repository)
        {
            _repository = repository;
        }

        public async Task AddAsync(Transit transit)
            => await _repository.AddAsync(transit);

        public async Task<IEnumerable<Transit>> GetAllAsync()
            => await _repository.GetAllAsync();

        public async Task<Transit> GetByIdAsync(int id)
            => await _repository.GetByIdAsync(id);
    }
}
