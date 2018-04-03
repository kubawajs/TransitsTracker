using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TransitsTracker.API.Services;
using TransitsTracker.Core.Domain;

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


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var transits = await _transitService.GetAllAsync();
            if(transits == null)
            {
                return NotFound();
            }
            return new JsonResult(transits) { StatusCode = 200 };
        }

        [HttpGet]
        [Route("{transitId}")]
        public async Task<IActionResult> Get(int transitId)
        {
            var transit = await _transitService.GetByIdAsync(transitId);
            if(transit == null)
            {
                return NotFound();
            }
            return new JsonResult(transit) { StatusCode = 200 };
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Transit transit)
        {
            if (transit == null)
            {
                return BadRequest();
            }
            await SetTransitDistance(transit);
            await _transitService.AddAsync(transit);

            return NoContent();
        }

        private async Task SetTransitDistance(Transit transit)
        {
            // TODO: test and try catch
            var distance = await _mapService.GetDistanceAsync(transit.SourceAddress, transit.DestinationAddress);
            transit.SetDistance(distance);
        }
    }
}
