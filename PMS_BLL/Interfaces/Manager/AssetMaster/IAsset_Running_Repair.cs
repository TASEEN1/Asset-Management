using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface IAsset_Running_Repair
    {
        Task<DataTable> GetAssetNo();
        Task<DataTable> GetAsset_Master_List(string AsstNo);
        Task<string> Machine_Running_Repairsave(List<Asset_Running_RepairModel> App);
        Task<DataTable> GetMachineRunningRepair_View();
    }
}
