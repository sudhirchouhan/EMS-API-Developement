using AutoMapper;
using EMS_Data_API.DataContext;
using EMS_Data_API.Models.DomainModels;
using EMS_Data_API.Models.DTO;
using EMS_Data_API.Repository;
using EMS_Data_API.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EMS_Data_API.Services
{
    public class BoothMasterServices : IBoothMasterRepo
    {
        private readonly ApplicationDatabaseContext db;
        private readonly IMapper mapper;
        public BoothMasterServices(ApplicationDatabaseContext _db, IMapper _mapper)
        {
            db = _db;
            mapper = _mapper;
        }
        public async Task<string> AddBoothAsync(BoothMasterDto boothMasterDto)
        {
            BoothMaster boothMaster = mapper.Map<BoothMaster>(boothMasterDto);
            await db.tblBoothMaster.AddAsync(boothMaster);
            await db.SaveChangesAsync();
            return "Record Saved Successfully..";
        }

        public async Task<string> DeleteBoothAsync(int pollId, int vsId, int Year)
        {
            if (vsId==0 ||Year==0 || pollId == 0)
            {
                return "Invalid data to Delete";
            }
            var boothData = await db.tblBoothMaster.FirstOrDefaultAsync(x => x.BoothNumber == pollId && x.VidhansabhaID == vsId && x.Year == Year);

            if (boothData == null)
            {
                return "Record Not Found";
            }
            db.tblBoothMaster.Remove(boothData);
            await db.SaveChangesAsync();
            return "Record Deleted Successfully";
        }

        public async Task<BoothMasterDto> SelectBoothByIdAsync(int pollId,int vsId,int Year)
        {
            var boothData = await db.tblBoothMaster.FirstOrDefaultAsync(x => x.BoothNumber == pollId && x.VidhansabhaID==vsId && x.Year==Year);
            var boothMappedDto = mapper.Map<BoothMasterDto>(boothData);
            return boothMappedDto;
        }

        public async Task<IEnumerable<BoothViewModel>> SelectBoothListAsync()
        {
            var boothListData =  from b in db.tblBoothMaster
                                join v in db.tblVidhansabhaMaster
                                on b.VidhansabhaID equals v.VidhansabhaId
                                select new BoothViewModel
                                {
                                    recordId=b.RecordID,
                                    VidhansabhaID= b.VidhansabhaID,
                                    VidhansabhaName=v.VidhansabhaName,
                                    VidhansabhaNameEnglish=v.VidhansabhaNameEng,
                                    BoothNumber=b.BoothNumber,
                                    BoothName=b.BoothName,
                                    BoothNameEnglish=b.BoothNameEnglish,
                                    BoothPlace=b.BoothPlaceEnglish,
                                    MaleVoter=b.MaleVoter,
                                    FemaleVoter=b.FemaleVoter,
                                    TotalVoter=b.TotalVoter,
                                    Year=b.Year,
                                    PublicationDate=b.PublicationDate

                                };
            List<BoothViewModel> boothList =await boothListData.ToListAsync();
            //List<BoothMaster> boothList = await db.tblBoothMaster.ToListAsync();
            //var boothListDto = mapper.Map<List<BoothMasterDto>>(boothList);
            return boothList;
        }

        public async Task<string> UpdateBoothAsync(int pollId,int vsId,int year, BoothMasterDto boothMasterDto)
        {
            if (vsId==0 ||year==0 || pollId == 0)
            {
                return "Invalid data to Update";
            }
            var boothData = db.tblBoothMaster.FirstOrDefault(x => x.BoothNumber == pollId && x.VidhansabhaID==vsId && x.Year==year);

            if (boothData == null)
            {
                return "Record Not Found";
            }
            boothData.Year = boothMasterDto.Year;
            boothData.VidhansabhaID = boothMasterDto.VidhansabhaID;
            boothData.BoothNumber = boothMasterDto.BoothNumber;
            boothData.BoothName = boothMasterDto.BoothName;
            boothData.BoothPlace = boothMasterDto.BoothPlace;
            boothData.MaleVoter = boothMasterDto.MaleVoter;
            boothData.FemaleVoter = boothMasterDto.FemaleVoter;
            boothData.TotalVoter = boothMasterDto.TotalVoter;
            boothData.PublicationDate = boothMasterDto.PublicationDate;
            boothData.BoothNameEnglish = boothMasterDto.BoothNameEnglish;
            boothData.BoothPlaceEnglish = boothMasterDto.BoothPlaceEnglish;
            db.tblBoothMaster.Update(boothData);
            await db.SaveChangesAsync();
            return "Record Updated Successfully";
        }
    }
}
