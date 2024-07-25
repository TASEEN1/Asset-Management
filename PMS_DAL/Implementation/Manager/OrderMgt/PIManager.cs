using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
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
    public class PIManager: IPIManager
    {


        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        public PIManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }

        public async Task<string> GeneratePIAdd(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_add", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@or_id", ord.or_id);
                    cmd.Parameters.AddWithValue("@or_po_no", ord.Po_No);
                    cmd.Parameters.AddWithValue("@or_style_no", ord.Style_No);
                    cmd.Parameters.AddWithValue("@or_ref_no", ord.Ref_no);
                    cmd.Parameters.AddWithValue("@pi_created_by", ord.Created_by);
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

        public async Task<string> GeneratePI(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_generate", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_id", ord.Pi_id);
                    cmd.Parameters.AddWithValue("@pi_or_id", ord.pi_or_id);
                    cmd.Parameters.AddWithValue("@paymentType", ord.payment_Type);
                    cmd.Parameters.AddWithValue("@pi_created_by", ord.Created_by);
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

        public async Task<DataTable> GetGeneratePIAddView(int Customer, int Buyer, string created_By)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_add_view " + Customer + "," + Buyer + ",'" + created_By + "'", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPIAddView(int Customer, string style, int Ref_no)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_before_add_view " + Customer + ", '" + style + "', " + Ref_no , _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPiApproval_checkedBy_View(string  Created_by)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_approval_checkedBy_view " + Created_by + "", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPiApproval_approvedBy_view(string Created_by)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_approval_approvedBy_view " + Created_by + "", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPiApproval_ForApprovalView(string Created_by)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_approval_forApproval_view "  + Created_by + "", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPiApproval_revise_view(string Created_by)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_generate_pi_approval_revise_view " + Created_by + "", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPIcustomer()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct or_cust, c_customer_name from dg_order_receiving inner join dg_customer on or_cust = c_id where or_com_post_bit = 1 and or_pi_add_bit = 0 and or_pi_revise_bit = 0", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetPIstyle(int custId)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct or_style_no, or_ref_no from dg_order_receiving where or_com_post_bit = 1 and or_pi_add_bit = 0 and or_pi_revise_bit = 0 and or_cust = " +  custId, _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetPI_Number()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct pi_number, pi_issued_ref_no from dg_pi_issued", _dg_Oder_Mgt);
            return data;
        }

        public async Task<string> PIDelete(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_add_delete_single", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@piID", ord.Pi_id);
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

        public async Task<string> PIRevise(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_approval_revise", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_issued_ref_no", ord.Ref_no);
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

        public async Task<string> ApprovedByApprove(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_approval_approvedBy_approve", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_issued_ref_no", ord.Ref_no);
                    cmd.Parameters.AddWithValue("@pi_approvedBy_user", ord.pi_approvedBy_user);
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

        public async Task<string> CheckedByApprove(List<PI_Model> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (PI_Model ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_generate_pi_approval_checkedBy_approve", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pi_issued_ref_no", ord.Ref_no);
                    cmd.Parameters.AddWithValue("@pi_checkedBy_user", ord.pi_checkedBy_user);
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
