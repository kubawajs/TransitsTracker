using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.Core.Domain;

namespace TransitsTracker.API.Database
{
    public class TransitsTrackerContext : DbContext
    {
        public TransitsTrackerContext(DbContextOptions<TransitsTrackerContext> options)
            : base(options)
        {
        }

        public DbSet<Transit> Transits { get; set; }
    }
}
