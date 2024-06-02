using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BLL.Utility;
using PMS_BOL.Functions;
using System.Net.Mime;

namespace PMS_API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class AssetReportController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public AssetReportController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        

        [HttpGet]
        public async Task<IActionResult> AssetDetailsSummary(string reportType, int comID, string AsstCat, int status, int floor, int line, string UserName)
       /* public byte[] AssetDetailsSummary(string reportType, int comID, string AsstCat, int status, int floor, int line, string UserName*/

        {
            var data =  _globalMaster.asset_ReportManager.AssetDetailsSummary(reportType, comID , AsstCat, status,floor,line,UserName);
            return File(data, MediaTypeNames.Application.Octet,(reportType));
        }

        [HttpGet]
        public async Task<IActionResult> AssetDetailsReport(string reportType , int ComID , string UserName)
        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.asset_ReportManager.AssetDetailsReport(reportType, ComID , UserName);
            return File(data, MediaTypeNames.Application.Octet,(reportFileExt.GetContentType(reportType)));
        }

    }

    }
