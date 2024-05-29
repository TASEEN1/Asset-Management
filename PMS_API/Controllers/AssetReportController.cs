using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;

namespace PMS_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetReportController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public AssetReportController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }


    }
}
