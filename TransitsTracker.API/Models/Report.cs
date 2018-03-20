using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransitsTracker.API.Models
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
    }
}
