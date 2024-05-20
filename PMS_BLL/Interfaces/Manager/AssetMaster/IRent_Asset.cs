using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.AssetMaster
{
    public interface IRent_Asset
    {
        Task<DataTable>GetCURRENT_HOLDER();
        Task<DataTable> GetBind_Floor(int comID);
        Task<DataTable> GetBind_Line( int ComID , int floorID);
        Task<DataTable> GetMachine_Name();
        Task<DataTable> Get_Asset_Category();
        Task<DataTable> Get_Brand();
        Task<DataTable> GetSupplierName();
        Task<DataTable> GetAsstSpecialFeature(); 
        Task<DataTable> GetAssetStatus();
        Task<DataTable> GetCurrency();

        Task<string> Rent_Asset_Save(List<Rent_Asset_Model> Asst_Rent);
        Task<string> Update_Asset_Rent (List<Rent_Asset_Model> Asst_Rent_put);
       
    }
}
