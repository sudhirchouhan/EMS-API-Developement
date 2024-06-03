using AutoMapper;
using EMS_Data_API.Models.DomainModels;
using EMS_Data_API.Models.DTO;

namespace EMS_Data_API.ProjectUtility
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<BoothMaster, BoothMasterDto>().ReverseMap();
            CreateMap<VidhansabhaMaster, VidhansabhaMasterDto>().ReverseMap();
        }
    }
}
