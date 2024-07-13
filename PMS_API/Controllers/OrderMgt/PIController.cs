using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.OrderMgt;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class PIController : ControllerBase
    {

        private readonly IGlobalMaster _globalMaster;

        public PIController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }



        [HttpPost]
        public async Task<IActionResult> GeneratePIAdd(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.GeneratePIAdd(app);
            return Ok(new { message = data });

        }



        [HttpPut]
        public async Task<IActionResult> GeneratePI(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.GeneratePI(app);
            return Ok(new { message = data });

        }

        [HttpGet]
        public async Task<IActionResult> GetGeneratePIAddView(int Customer, int Buyer, string created_By)
        {
            var data = await _globalMaster.piManager.GetGeneratePIAddView(Customer, Buyer,created_By);
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetPIAddView(int Customer, string style, int Ref_no)
        {
            var data = await _globalMaster.piManager.GetPIAddView(Customer, style, Ref_no);
            return Ok(data);
        }


        [HttpDelete]
        public async Task<IActionResult> PIDelete(List<PI_Model> app)
        {
            var data = await _globalMaster.piManager.PIDelete(app);
            return Ok(new { message = data });

        }
    }
}
