using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.Core.Domain;

namespace TransitsTracker.API.Services
{
    public interface IMapService
    {
        Task<int> GetDistanceAsync(Address source, Address destination);
    }
}
