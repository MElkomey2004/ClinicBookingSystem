using ClinicBookingSystem.DTOs.Users;
using ClinicBookingSystem.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem.Controllers
{
	[Authorize(Policy = "RequireAdminOrDoctorRole")] 
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserService _service;

		public UsersController(IUserService service)
		{
			_service = service;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var users = await _service.GetAllPatientsAsync();
			return Ok(users);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var user = await _service.GetByIdAsync(id);
			return user == null ? NotFound() : Ok(user);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CreateUserDto dto)
		{
			var created = await _service.AddAsync(dto);
			return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
		}

		[HttpPut]
		public async Task<IActionResult> Update(UpdateUserDto dto)
		{
			var result = await _service.UpdateAsync(dto);
			return result ? NoContent() : NotFound();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _service.DeleteAsync(id);
			return result ? NoContent() : NotFound();
		}
	}
}