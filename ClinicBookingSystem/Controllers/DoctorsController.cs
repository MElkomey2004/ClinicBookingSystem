using AutoMapper;
using ClinicBookingSystem.DTOs.Doctor;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DoctorsController : ControllerBase
	{
		private readonly IDoctorService _service;
		private readonly IMapper _mapper;

		public DoctorsController(IDoctorService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var doctors = await _service.GetAllAsync();
			var result = _mapper.Map<IEnumerable<DoctorDto>>(doctors);
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var doctor = await _service.GetByIdAsync(id);
			if (doctor == null) return NotFound();
			var result = _mapper.Map<DoctorDto>(doctor);
			return Ok(result);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateDoctorDto dto)
		{
			var doctor = _mapper.Map<Doctor>(dto);
			await _service.AddAsync(doctor);
			var result = _mapper.Map<DoctorDto>(doctor);
			return CreatedAtAction(nameof(GetById), new { id = doctor.Id }, result);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateDoctorDto dto)
		{
			if (id != dto.Id) return BadRequest("ID mismatch");
			var doctor = _mapper.Map<Doctor>(dto);
			await _service.UpdateAsync(doctor);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _service.DeleteAsync(id);
			return NoContent();
		}
	}
}
