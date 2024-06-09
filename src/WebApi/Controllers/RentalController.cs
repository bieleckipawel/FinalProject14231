using Microsoft.AspNetCore.Mvc;
using FinalProject14231.Application.BikeRentals;
using FinalProject14231.Domain.Entities;
using FinalProject14231.Domain.Services;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalById(int id)
        {
            var rental = await _rentalService.GetRentalByIdAsync(id);
            return Ok(rental);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentals()
        {
            var rentals = await _rentalService.GetAllRentalsAsync();
            return Ok(rentals);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental([FromBody] Rental rental)
        {
            await _rentalService.CreateRentalAsync(rental);
            return CreatedAtAction(nameof(GetRentalById), new { id = rental.Id }, rental);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRental(int id, [FromBody] Rental rental)
        {
            await _rentalService.UpdateRentalAsync(id, rental);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            await _rentalService.DeleteRentalAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/return")]
        public async Task<IActionResult> ReturnBike(int id)
        {
            await _rentalService.ReturnBikeAsync(id);
            return NoContent();
        }
    }
}
