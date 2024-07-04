using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models;

namespace PMS_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderReceiveController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public OrderReceiveController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> GetPaymentType()
        {
            var data = await _globalMaster.orderManager.GetPaymentType();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetColor()
        {
            var data = await _globalMaster.orderManager.GetColor();
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> GetUnit()
        {
            var data = await _globalMaster.orderManager.GetUnit();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> ColorSave(List<ColorSave> app)
        {
            var data = await _globalMaster.orderManager.ColorSave(app);
            return Ok(new { message = data });

        }
    }
}
