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
        public async Task<IActionResult> GetBuyer()
        {
            var data = await _globalMaster.orderManager.GetBuyer();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer()
        {
            var data = await _globalMaster.orderManager.GetCustomer();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetDia()
        {
            var data = await _globalMaster.orderManager.GetDia();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> Getgsm()
        {
            var data = await _globalMaster.orderManager.Getgsm();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> Getdesign()
        {
            var data = await _globalMaster.orderManager.Getdesign();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetBuyerView()
        {
            var data = await _globalMaster.orderManager.GetBuyerView();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetcustomerView()
        {
            var data = await _globalMaster.orderManager.GetcustomerView();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetcolorView()
        {
            var data = await _globalMaster.orderManager.GetcolorView();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetdesignView()
        {
            var data = await _globalMaster.orderManager.GetdesignView();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetDiaView()
        {
            var data = await _globalMaster.orderManager.GetDiaView();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetgsmView()
        {
            var data = await _globalMaster.orderManager.GetgsmView();
            return Ok(data);

        }
        [HttpGet]
        public async Task<IActionResult> GetitemView()
        {
            var data = await _globalMaster.orderManager.GetitemView();
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> GetprocessTypeview()
        {
            var data = await _globalMaster.orderManager.GetprocessTypeview();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetStyleEdit(int custID)
        {
            var data = await _globalMaster.orderManager.GetStyleEdit(custID);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerEdit()
        {
            var data = await _globalMaster.orderManager.GetCustomerEdit();
            return Ok(data);
        }


        [HttpGet]
        public async Task<IActionResult> OrderReceivedAddView(int Customer, int Buyer, string Style_no)
        {
            var data = await _globalMaster.orderManager.OrderReceivedAddView(Customer, Buyer, Style_no);
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderReceivedAddEditView(int Customer, int Buyer, string Style_no)
        {
            var data = await _globalMaster.orderManager.GetOrderReceivedAddEditView(Customer, Buyer, Style_no);
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

        [HttpPost]
        public async Task<IActionResult> DiaSave(List<diaSave> app)
        {
            var data = await _globalMaster.orderManager.DiaSave(app);
            return Ok(new { message = data });

        }
        [HttpPost]
        public async Task<IActionResult> GsmSave(List<gsmSave> app)
        {
            var data = await _globalMaster.orderManager.GsmSave(app);
            return Ok(new { message = data });

        }
        [HttpPost]
        public async Task<IActionResult> DesignSave(List<designSave> app)
        {
            var data = await _globalMaster.orderManager.DesignSave(app);
            return Ok(new { message = data });

           
        }
        [HttpDelete]
        public async Task<IActionResult> OrderReceiveDelete(List<orderReceiveDelete> app)
        {
            var data = await _globalMaster.orderManager.OrderReceiveDelete(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> OrderReceiveUpdate(List<OrderReceivingAdd> app)
        {
            var data = await _globalMaster.orderManager.OrderReceiveUpdate(app);
            return Ok(new { message = data });

        }
        [HttpDelete]
        public async Task<IActionResult> CustomerDelete(List<customerSave> app)
        {
            var data = await _globalMaster.orderManager.CustomerDelete(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> CustomerUpdate(List<customerSave> app)
        {
            var data = await _globalMaster.orderManager.CustomerUpdate(app);
            return Ok(new { message = data });

        }

        [HttpDelete]
        public async Task<IActionResult> BuyerDelete(List<BuyerSave> app)
        {
            var data = await _globalMaster.orderManager.BuyerDelete(app);
            return Ok(new { message = data });

        }

        [HttpPut]
        public async Task<IActionResult> BuyerUpdate(List<BuyerSave> app)
        {
            var data = await _globalMaster.orderManager.BuyerUpdate(app);
            return Ok(new { message = data });

        }
    }
}
