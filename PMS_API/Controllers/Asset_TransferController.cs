using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;

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
            var data= _globalMaster.asset_TransferManager.Get_Company_CH();
            return Ok(data);
        }

        [HttpGet]
        public async Task<IActionResult> BindFloor(int ComID)
        {
            var data= _globalMaster.asset_TransferManager.BindFloor(ComID);
            return Ok(data);


        }
    }
}
