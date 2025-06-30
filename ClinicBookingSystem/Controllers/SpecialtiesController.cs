using AutoMapper;
using ClinicBookingSystem.DTOs.Specialty;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpecialtiesController : ControllerBase
	{
		private readonly ISpecialtyService _service;
		private readonly IMapper _mapper;

		public SpecialtiesController(ISpecialtyService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var specialties = await _service.GetAllAsync();
			var specialtyDtos = _mapper.Map<IEnumerable<SpecialtyDto>>(specialties);
			return Ok(specialtyDtos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var specialty = await _service.GetByIdAsync(id);
			if (specialty == null) return NotFound();

			var dto = _mapper.Map<SpecialtyDto>(specialty);
			return Ok(dto);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreateSpecialtyDto dto)
		{
			var specialty = _mapper.Map<Specialty>(dto);
			await _service.AddAsync(specialty);
			var resultDto = _mapper.Map<SpecialtyDto>(specialty);
			return CreatedAtAction(nameof(GetById), new { id = specialty.Id }, resultDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateSpecialtyDto dto)
		{
			if (id != dto.Id) return BadRequest("ID mismatch");

			var specialty = _mapper.Map<Specialty>(dto);
			await _service.UpdateAsync(specialty);
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
