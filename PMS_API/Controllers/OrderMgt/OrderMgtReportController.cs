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
        public async Task<IActionResult> OrderReceivedReport(int comID, string UserName, string reportType, int? customer, string? style_No,  DateTime FromDate, DateTime ToDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data =  _globalMaster.orderReportManager.OrderReceivedReport(comID, UserName, reportType,customer,style_No,FromDate,ToDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }


        [HttpGet]
        public async Task<IActionResult> ProformaInvoiceReport(int comID, string UserName, string reportType, int? customer, string? style_No, DateTime FromDate, DateTime ToDate)


        {
            ReportFileExt reportFileExt = new ReportFileExt();
            var data = _globalMaster.orderReportManager.ProformaInvoiceReport(comID, UserName, reportType, customer, style_No,  FromDate, ToDate);
            return File(data, MediaTypeNames.Application.Octet, (reportFileExt.GetContentType(reportType)));
        }

    }
}
