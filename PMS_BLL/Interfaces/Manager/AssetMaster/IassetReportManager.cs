using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface IAssetReportManager
    {
        public byte[] AssetDetailsSummary(string reportType, int comID,  string UserName);

        public byte[] AssetDetailsReport(string reportType, int comID, string UserName);
        public byte[] AssetDetails_RepairReport(string reportType, int comID, string UserName);
        public byte[] AssetDetailsMaster_Report(string reportType, int comID, string UserName);
        public byte[] AssetManagementReport(string reportType, int comID, string UserName);
        public byte[] AssetSummaryReport(string reportType, int comID, string UserName);
        public byte[] RentedAssetDetailsReport(string reportType, int comID, string UserName);
        public byte[] InternalFixedAssetTransferReport(string reportType, int comID, string UserName);
        public byte[] ExternalFixedAssetTransferReport(string reportType, int fromComId, int toComId, string UserName);




    }

    
}
