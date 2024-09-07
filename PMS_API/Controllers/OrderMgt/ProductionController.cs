using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.Order_Mgt;
using PMS_BOL.Models.OrderMgt;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class ProductionController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public ProductionController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }
        //DropDown 
        [HttpGet]
        public async Task<IActionResult> GetmachineNo()
        {
            var data = await _globalMaster.productionManager.GetmachineNo();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetShift()
        {
            var data = await _globalMaster.productionManager.GetShift();
            return Ok(data);
        }
        //Modal
        [HttpGet]
        public async Task<IActionResult> GetmachineView()
        {
            var data = await _globalMaster.productionManager.GetmachineView();
            return Ok(data);
        }
        [HttpPost]
        public async Task<IActionResult> MachineDetailsSave(List<MachineDetails>MC)
        {
            var data = await _globalMaster.productionManager.MachineDetailsSave(MC);
            return Ok(new { message = data });
        }
        [HttpPost]
        public async Task<IActionResult> shiftSave(List<ShiftDetails> SF)
        {
            var data = await _globalMaster.productionManager.shiftSave(SF);
            return Ok(new { message = data });
        }
        [HttpPost]
        public async Task<IActionResult> Production_padding_save(List<ProductionModel> PD)
        {
            var data = await _globalMaster.productionManager.Production_padding_save(PD);
            return Ok(new { message = data });
        }
    }
}
