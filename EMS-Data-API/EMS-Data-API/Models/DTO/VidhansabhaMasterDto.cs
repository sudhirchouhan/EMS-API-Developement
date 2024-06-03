using System.ComponentModel.DataAnnotations;

namespace EMS_Data_API.Models.DTO
{
    public class VidhansabhaMasterDto
    {
      
        public int? VidhansabhaRecordId { get; set; }
       
        public int VidhansabhaId { get; set; }
      
        public string? VidhansabhaName { get; set; } = string.Empty;
      
        public int Year { get; set; }
       
        public string? ReservationCategory { get; set; } = string.Empty;
        public string? VidhansabhaNameEng { get; set; } = string.Empty;
    }
}
