using AutoMapper;
using ClinicBookingSystem.DTOs.Clinic;
using ClinicBookingSystem.Models;
using ClinicBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClinicsController : ControllerBase
	{
		private readonly IClinicService _clinicService;
		private readonly IMapper _mapper;

		public ClinicsController(IClinicService clinicService, IMapper mapper)
		{
			_clinicService = clinicService;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var clinics = await _clinicService.GetAllAsync();
			var result = _mapper.Map<List<ClinicDto>>(clinics);
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var clinic = await _clinicService.GetByIdAsync(id);
			if (clinic == null)
				return NotFound();

			var dto = _mapper.Map<ClinicDto>(clinic);
			return Ok(dto);
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] CreateClinicDto dto)
		{
			var clinic = _mapper.Map<Clinic>(dto);
			await _clinicService.AddAsync(clinic);
			return Ok(new { message = "Clinic created", clinic.Id });
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, [FromBody] UpdateClinicDto dto)
		{
			if (id != dto.Id)
				return BadRequest("ID mismatch");

			var existingClinic = await _clinicService.GetByIdAsync(id);
			if (existingClinic == null)
				return NotFound("Clinic not found");

			_mapper.Map(dto, existingClinic); // map fields into existing clinic object
			await _clinicService.UpdateAsync(existingClinic);

			return Ok(new { message = "Clinic updated" });
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _clinicService.DeleteAsync(id);
			return NoContent();
		}
	}
}