using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Reporting.Map.WebForms.BingMaps;
using PMS_BLL.Interfaces;
using PMS_BLL.Utility;
using PMS_DAL.Implementation.Manager.Asset_Master;
using System.Drawing;
using System.Net.Mime;

namespace PMS_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssetReportController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public AssetReportController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> AssetDetailsSummary(string reportType, int comID, string UserName)
        {
            var data = _globalMaster.asset_ReportManager.AssetDetailsSummary(reportType, comID, UserName);
            return File(data, MediaTypeNames.Application.Octet, (reportType));
        }

        [HttpGet]
        public async Task<IActionResult> AssetManagementReport(string reportType, int comID, string UserName)
        {
            var data = _globalMaster.asset_ReportManager.AssetManagementReport(reportType, comID, UserName);
            return File(data, MediaTypeNames.Application.Octet, (reportType));
        }

        [HttpGet]
        public async Task<IActionResult> AssetSummaryReport(string reportType, int comID, string UserName)
        {
            var data = _globalMaster.asset_ReportManager.AssetSummaryReport(reportType, comID, UserName);
            return File(data, MediaTypeNames.Application.Octet, (reportType));
            //return File(data, MediaTypeNames.Application.Octet, "PDF");
        }
        [HttpGet]
        public async Task<IActionResult> RentedAssetDetailsReport(string reportType, int comID, string UserName)
        {
            var data = _globalMaster.asset_ReportManager.RentedAssetDetailsReport(reportType, comID, UserName);
            return File(data, MediaTypeNames.Application.Octet, (reportType));
            //return File(data, MediaTypeNames.Application.Octet, "PDF");
        }

    }
}
