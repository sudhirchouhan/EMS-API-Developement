using EMS_Data_API.Models.DTO;
using EMS_Data_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EMS_Data_API.Controllers
{
    [Route("api/vidhansabha")]
    [ApiController]
    public class VidhansabhaController : ControllerBase
    {
        private readonly IVidhansabhaMasterRepo vidhanSabhaRepo;
        public VidhansabhaController(IVidhansabhaMasterRepo _vidhanSabhaRepo)
        {
            vidhanSabhaRepo = _vidhanSabhaRepo;
        }
        [HttpGet("GetVidhansabhaDataByID")]
        public async Task<IActionResult> GetVidhansabhaById(int vsId)
        {
            if (vsId == 0)
            {
                return BadRequest("ID Should Not be Zero");
            }
            var ReturnData=await vidhanSabhaRepo.SelectVidhansabhaByIdAsync(vsId);
            if(ReturnData == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(ReturnData);
        }
        [HttpGet("GetVidhansabhaList")]
        public async Task<IActionResult> GetVidhansabhaList()
        {
           
            var ReturnData = await vidhanSabhaRepo.SelectVidhansabhaListAsync();
            if (ReturnData == null)
            {
                return NotFound("Data Not Found");
            }
            return Ok(ReturnData);
        }
        [HttpPost("saveVidhansabha")]
        public async Task<IActionResult> AddVidhansabha([FromBody] VidhansabhaMasterDto model)
        {
           var result= await vidhanSabhaRepo.AddVidhansabhaAsync(model);
            if(result!=null)
            {
                return Ok(result);
            }
            return BadRequest("Issues in Saving the Record..");

        }
        [HttpPut("updateVidhansabha")]
        public async Task<IActionResult> UpdateVidhansabha(int vsId, VidhansabhaMasterDto model)
        {
            var result = await vidhanSabhaRepo.UpdateVidhansabhaAsync(vsId,model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Issues in Updating the Record..");

        }
        [HttpDelete("DeleteVidhansabha")]
        public async Task<IActionResult> DeleteVidhansabha(int vsId)
        {
            var result = await vidhanSabhaRepo.DeleteVidhansabhaAsync(vsId);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("Issues in Deleting the Record..");

        }
    }
}
