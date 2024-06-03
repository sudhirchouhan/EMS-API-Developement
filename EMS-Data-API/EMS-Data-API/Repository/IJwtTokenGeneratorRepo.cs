using EMS_Data_API.Models;

namespace EMS_Data_API.Repository
{
    public interface IJwtTokenGeneratorRepo
    {
        string GenerateToken(ApplicationUser user, IEnumerable<string> roles);
    }
}
