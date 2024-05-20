using PMS_BLL.Interfaces.Manager.Asset_Master;
using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.Asset_Master
{
    public class Asset_TransferManager: IAsset_TransferManager
    {
        
            private readonly Dg_SqlCommon _SqlCommon;
            private readonly SqlConnection _specfo_conn;
            private readonly SqlConnection _dg_Asst_Mgt;
            private readonly SqlConnection _specFo_inventory;

            public Asset_TransferManager(Dg_SqlCommon sqlCommon)
            {
                _SqlCommon = sqlCommon;
                _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
                _specFo_inventory = new SqlConnection(Dg_Getway.SpecFoInventory);
                _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            }

        public async Task<DataTable> Get_Company_CH()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName",_specfo_conn);
            return data;
        }
        public async Task<DataTable> BindFloor( int ComID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT nFloor, cFloor_Descriptin from Smt_Floor where CompanyID = '"+ ComID + "' Order by cFloor_Descriptin ",_specfo_conn);
            return data;
        }
        
    }
}
