using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class workOrderController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public workOrderController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }




    }
}
