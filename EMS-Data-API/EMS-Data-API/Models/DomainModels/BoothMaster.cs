using System.ComponentModel.DataAnnotations;

namespace EMS_Data_API.Models.DomainModels
{
    public class BoothMaster
    {
        [Key]
        public int RecordID { get; set; }
        [Required]
        public int BoothNumber { get; set; }
        [Required]
        public int VidhansabhaID { get; set; }
        [Required]
        public string? BoothName { get; set; }
        [Required]
        public string? BoothPlace { get; set; }
        [Required]
        public int? MaleVoter { get; set; }
        [Required]
        public int? FemaleVoter { get; set; }
        [Required]
        public int? TotalVoter { get; set; }
        public string? PublicationDate { get; set; }
        [Required]
        public int Year { get; set; }
        public string? BoothNameEnglish { get; set; }
        public string? BoothPlaceEnglish { get; set; }

    }
}