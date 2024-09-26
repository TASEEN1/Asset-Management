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
        public byte[] OrderReceivedReport(int comID, string UserName, string reportType, int? customer,string? style );
        public byte[] OrderReceivedReportD2D(int comID, string UserName, string reportType, DateTime FromDate, DateTime ToDate);

        public byte[] ProformaInvoiceReport(int comID, string UserName, string reportType,  string? pi_number);
        public byte[] WorkOrderReportFormate(int comID, string UserName, string reportType, int Rrf_No,int customerId);
        public byte[] AttributeFromReport(int comID, string UserName, string reportType, string? pi_number);

        public byte[] ProductionSummaryReport(int comID, string UserName, string reportType, DateTime FromDate, DateTime ToDate);
        public byte[] DailyProductionSummaryReport(int comID, string UserName, string reportType,int processType, DateTime FromDate, DateTime ToDate);
        public byte[] DailyPlaningReport(int comID, string UserName, string reportType, int processType, DateTime FromDate);
        public byte[] StyleWisePeoductionReport(int comID, string UserName, string reportType,int customer , int refNO  , string style, int processType, DateTime FromDate);
        public byte[] HourlyPeoductionReport(int comID, string UserName, string reportType, DateTime productionDate,int? prodprocID);














    }
}
