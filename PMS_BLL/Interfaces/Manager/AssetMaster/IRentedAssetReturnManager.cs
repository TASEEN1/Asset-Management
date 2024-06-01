using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.Asset_Master
{
    public interface IRentedAssetReturnManager
    {
        Task<DataTable> GetCurrentHolder();
        Task<DataTable> GetSupplier(int currentHolder);
        Task<DataTable> GetAssetName(string supplierId);
        Task<DataTable> GetRentAssetList(int currentHolderId, string supplierId);
        Task<String> PutReturnAdd(List<RentAssetAdd> put_return_add);
        Task<DataTable> GetReturnAddView(int currentHolderId, string supplierId);
        Task<String> PutAssetRent(List<AssetRentComplete> put_asset_rent);
        Task<DataTable> GetEId();
        Task<DataTable> ForApproval_AssetReturnView(int comID);
        Task<DataTable> ForApproval_Asset_ReturnView(int comID);
        Task<bool> ForApproval_Asset_Return(List<AssetForApprove> App);
        Task<bool> Asset_ReturnCancel(List<AssetReturnCancel> App);





    }
}
