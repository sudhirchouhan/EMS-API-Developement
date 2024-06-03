using EMS_Data_API.Models.DTO;
using EMS_Data_API.ViewModels;

namespace EMS_Data_API.Repository
{
    public interface IBoothMasterRepo
    {
        Task<string> AddBoothAsync(BoothMasterDto boothMasterDto);
        Task<string> UpdateBoothAsync(int pollId, int vsId, int year, BoothMasterDto boothMasterDto);
        Task<string> DeleteBoothAsync(int pollId, int vsId, int Year);
        Task<BoothMasterDto> SelectBoothByIdAsync(int pollId, int vsId, int Year);
        Task<IEnumerable<BoothViewModel>> SelectBoothListAsync();
    }
}
