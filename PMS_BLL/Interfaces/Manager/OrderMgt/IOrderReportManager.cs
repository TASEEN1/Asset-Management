using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IOrderReportManager
    {
        public byte[] OrderReceivedReport(int comID, string UserName, string reportType, int? customer, string? style_No, DateTime FromDate, DateTime ToDate);
        public byte[] ProformaInvoiceReport(int comID, string UserName, string reportType, int? customer, string? style_No, DateTime FromDate, DateTime ToDate);
        




    }
}
