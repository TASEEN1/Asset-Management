using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PMS_BLL.Interfaces;
using PMS_BOL.Functions;
using System.Net.Mime;

namespace PMS_API.Controllers.OrderMgt
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class OrderMgtReportController : ControllerBase
    {
        private readonly IGlobalMaster _globalMaster;

        public OrderMgtReportController(IGlobalMaster globalMaster)
        {
            _globalMaster = globalMaster;
        }

        [HttpGet]
        public async Task<IActionResult> OrderReceivedReport(int comID, string UserName, string reportType, int? Ref_NO ,DateTime FromDate, DateTime ToDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.OrderReceivedReport(comID, UserName, reportType, Ref_NO, FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }






        [HttpGet]
        public async Task<IActionResult> ProformaInvoiceReport(int comID, string UserName, string reportType, int? pi_issued_ref_no, string? pi_number)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.ProformaInvoiceReport(comID, UserName, reportType, pi_issued_ref_no, pi_number);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }


        [HttpGet]
        public async Task<IActionResult> WorkOrderReport(int comID, string UserName, string reportType, int Rrf_No)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.WorkOrderReport(comID, UserName, reportType, Rrf_No);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }
        [HttpGet]
        public async Task<IActionResult> WorkOrderReportFormate(int comID, string UserName, string reportType, int Rrf_No, int customerId)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.WorkOrderReportFormate(comID, UserName, reportType, Rrf_No,customerId);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

    }
}
