using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TransitsTracker.Core.Domain
{
    public abstract class Report
    {
        protected int CalculateTotalDistance(List<Transit> transits)
            => transits.Sum(o => o.Distance);

        protected decimal CalculateTotalPrice(List<Transit> transits)
            => transits.Sum(o => o.Price);
    }
}
