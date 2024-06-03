namespace EMS_Data_API.Models.DTO
{
    public class ResultResponseDTO
    {
        public object Result { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message {  get; set; }=string.Empty;
    }
}
