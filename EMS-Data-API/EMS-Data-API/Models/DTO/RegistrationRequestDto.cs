using System.ComponentModel.DataAnnotations;

namespace EMS_Data_API.Models.DTO
{
    public class RegistrationRequestDto
    {
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        public string UserName { get; set; } = string.Empty;
        [Required]

        public string Password { get; set; } = string.Empty;
        public string? MobileNumber { get; set; } = string.Empty;
        public string? FullAddress { get; set; } = string.Empty;
        [Required]
        public string Party { get; set; } = string.Empty;
        [Required]
        public int Year { get; set; }
        [Required]
        public int VidhansabhaId { get; set; }
        public string Role { get; set; }
    }
}
