using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models.OrderMgt;

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


        [HttpGet]
        public async Task<IActionResult> GetItemDescription()
        {
            var data = await _globalMaster.orderManager.GetItemDescription();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetProcessType()
        {
            var data = await _globalMaster.orderManager.GetProcessType();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> Getbuyer()
        {
            var data = await _globalMaster.orderManager.Getbuyer();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var data = await _globalMaster.orderManager.GetCustomer();
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> OrderReceivedAddView(int Customer, int Buyer, string Style_no)
        {
            var data = await _globalMaster.orderManager.OrderReceivedAddView(Customer, Buyer, Style_no);
            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> ColorSave(List<ColorSave> app)
        {
            var data = await _globalMaster.orderManager.ColorSave(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> OrderReceivedAdd(List<OrderReceivingAdd> app)
        {
            var data = await _globalMaster.orderManager.OrderReceivedAdd(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> OrderReceivedComplete(List<OrderReciveComplete> app)
        {
            var data = await _globalMaster.orderManager.OrderReceivedComplete(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> ItemDescriptionSave(List<ItemDescriptionSave> app)
        {
            var data = await _globalMaster.orderManager.ItemDescriptionSave(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> ProcessTypeSave(List<ProcessTypeSave> app)
        {
            var data = await _globalMaster.orderManager.ProcessTypeSave(app);
            return Ok(new { message = data });

        }
        [HttpPost]
        public async Task<IActionResult> BuyerSave(List<BuyerSave> app)
        {
            var data = await _globalMaster.orderManager.BuyerSave(app);
            return Ok(new { message = data });

        }

        [HttpPost]
        public async Task<IActionResult> CustomerSave(List<customerSave> app)
        {
            var data = await _globalMaster.orderManager.CustomerSave(app);
            return Ok(new { message = data });

        }

    }
}
