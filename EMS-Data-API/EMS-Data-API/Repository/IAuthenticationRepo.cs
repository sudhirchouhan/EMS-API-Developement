using EMS_Data_API.Models.DTO;

namespace EMS_Data_API.Repository
{
    public interface IAuthenticationRepo
    {
        Task<string> RegisterAsync(RegistrationRequestDto requestDto);
        Task<LoginResposeDto> LoginAsync(LoginRequestDto requestDto);
        Task<bool> AssignRoleAsync(string userName, string roleName);
    }
}
