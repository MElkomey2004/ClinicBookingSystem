using ClinicBookingSystem.DTOs.Appointment;
using ClinicBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AppointmentsController : ControllerBase
	{
		private readonly IAppointmentService _service;

		public AppointmentsController(IAppointmentService service)
		{
			_service = service;
		}

		[HttpGet]
		[Authorize(Roles = "Admin,Doctor")]
		public async Task<IActionResult> GetAll()
		{
			var appointments = await _service.GetAllAsync();
			return Ok(appointments);
		}

		[HttpGet("{id}")]
		[Authorize(Roles = "Admin,Doctor")]
		public async Task<IActionResult> GetById(int id)
		{
			var appointment = await _service.GetByIdAsync(id);
			return appointment == null ? NotFound() : Ok(appointment);
		}

		[HttpPost]
		[Authorize(Roles = "Patient")]
		public async Task<IActionResult> Create([FromBody] CreateAppointmentDto dto)
		{
			await _service.AddAsync(dto);
			return Ok(dto);
		}

		[HttpPut("{id}")]
		[Authorize(Roles = "Admin,Doctor")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateAppointmentDto dto)
		{
			if (id != dto.Id) return BadRequest();
			await _service.UpdateAsync(dto);
			return NoContent();
		}

		[HttpDelete("{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return NoContent();
		}
	}
}
