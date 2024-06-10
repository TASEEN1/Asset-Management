using PMS_BLL.Interfaces.Manager.AssetMaster;
using PMS_BLL.Utility;
using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.Asset_Master
{
    public class scheduleMaintenanceManager: Ischedule_Maintenance
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _specFo_inventory;

        public scheduleMaintenanceManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _specFo_inventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
        }

        public async Task<DataTable> GetAssetNo()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT DISTINCT McAsstNo FROM Mr_Asset_Master_List ORDER BY McAsstNo", _dg_Asst_Mgt);
            return data;
        }

        public async Task<DataTable> GetAsset_Master_List(string AsstNo)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("Mr_Asset_Master_List_Select '" + AsstNo + "'", _dg_Asst_Mgt);
            return data;
        }

        public async Task<string> ScheduleMaintenanceSave(List<ScheduleMaintenanceModel> App)
        {
            string message = string.Empty;
            await _dg_Asst_Mgt.OpenAsync();


            try
            {
                foreach (ScheduleMaintenanceModel asset in App)
                {
                    SqlCommand cmd = new SqlCommand("Mr_Schedule_Maintenance_Save", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@assetno", asset.assetno);
                    cmd.Parameters.AddWithValue("@nextservicedate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@ItemReplaced", asset.itemreplace);
                    cmd.Parameters.AddWithValue("@readydate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@doneby", asset.doneby);
                    cmd.Parameters.AddWithValue("@InputUser", asset.InputUser);
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


        public async Task<string> SM_service_Typesave(List<SMServiceTypeSave_Model> app)
        {
            string message = string.Empty;
            await _dg_Asst_Mgt.OpenAsync();


            try
            {
                foreach (SMServiceTypeSave_Model asset in app)
                {
                    SqlCommand cmd = new SqlCommand("Mr_SM_Service_Type_Save", _dg_Asst_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AssetNo", asset.assetno);
                    cmd.Parameters.AddWithValue("@ServiceID", asset.ServiceID);
                    cmd.Parameters.AddWithValue("@ReadyDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@InputUser", asset.InputUser);
                    //cmd.Parameters.Add("@ERROR", SqlDbType.Char, 500);
                    //cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;
                    await cmd.ExecuteNonQueryAsync();
                    //message = (string)cmd.Parameters["@ERROR"].Value;
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


    }
}
