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
        private readonly IMapService _mapService;

        public TransitsController(ITransitService transitService, IMapService mapService)
        {
            _transitService = transitService;
            _mapService = mapService;
        }

        // TODO: get and get by id

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Transit transit)
        {
            if (transit == null)
            {
                return BadRequest();
            }
            await SetTransitDistance(transit);
            await _transitService.AddAsync(transit);

            return Json(transit);
        }

        private async Task SetTransitDistance(Transit transit)
        {
            var distance = await _mapService.GetDistanceAsync(transit.SourceAddress, transit.DestinationAddress);
            transit.SetDistance(distance);
        }
    }
}
