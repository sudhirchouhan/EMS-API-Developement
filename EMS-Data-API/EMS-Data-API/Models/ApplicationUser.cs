using Microsoft.AspNetCore.Identity;

namespace EMS_Data_API.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }=string.Empty;
        public string MobileNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public string Party { get; set; } = string.Empty;
        public int? Year { get; set; }
        public int VidhansabhaId { get; set; }
    }
}
