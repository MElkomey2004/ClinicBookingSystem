using ClinicBookingSystem.DTOs.Auth;
using ClinicBookingSystem.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClinicBookingSystem.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly ITokenRepository _tokenRepository;

		public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
		{
			_userManager = userManager;
			_tokenRepository = tokenRepository;
		}

		[HttpPost("Register")]
		public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
		{
			if (registerRequestDTO == null || string.IsNullOrWhiteSpace(registerRequestDTO.UserName) || string.IsNullOrWhiteSpace(registerRequestDTO.Password))
			{
				return BadRequest("Invalid registration data.");
			}

			var existingUser = await _userManager.FindByEmailAsync(registerRequestDTO.UserName);
			if (existingUser != null)
			{
				return BadRequest("User already exists.");
			}

			var identityUser = new IdentityUser
			{
				UserName = registerRequestDTO.UserName,
				Email = registerRequestDTO.UserName
			};

			var result = await _userManager.CreateAsync(identityUser, registerRequestDTO.Password);
			if (!result.Succeeded)
			{
				return BadRequest(result.Errors);
			}

			// Assign roles — default to "Patient" if none provided
			var rolesToAssign = registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any()
				? registerRequestDTO.Roles
				: new List<string> { "Patient" };

			var roleResult = await _userManager.AddToRolesAsync(identityUser, rolesToAssign);
			if (!roleResult.Succeeded)
			{
				return BadRequest("User created, but failed to assign roles.");
			}

			return Ok("User was registered. Please login.");
		}

		[HttpPost("Login")]
		public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginRequestDTO)
		{
			if (loginRequestDTO == null || string.IsNullOrWhiteSpace(loginRequestDTO.Username) || string.IsNullOrWhiteSpace(loginRequestDTO.Password))
			{
				return BadRequest("Invalid login data.");
			}

			var user = await _userManager.FindByEmailAsync(loginRequestDTO.Username);
			if (user == null)
			{
				return BadRequest("Username or password incorrect.");
			}

			var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
			if (!isPasswordValid)
			{
				return BadRequest("Username or password incorrect.");
			}

			var roles = await _userManager.GetRolesAsync(user);
			var jwtToken = _tokenRepository.CreateJWTToken(user, roles.ToList());

			var response = new LoginResponseDTO
			{
				JwtToken = jwtToken
			};

			return Ok(response);
		}
	}
}
