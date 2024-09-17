using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Order_Mgt;
using PMS_DAL.Implementation;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PlaningController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public PlaningController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        //DROP DOWN

        [HttpGet]
        public async Task<IActionResult> Get_PI_Number()
        {
            var data = await _globalMaster.planingManager.Get_PI_Number();
            return Ok(data);
        }
        //VIEW
        [HttpGet]
        public async Task<IActionResult> GetPlaning_Details_BeforeAdd(string Pi_Number, int Proc_ID)
        {
            var data = await _globalMaster.planingManager.GetPlaning_Details_BeforeAdd(Pi_Number,Proc_ID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetPlaning_Details_AfterAdd(string Pi_Number, int Proc_ID, string sessionUser)
        {
            var data = await _globalMaster.planingManager.GetPlaning_Details_AfterAdd(Pi_Number, Proc_ID,sessionUser);
            return Ok(data);
        }
        //ADD/SAVE


        [HttpPost]
        public async Task<IActionResult> PlaningSave(List<PlaningModel> PL)
        {
            var data = await _globalMaster.planingManager.PlaningSave(PL);

            return Ok(new { message = data });
        }

        [HttpPut]
        public async Task<IActionResult> PlaningComplete(List<PlaningModel> PL)
        {
            var data = await _globalMaster.planingManager.PlaningComplete(PL);

            return Ok(new { message = data });
        }

        [HttpDelete]
        public async Task<IActionResult> PL_Delete(List<PlaningModel> PL)
        {
            var data = await _globalMaster.planingManager.PL_Delete(PL);

            return Ok(new { message = data });
        }
    }
   
}
