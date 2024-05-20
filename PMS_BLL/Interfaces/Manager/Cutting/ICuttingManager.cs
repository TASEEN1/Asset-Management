using PMS_BOL.Models;
using System.Data;

namespace PMS_BLL.Interfaces.Manager.Cutting
{
    public interface ICuttingManager
    {
        Task<DataTable> GetCompany();
        Task<DataTable> GetYear();
        Task<DataTable> GetBuyer(int comID, int Year);
        Task<DataTable> GetStyle(int comID, int buyerID);
        Task<DataTable> GetStyleInfo(int buyerID, int styleID);
        Task<DataTable> GetCutMasterView(int styleID);
        Task<string> SaveCutMaster(CutMaster cut);
        Task<DataTable> GetCuttingYear(int comID);
        Task<DataTable> GetCuttingStyle(int Year, int comID);
        Task<DataTable> GetCuttingPO(int styleID);
        Task<DataTable> GetCuttingCountry(int styleID, string POID);
        Task<DataTable> GetCuttingCutNo(int styleID, string POID);
        Task<DataTable> GetCuttingLayNo(int styleID, string POID);
        Task<DataTable> GetCuttingSizeRatio(int styleID, string POID);
        Task<DataTable> GetCuttingColor(int styleID, string POID);
        Task<DataTable> GetCuttingFabricDetails(int styleID, string POID);
        Task<string> SaveCutting(List<CuttingSave> cut);
        Task<string> SaveCuttingLaySize(List<CuttingLaySize> CLS);
        Task<DataTable> ForApprovalCuttingView(int comID);
        Task<DataTable> ApprovalCuttingView(int comID);
        Task<bool> ForApprovalCutting(List<CutForApprove> App);
        Task<bool> ApprovalCutting(List<CutForApprove> App);
        Task<bool> CancelCutting(List<CutForApprove> App);
        Task<DataTable> GetCompanyUserWise(int comID);
        Task<DataTable> GetLay(int styleID, string POID);
        Task<DataTable> GetCuttingStyleReport(int Year, int comID);
    }
}
