namespace EMS_Data_API.ViewModels
{
    public class BoothViewModel
    {
        public int? recordId { get; set; }
        public int BoothNumber { get; set; }

        public int VidhansabhaID { get; set; }
        public string? VidhansabhaName { get; set; }
        public string? VidhansabhaNameEnglish { get; set; }
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
