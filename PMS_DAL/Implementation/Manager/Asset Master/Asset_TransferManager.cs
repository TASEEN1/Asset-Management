using PMS_BLL.Interfaces.Manager.Asset_Master;
using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Utility;
using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.Asset_Master
{
    public class Asset_TransferManager : IAsset_TransferManager
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
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT dbo.Smt_Company.nCompanyID, dbo.Smt_Company.cCmpName FROM dbo.Smt_StyleMaster INNER JOIN dbo.Smt_Company ON dbo.Smt_StyleMaster.cCmp = dbo.Smt_Company.nCompanyID where ConfirmStatus='CONF' order by cCmpName", _specfo_conn);
            return data;
        }
        public async Task<DataTable> BindFloor(int ComID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT nFloor, cFloor_Descriptin from Smt_Floor where CompanyID = '" + ComID + "' Order by cFloor_Descriptin ", _specfo_conn);
            return data;
        }

        public async Task<DataTable> GetLine(int comID, int floorID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT Line_Code,Line_No from Smt_Line where CompanyID='" + comID + "' and FloorID='" + floorID + "' Order by Line_No ", _specfo_conn);

            return data;
        }

        public async Task<DataTable> IGet_Asst_No(int ComID, int floorID, int LineID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT McAsstNo  FROM Mr_Asset_Master_List  where McCompanyID='" + ComID + "' and  nFloor='" + floorID + "' and Line_Code='" + LineID + "' order by McAsstNo", _dg_Asst_Mgt);
            return data;
        }

        public async Task<DataTable> EGet_Asst_No(int ComID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT McAsstNo  FROM Mr_Asset_Master_List  where McCompanyID='" + ComID + "'  and Mc_Transfer=0 order by McAsstNo", _dg_Asst_Mgt);
            return data;
        }



        public async Task<string> Internal_Transfer_Save(List<Asset_Transfer_Model> App)
        {
            string message = string.Empty;
            await _dg_Asst_Mgt.OpenAsync();


            try
            {
                foreach (Asset_Transfer_Model Apps in App)
                {
                    SqlCommand cmd = new SqlCommand("Mr_Internal_Transfer_Save", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AssetNo", Apps.AssetNo);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ComFrom", Apps.ComFrom);
                    cmd.Parameters.AddWithValue("@ComTo", Apps.ComTo);
                    cmd.Parameters.AddWithValue("@FloorFrom", Apps.FloorFrom);
                    cmd.Parameters.AddWithValue("@FloorTo", Apps.FloorTo);
                    cmd.Parameters.AddWithValue("@LineFrom", Apps.LineFrom);
                    cmd.Parameters.AddWithValue("@LineTo", Apps.LineTo);
                    cmd.Parameters.AddWithValue("@Status", Apps.Status);
                    cmd.Parameters.AddWithValue("@Remarks", Apps.Remarks);
                    cmd.Parameters.AddWithValue("@InputUser", Apps.InputUser);
                    cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    message = (string)cmd.Parameters["@ERROR"].Value;
                }



            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                _dg_Asst_Mgt.Close();
            }
            return message;
        }

        public async Task<DataTable> Internal_Transfer_View(int comID, string UID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Internal_Transfer_Add_View '" + comID + "' and ' " + UID + "'", _dg_Asst_Mgt);
            return data;
        }
    }
}
