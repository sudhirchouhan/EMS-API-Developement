using EMS_Data_API.Models.DTO;
using EMS_Data_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Data_API.Controllers
{
    [Route("api/booth")]
    [ApiController]
    public class BoothController : ControllerBase
    {
        private readonly IBoothMasterRepo boothRepo;
        private ResultResponseDTO responseDTO;
        public BoothController(IBoothMasterRepo _boothRepo)
        {
            boothRepo = _boothRepo;
            responseDTO = new ResultResponseDTO();
        }
        [HttpGet("GetBoothDataByID")]
        public async Task<IActionResult> GetBoothById(int pollId,int vsId,int year)
        {
            if (pollId == 0 || vsId==0 || year==0)
            {
                return BadRequest("Data Should Not be Zero");
            }
            var ReturnData = await boothRepo.SelectBoothByIdAsync(pollId,vsId,year);
            if (ReturnData == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(ReturnData);
        }
        [HttpGet("GetBoothList")]
        public async Task<IActionResult> GetBoothList()
        {

            var ReturnData = await boothRepo.SelectBoothListAsync();
            if (ReturnData.Count() == 0)
            {
                return NotFound("Data Not Found");
            }
            responseDTO.Result= ReturnData;
            return Ok(responseDTO);
        }
        [HttpPost("insertBooth")]
        public async Task<IActionResult> AddBooth([FromBody] BoothMasterDto model)
        {
            var result = await boothRepo.AddBoothAsync(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Issues in Saving the Record..");

        }
        [HttpPut("updateBooth")]
        public async Task<IActionResult> UpdateBooth(int pollId,int vsId,int year, BoothMasterDto model)
        {
            var result = await boothRepo.UpdateBoothAsync(pollId,vsId,year, model);
            if (result != null)
            {
                responseDTO.Result= result;
                return Ok(responseDTO);
            }
            return BadRequest("Issues in Updating the Record..");

        }
        [HttpDelete("DeleteBooth")]
        public async Task<IActionResult> DeleteBooth(int pollId,int vsId,int year)
        {
            var result = await boothRepo.DeleteBoothAsync(pollId,vsId,year);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Issues in Deleting the Record..");

        }
    }
}
