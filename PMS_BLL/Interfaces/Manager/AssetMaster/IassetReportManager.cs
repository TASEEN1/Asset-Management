using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface IAssetReportManager
    {
        public byte[] AssetInfoDetailsRpt(string reportType, int comID);

    }
}
