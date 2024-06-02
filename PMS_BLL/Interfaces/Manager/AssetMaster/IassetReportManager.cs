using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface IAssetReportManager
    {
        public byte[] AssetDetailsSummary(string reportType, int comID, string AsstCat, int status, int floor, int line, string UserName);

        public byte[] AssetDetailsReport(string reportType, int comID, string UserName);


    }

    
}
