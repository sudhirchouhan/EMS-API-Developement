using System.ComponentModel.DataAnnotations;

namespace EMS_Data_API.Models.DomainModels
{
    public class VidhansabhaMaster
    {
        [Key]
        public int VidhansabhaRecordId {  get; set; }
        [Required]
        public int VidhansabhaId { get;  set; }
        [Required]
        public string? VidhansabhaName { get; set; }=string.Empty;
        [Required]
        public int Year { get; set; }
        [Required]
        public string? ReservationCategory { get; set; } = string.Empty;
        public string? VidhansabhaNameEng { get; set; } = string.Empty;
    }
}
