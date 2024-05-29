using PMS_BLL.Interfaces.Manager;
using PMS_BLL.Interfaces.Manager.Asset_Master;
using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Interfaces.Manager.Cutting;

namespace PMS_BLL.Interfaces
{
    public interface IGlobalMaster
    {
        IUserLoginManager userLogin { get; }
      
        ICuttingManager cuttingmanager { get; }
        ICuttingReportManager cuttingreportmanager { get; }
        IAssetMasterManager assetmastermanager { get; }
        IRent_Asset rent_Asset { get; }
        IRentedAssetReturnManager rentedAssetReturnManager { get; }
        IAsset_TransferManager asset_TransferManager { get; }
        IAsset_Running_Repair asset_Running_Repair { get; }
        Ischedule_Maintenance schedule_Maintenance { get; }
        IassetReportManager asset_ReportManager { get; }

       
    }
}