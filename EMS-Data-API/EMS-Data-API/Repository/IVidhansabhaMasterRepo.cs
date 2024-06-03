using EMS_Data_API.Models.DTO;

namespace EMS_Data_API.Repository
{
    public interface IVidhansabhaMasterRepo
    {
       Task<string> AddVidhansabhaAsync(VidhansabhaMasterDto vidhansabhaMasterDto);
        Task<string> UpdateVidhansabhaAsync(int vsId,VidhansabhaMasterDto vidhansabhaMasterDto);
        Task<string> DeleteVidhansabhaAsync(int vsId);
        Task<VidhansabhaMasterDto> SelectVidhansabhaByIdAsync(int vsId);
        Task<IEnumerable<VidhansabhaMasterDto>> SelectVidhansabhaListAsync();
    }
}
