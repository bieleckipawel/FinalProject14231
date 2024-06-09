using Microsoft.AspNetCore.Mvc;
using FinalProject14231.Application.Services;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Services;
using FinalProject14231.Application.Common.Security;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class BikeController : ControllerBase
    {
        private readonly IBikeService _bikeService;

        public BikeController(IBikeService bikeService)
        {
            _bikeService = bikeService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBikeById(int id)
        {
            var bike = await _bikeService.GetBikeByIdAsync(id);
            return Ok(bike);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBikes()
        {
            var bikes = await _bikeService.GetAllBikesAsync();
            return Ok(bikes);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBike([FromBody] Bike bike)
        {
            await _bikeService.CreateBikeAsync(bike);
            return CreatedAtAction(nameof(GetBikeById), new { id = bike.Id }, bike);
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateBike(int id, [FromBody] Bike bike)
        {
            await _bikeService.UpdateBikeAsync(id, bike);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize] 
        public async Task<IActionResult> DeleteBike(int id)
        {
            await _bikeService.DeleteBikeAsync(id);
            return NoContent();
        }
    }
}
