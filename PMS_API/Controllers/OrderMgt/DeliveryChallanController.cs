using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class DeliveryChallanController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public DeliveryChallanController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }
        //Common 
        //GetDelivery_Challan_PINumber(customer wise)
        [HttpGet]
        public async Task<IActionResult> GetDelivery_Challan_PINumber(string PI_Number, int custParamForPI, int pageProcId, int itemProcId)
        {
            var data = await _globalMaster.challanManager.GetDelivery_Challan_PINumber(PI_Number, custParamForPI, pageProcId, itemProcId);
            return Ok(data);
        }




        //-------Padding------//

        //Drop Down

        [HttpGet]
        public async Task<IActionResult> GetPadding_Challan_ProcessType()
        {
            var data = await _globalMaster.challanManager.GetPadding_Challan_ProcessType();
            return Ok(data);
        }
    }
}
