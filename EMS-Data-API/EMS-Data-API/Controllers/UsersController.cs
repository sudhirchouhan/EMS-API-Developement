using EMS_Data_API.Models.DTO;
using EMS_Data_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EMS_Data_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAuthenticationRepo authenticationRepo;
        public ResultResponseDTO response;
        public UsersController(IAuthenticationRepo _authenticationRepo)
        {
            authenticationRepo = _authenticationRepo;
            response = new ResultResponseDTO();
        }

        [HttpPost("registerUsers")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationRequestDto model)
        {
            var errorMessage=await authenticationRepo.RegisterAsync(model);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                response.IsSuccess = false;
                response.Message= errorMessage;
                return BadRequest(response);
            }
            return Ok(response);
        }
        [HttpPost("loign")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var loginResponse = await authenticationRepo.LoginAsync(model);
            if (loginResponse.User==null)
            {
                response.IsSuccess = false;
                response.Message = "UserName or Password is incorrect";
                return BadRequest(response);
            }
            response.Result = loginResponse;

            return Ok(response);
        }
        [HttpPost("AssignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDto registrationRequestDto)
        {
            var assignRoleSuccessful = await authenticationRepo.AssignRoleAsync(registrationRequestDto.UserName, registrationRequestDto.Role.ToUpper());
            if (!assignRoleSuccessful)
            {
                response.IsSuccess = false;
                response.Message = "Error Encountered";
                return BadRequest(response);
            }

            return Ok(response);
        }

    }
}
