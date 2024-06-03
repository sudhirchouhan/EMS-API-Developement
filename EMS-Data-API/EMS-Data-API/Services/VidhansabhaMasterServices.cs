using AutoMapper;
using EMS_Data_API.DataContext;
using EMS_Data_API.Models.DomainModels;
using EMS_Data_API.Models.DTO;
using EMS_Data_API.Repository;
using Microsoft.EntityFrameworkCore;

namespace EMS_Data_API.Services
{
    public class VidhansabhaMasterServices : IVidhansabhaMasterRepo
    {
        private readonly ApplicationDatabaseContext db;
        private readonly IMapper mapper;
        public VidhansabhaMasterServices(ApplicationDatabaseContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public async Task<string> AddVidhansabhaAsync(VidhansabhaMasterDto vidhansabhaMasterDto)
        {
            VidhansabhaMaster vidhanSabhaMaster=mapper.Map<VidhansabhaMaster>(vidhansabhaMasterDto);
            await db.tblVidhansabhaMaster.AddAsync(vidhanSabhaMaster);
             await db.SaveChangesAsync();
            return "Record Saved Successfully..";

        }

        public async Task<string> DeleteVidhansabhaAsync(int vsId)
        {
            if (vsId.ToString() == null || vsId == 0)
            {
                return "Invalid data to Update";
            }
            var vidhansabhaData = await db.tblVidhansabhaMaster.FirstOrDefaultAsync(x => x.VidhansabhaId == vsId);

            if (vidhansabhaData == null)
            {
                return "Record Not Found";
            }
             db.tblVidhansabhaMaster.Remove(vidhansabhaData);
            await db.SaveChangesAsync();
            return "Record Deleted Successfully";
        }

        public async Task<VidhansabhaMasterDto> SelectVidhansabhaByIdAsync(int vsId)
        {
            
            var vidhansabhaData = await db.tblVidhansabhaMaster.FirstOrDefaultAsync(x => x.VidhansabhaId == vsId);
            var vidhansabhaMappedDto= mapper.Map<VidhansabhaMasterDto>(vidhansabhaData);
            return vidhansabhaMappedDto;
        }

        public async Task<IEnumerable<VidhansabhaMasterDto>> SelectVidhansabhaListAsync()
        {
            List<VidhansabhaMaster> vsList=await db.tblVidhansabhaMaster.ToListAsync();
            var vsListDto=mapper.Map<List<VidhansabhaMasterDto>>(vsList);
            return vsListDto;
        }

        public async Task<string> UpdateVidhansabhaAsync(int vsId, VidhansabhaMasterDto vidhansabhaMasterDto)
        {
            if(vsId.ToString()==null || vsId==0)
            {
                return  "Invalid data to Update";
            }
            var vidhansabhaData=db.tblVidhansabhaMaster.FirstOrDefault(x=>x.VidhansabhaId==vsId);
           
            if(vidhansabhaData==null)
            {
                return "Record Not Found";
            }
            vidhansabhaData.Year = vidhansabhaMasterDto.Year;
            vidhansabhaData.VidhansabhaId = vidhansabhaMasterDto.VidhansabhaId;
            vidhansabhaData.VidhansabhaName = vidhansabhaMasterDto.VidhansabhaName;
            vidhansabhaData.VidhansabhaNameEng = vidhansabhaMasterDto.VidhansabhaNameEng;
            vidhansabhaData.ReservationCategory = vidhansabhaMasterDto.ReservationCategory;
            db.tblVidhansabhaMaster.Update(vidhansabhaData);
            await db.SaveChangesAsync();
            return "Record Updated Successfully";
        }
    }
}
