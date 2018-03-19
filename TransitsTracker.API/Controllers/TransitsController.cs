using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TransitsTracker.API.Models;
using TransitsTracker.API.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TransitsTracker.API.Controllers
{
    [Route("api/[controller]")]
    public class TransitsController : Controller
    {
        private readonly ITransitService _transitService;

        public TransitsController(ITransitService transitService)
        {
            _transitService = transitService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Transit transit)
        {
            if(transit == null)
            {
                return BadRequest();
            }
            await _transitService.AddAsync(transit);
            return Json(transit);
        }
    }
}
