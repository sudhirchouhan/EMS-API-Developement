using System.ComponentModel.DataAnnotations;

namespace EMS_Data_API.Models.DTO
{
    public class BoothMasterDto
    {
      
        public int RecordID { get; set; }
      
        public int BoothNumber { get; set; }
       
        public int VidhansabhaID { get; set; }
     
        public string? BoothName { get; set; }
      
        public string? BoothPlace { get; set; }
      
        public int? MaleVoter { get; set; }
      
        public int? FemaleVoter { get; set; }
      
        public int? TotalVoter { get; set; }
        public string? PublicationDate { get; set; }
      
        public int Year { get; set; }
        public string? BoothNameEnglish { get; set; }
        public string? BoothPlaceEnglish { get; set; }
    }
}
