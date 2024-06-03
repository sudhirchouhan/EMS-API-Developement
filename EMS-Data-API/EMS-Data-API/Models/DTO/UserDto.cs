namespace EMS_Data_API.Models.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Party { get; set; } = string.Empty;
        public int? Year { get; set; }
        public int VidhansabhaId { get; set; }
    }
}
