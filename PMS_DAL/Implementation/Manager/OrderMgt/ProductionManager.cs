using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using PMS_BOL.Models.Order_Mgt;
using PMS_BOL.Models.OrderMgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public class ProductionManager : IProductionManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        public ProductionManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }

        //DropDown
        public async Task<DataTable> GetmachineNo()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select md_id,md_machine_no from dg_dimtbl_machine_details order by md_machine_no", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetShift()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select ps_id, ps_shift_name from dg_dimtbl_production_shift order by ps_shift_name", _dg_Oder_Mgt);
            return data;
        }

        //Modal
        public async Task<DataTable> GetmachineView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_dimtbl_machine_details order by md_machine_no", _dg_Oder_Mgt);
            return data;
        }

        public async Task<string> MachineDetailsSave(List<MachineDetails> MC)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (MachineDetails ord in MC)
                {
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_machine_details_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@md_createdBy_compId", ord.ComID);
                    cmd.Parameters.AddWithValue("@md_machine_name", ord.machine_Name);
                    cmd.Parameters.AddWithValue("@md_machine_no", ord.machine_No);
                    cmd.Parameters.AddWithValue("@md_machine_capacity", ord.machine_capacity);
                    cmd.Parameters.AddWithValue("@md_created_by", ord.Created_by);
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
                _dg_Oder_Mgt.Close();
            }
            return message;
        }



        public async Task<string> shiftSave(List<ShiftDetails> SF)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (ShiftDetails ord in SF)
                {
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_production_shift_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ps_createdBy_compId", ord.ComID);
                    cmd.Parameters.AddWithValue("@ps_shift_name", ord.shiftName);
                    cmd.Parameters.AddWithValue("@ps_shift_startTime",ord.shiftstartTime.ToString("HH:mm"));
                    cmd.Parameters.AddWithValue("@ps_shift_endTime", ord.shiftendTime.ToString("HH:mm"));
                    cmd.Parameters.AddWithValue("@ps_created_by", ord.Created_by);
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
                _dg_Oder_Mgt.Close();
            }
            return message;
        }
        public async Task<string> Production_padding_save(List<ProductionModel> PD)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (ProductionModel ord in PD)
                {
                    SqlCommand cmd = new SqlCommand("dg_production_padding_add", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@createdBy_compId", ord.ComID);
                    cmd.Parameters.AddWithValue("@pp_id", ord.pp_ID);
                    cmd.Parameters.AddWithValue("@pp_or_id", ord.production_or_id);
                    cmd.Parameters.AddWithValue("@pp_or_ref_no", ord.production_or_refno);
                    cmd.Parameters.AddWithValue("@pp_padding_today_production_entry_qty", ord.production_padding_today_production_entry_qty);
                    cmd.Parameters.AddWithValue("@pp_quilting_today_production_entry_qty", ord.production_quilting_today_production_entry_qty);
                    cmd.Parameters.AddWithValue("@createdby", ord.createdby);


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
                _dg_Oder_Mgt.Close();
            }
            return message;
        }

    }
}
