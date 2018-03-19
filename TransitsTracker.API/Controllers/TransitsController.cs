using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransitsTracker.API.Contexts;
using TransitsTracker.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransitsTracker.API.Controllers
{
    [Route("api/[controller]")]
    public class TransitsController : Controller
    {
        private readonly TransitsTrackerContext _context;

        public TransitsController(TransitsTrackerContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Transit transit)
        {
            if(transit == null)
            {
                return BadRequest();
            }

            _context.Transits.Add(transit);
            _context.SaveChanges();

            return Json(transit);
        }
    }
}
