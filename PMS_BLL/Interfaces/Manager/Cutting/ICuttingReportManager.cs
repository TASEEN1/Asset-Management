using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.Cutting
{
    public interface ICuttingReportManager
    {
        byte[] LayWiseReport(string reportType,int comID, int style, int cut, int lay, string UserName);
        byte[] Cut_Style_CountryReport(string reportType, int comID, int style, int po, int country, string UserName);
        byte[] DailyCuttingReport(string reportType, int comID, DateTime CutDate, string UserName);
        byte[] StylePOLayWiseReport(string reportType, int comID, int style, string po, int lay, string UserName);
        byte[] CuttingSummaryD2DReport(string reportType, int comID, string fromdate, string todate, string UserName);
        byte[] StyleWiseCuttingToInputReport(string reportType, int comID, int styleID, string style, string UserName);
        byte[] StylePOWiseCuttingToInputReport(string reportType, int comID, int styleID, string style, string poID, string PO, string UserName);
        byte[] StyleWiseClosingCuttingToInputReport(string reportType, int comID, int styleID, string style, string UserName);
    }
}

