using ClinicBookingSystem.DTOs.TimeSlot;
using ClinicBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TimeSlotsController : ControllerBase
	{
		private readonly ITimeSlotService _timeSlotService;

		public TimeSlotsController(ITimeSlotService timeSlotService)
		{
			_timeSlotService = timeSlotService;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<TimeSlotDto>>> GetAll()
		{
			var slots = await _timeSlotService.GetAllAsync();
			return Ok(slots);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<TimeSlotDto>> GetById(int id)
		{
			var slot = await _timeSlotService.GetByIdAsync(id);
			if (slot == null) return NotFound();
			return Ok(slot);
		}

		[HttpGet("doctor/{doctorId}")]
		public async Task<ActionResult<IEnumerable<TimeSlotDto>>> GetByDoctorId(int doctorId)
		{
			var slots = await _timeSlotService.GetByDoctorIdAsync(doctorId);
			return Ok(slots);
		}

		[HttpPost]
		public async Task<ActionResult<TimeSlotDto>> Create(CreateTimeSlotDto dto)
		{
			var createdSlot = await _timeSlotService.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = createdSlot.Id }, createdSlot);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateTimeSlotDto dto)
		{
			if (id != dto.Id)
			{
				return BadRequest("ID mismatch");
			}

			var updated = await _timeSlotService.UpdateAsync(dto);
			if (!updated) return NotFound();

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var deleted = await _timeSlotService.DeleteAsync(id);
			if (!deleted) return NotFound();

			return NoContent();
		}
	}
}
