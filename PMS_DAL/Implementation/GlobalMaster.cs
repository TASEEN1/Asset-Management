using Microsoft.AspNetCore.Hosting;
using PMS_BLL.Interfaces;
using PMS_BLL.Interfaces.Manager;
using PMS_BLL.Interfaces.Manager.Asset_Master;
using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Interfaces.Manager.Cutting;
using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using PMS_DAL.Implementation.Manager;
using PMS_DAL.Implementation.Manager.Asset_Master;
using PMS_DAL.Implementation.Manager.Cutting;
using PMS_DAL.Implementation.Manager.OrderMgt;

namespace PMS_DAL.Implementation
{
    public class GlobalMaster : IGlobalMaster
    {
        private readonly Dg_SqlCommon _sqlCommon;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GlobalMaster(Dg_SqlCommon sqlCommon, IWebHostEnvironment webHostEnvironment)
        {
            _sqlCommon = sqlCommon;
            _webHostEnvironment = webHostEnvironment;
         //Asset Managment System
            userLogin = new UserLoginManager(_sqlCommon);
            cuttingmanager = new CuttingManager(_sqlCommon);
            cuttingreportmanager = new CuttingReportManager(_sqlCommon, _webHostEnvironment);
            assetmastermanager = new AssetMasterManager(_sqlCommon);
            rent_Asset = new RentAssetManager(_sqlCommon);
            rentedAssetReturnManager = new RentedAssetReturnManager(_sqlCommon);
            asset_TransferManager = new AssetTransferManager(_sqlCommon);
            asset_Running_Repair = new AssetRunningRepairManager(_sqlCommon);
            schedule_Maintenance = new scheduleMaintenanceManager(_sqlCommon);
            asset_ReportManager = new AssetReportManager(_sqlCommon, _webHostEnvironment);


            //--OMS
            orderManager = new OrderManager(_sqlCommon);
            orderReportManager = new OrderReportManager (_sqlCommon, _webHostEnvironment);








        }
        //Asset Managment System
            public IUserLoginManager userLogin { get; private set; }
            public ICuttingManager cuttingmanager { get; private set; }
            public ICuttingReportManager cuttingreportmanager { get; private set; }
            public IAssetMasterManager assetmastermanager { get; private set; }
            public IRentAsset rent_Asset { get; private set; }
            public IRentedAssetReturnManager rentedAssetReturnManager { get; private set; }
            public IAssetTransferManager asset_TransferManager { get; private set; }
            public IAssetRunningRepair asset_Running_Repair { get; private set; }
            public Ischedule_Maintenance schedule_Maintenance { get; private set; }
            public IAssetReportManager asset_ReportManager { get; private set; }

        //OMS
            public IOrderManager orderManager { get; private set; }

            public IOrderReportManager orderReportManager { get; private set; }







    }
}
