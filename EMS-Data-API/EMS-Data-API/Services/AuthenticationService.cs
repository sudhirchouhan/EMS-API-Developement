using EMS_Data_API.DataContext;
using EMS_Data_API.Models;
using EMS_Data_API.Models.DTO;
using EMS_Data_API.Repository;
using Microsoft.AspNetCore.Identity;

namespace EMS_Data_API.Services
{
    public class AuthenticationService : IAuthenticationRepo
    {
        private readonly ApplicationDatabaseContext db;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IJwtTokenGeneratorRepo jwtTokenGenerator;
        public AuthenticationService(ApplicationDatabaseContext _db, 
            UserManager<ApplicationUser> _userManager,
            RoleManager<IdentityRole> _roleManager,
            IJwtTokenGeneratorRepo _jwtTokenGenerator)
        {
            db = _db;
            userManager = _userManager;
            roleManager = _roleManager;
            jwtTokenGenerator = _jwtTokenGenerator;
        }

        
        public async Task<bool> AssignRoleAsync(string userName, string roleName)
        {
            var user = db.tblUsers.FirstOrDefault(x => x.UserName.ToLower() == userName.ToLower());
            if(user != null)
            {
                if(!roleManager.RoleExistsAsync(roleName).GetAwaiter().GetResult())
                {
                    roleManager.CreateAsync(new IdentityRole(roleName)).GetAwaiter().GetResult();
                }
                await userManager.AddToRoleAsync(user,roleName);
                return true;
            }
            return false;
        }

        public async Task<LoginResposeDto> LoginAsync(LoginRequestDto requestDto)
        {

            var user = db.tblUsers.FirstOrDefault(x => x.UserName.ToLower() == requestDto.UserName.ToLower());
            bool isValid =await userManager.CheckPasswordAsync(user, requestDto.Password);
            if(user==null || isValid==false)
            {
                return new LoginResposeDto() { User = null, Token = "" };
            }
            var roles=await userManager.GetRolesAsync(user);
            var token=jwtTokenGenerator.GenerateToken(user, roles);
            UserDto userDto = new UserDto()
            {
                Id=user.Id,
                FullName=user.FullName,
                Party=user.Party,
                VidhansabhaId=user.VidhansabhaId,
                Year=user.Year
            };
            LoginResposeDto loginResponseDto = new LoginResposeDto()
            {
                User = userDto,
                Token= token
            };
            return loginResponseDto;
        }

        public async Task<string> RegisterAsync(RegistrationRequestDto requestDto)
        {
            if(requestDto!=null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    FullName = requestDto.FullName,
                    FullAddress = requestDto.FullAddress,
                    MobileNumber = requestDto.MobileNumber,
                    Party = requestDto.Party,
                    Year = requestDto.Year,
                    VidhansabhaId = requestDto.VidhansabhaId,
                    Email=requestDto.UserName,
                    NormalizedEmail= requestDto.UserName,
                    PhoneNumber=requestDto.MobileNumber,
                    UserName=requestDto.UserName
                };
                var result= await userManager.CreateAsync(user,requestDto.Password);
                if(result.Succeeded)
                {
                    var returnUserData = db.tblUsers.First(x => x.Email == requestDto.UserName);
                    
                    return "";
                }
                else
                {
                    return result.Errors.FirstOrDefault().Description;
                }
            }
            return "Request Data is Null";
           

        }
    }
}
