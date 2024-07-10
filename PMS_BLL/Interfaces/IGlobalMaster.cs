using PMS_BLL.Interfaces.Manager;
using PMS_BLL.Interfaces.Manager.Asset_Master;
using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Interfaces.Manager.Cutting;
using PMS_BLL.Interfaces.Manager.OrderMgt;

namespace PMS_BLL.Interfaces
{
    public interface IGlobalMaster
    {
        //Asset Managment System
        IUserLoginManager userLogin { get; }
        ICuttingManager cuttingmanager { get; }
        ICuttingReportManager cuttingreportmanager { get; }
        IAssetMasterManager assetmastermanager { get; }
        IRentAsset rent_Asset { get; }
        IRentedAssetReturnManager rentedAssetReturnManager { get; }
        IAssetTransferManager asset_TransferManager { get; }
        IAssetRunningRepair asset_Running_Repair { get; }
        Ischedule_Maintenance schedule_Maintenance { get; }
        IAssetReportManager asset_ReportManager { get; }


        //-------OMS
        IOrderManager orderManager { get; }
        IOrderReportManager orderReportManager { get; }



    }
}