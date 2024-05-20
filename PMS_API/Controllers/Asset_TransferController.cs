using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Models;

namespace PMS_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class Asset_TransferController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public Asset_TransferController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> Get_Company_CH()
        {
            var data = _globalMaster.asset_TransferManager.Get_Company_CH();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> BindFloor(int ComID)
        {
            var data = _globalMaster.asset_TransferManager.BindFloor(ComID);
            return Ok(data);


        }

        [HttpGet]
        public async Task<IActionResult> GetLine(int ComID, int floorID)
        {
            var data = _globalMaster.asset_TransferManager.GetLine(ComID, floorID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> IGet_Asst_No(int ComID, int floorID, int LineID)
        {
            var data = _globalMaster.asset_TransferManager.IGet_Asst_No(ComID, floorID, LineID);
            return Ok(data);
        }
        [HttpGet]
        public async Task<IActionResult> EGet_Asst_No(int ComID)
        {
            var data = _globalMaster.asset_TransferManager.EGet_Asst_No(ComID);
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Internal_Transfer_Save(List<Asset_Transfer_Model> App)
        {
            var data = await _globalMaster.asset_TransferManager.Internal_Transfer_Save(App);
            return Ok(new { message = data });

        }
        [HttpGet]
        public async Task<IActionResult> Internal_Transfer_View(int comID , string UID)
        {
            var data = await _globalMaster.asset_TransferManager.Internal_Transfer_View(comID, UID);
            return Ok(data);
        }
    }
}