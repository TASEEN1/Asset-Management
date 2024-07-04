using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using PMS_BOL.Models.OrderMgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public  class OrderManager:IOrderManager
    {

        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;



        public OrderManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);


        }

        public async Task<DataTable> GetPaymentType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT distinct Payment_Mode, PM_NO FROM dbo.Smt_PaymentMode", _specfo_conn);
            return data;
        }
        public async Task<DataTable> GetColor()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct c_color_name, c_id from dbo.dg_color", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetUnit()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct cUnitDes , nUnitID from Smt_Unit", _SpecFoInventory);
            return data;
        }
        public async Task<DataTable> GetItemDescription()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select id_id, id_item_name from dg_item_description", _dg_Oder_Mgt);
            return data;
        }
        public async Task<DataTable> GetProcessType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select it_id, it_process_name from dg_item_type", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> Getbuyer()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select b_id, b_buyer_name from dg_buyer", _dg_Oder_Mgt);

            return data;
        }

        public async Task<DataTable> GetCustomer()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select c_id, c_customer_name, c_att_person, c_att_mobile, c_terms_and_condition from dg_customer", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> GetDia()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select d_id, d_name from dg_dia", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> Getgsm()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select g_id, g_gsm from dg_gsm", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> Getdesign()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select des_id, des_name from dg_design", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> GetBuyerView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_buyer", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> GetcustomerView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_customer", _dg_Oder_Mgt);

            return data;
        }




        public async Task<DataTable> OrderReceivedAddView(int Customer, int Buyer, string Style_no)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_order_receiving_add_view " + Customer + "," + Buyer + ",'" + Style_no + "'", _dg_Oder_Mgt);
            return data;
        }

        public async Task<string> ColorSave(List<ColorSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (ColorSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_color_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@colorName", ord.ColorName);
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


        public async Task<string> OrderReceivedAdd(List<OrderReceivingAdd> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (OrderReceivingAdd ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_order_receiving_add", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@or_cust", ord.Customer);
                    cmd.Parameters.AddWithValue("@or_buyer", ord.Buyer);
                    cmd.Parameters.AddWithValue("@or_style_no", ord.style_no);
                    cmd.Parameters.AddWithValue("@or_po_no", ord.Po_no);
                    cmd.Parameters.AddWithValue("@or_att_name", ord.Att_name);
                    cmd.Parameters.AddWithValue("@or_att_mobile_no", ord.Att_mobile_no);
                    cmd.Parameters.AddWithValue("@or_att_email", ord.Att_email);
                    cmd.Parameters.AddWithValue("@or_item_desc", ord.Item_desc);
                    cmd.Parameters.AddWithValue("@or_item_color", ord.Item_color);
                    cmd.Parameters.AddWithValue("@or_design ", ord.Design);
                    cmd.Parameters.AddWithValue("@or_dia", ord.Dia);
                    cmd.Parameters.AddWithValue("@or_gsm", ord.Gsm);
                    cmd.Parameters.AddWithValue("@or_proc_type", ord.proc_type);
                    cmd.Parameters.AddWithValue("@or_order_qty", ord.Oder_qty);
                    cmd.Parameters.AddWithValue("@or_unit_price", ord.Unit_price);
                    cmd.Parameters.AddWithValue("@or_unit", ord.unit);
                    cmd.Parameters.AddWithValue("@or_total_price", ord.Total_price);
                    cmd.Parameters.AddWithValue("@or_payment_type", ord.Payment_type);
                    cmd.Parameters.AddWithValue("@or_cust_terms_cond", ord.Terms_condition);
                    cmd.Parameters.AddWithValue("@or_order_recv_date",ord.Ord_receive_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@or_order_deli_date", ord.Ord_delivery_date.ToString("yyyy-MM-dd"));
                    //cmd.Parameters.AddWithValue("@or_remarks", ord.Remarks);
                    cmd.Parameters.AddWithValue("@or_created_by", ord.CreatedBy);
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

        public async Task<string> OrderReceivedComplete(List<OrderReciveComplete> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (OrderReciveComplete ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_order_receiving_complete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@or_cust", ord.Customer);
                    cmd.Parameters.AddWithValue("@or_buyer", ord.Buyer);
                    cmd.Parameters.AddWithValue("@or_style_no", ord.Style_no);
                    cmd.Parameters.AddWithValue("@remarks", ord.Remarks);
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
        public async Task<string> ItemDescriptionSave(List<ItemDescriptionSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (ItemDescriptionSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_item_description_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemName", ord.ItemName);
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
        public async Task<string> ProcessTypeSave(List<ProcessTypeSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (ProcessTypeSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_item_type_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@procName", ord.processName);
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
        public async Task<string> BuyerSave(List<BuyerSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (BuyerSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_buyer_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@buyerName", ord.BuyerName);
                    cmd.Parameters.AddWithValue("@attPerson", ord.AttPerson);
                    cmd.Parameters.AddWithValue("@attEmail", ord.AttEmail);
                    cmd.Parameters.AddWithValue("@attMobile", ord.Attmobile_No);
                    cmd.Parameters.AddWithValue("@buyerAddress", ord.BuyerAddress);
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

        public async Task<string> CustomerSave(List<customerSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (customerSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_customer_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerName", ord.Cus_Name);
                    cmd.Parameters.AddWithValue("@attPerson", ord.AttPerson);
                    cmd.Parameters.AddWithValue("@attEmail", ord.AttEmail);
                    cmd.Parameters.AddWithValue("@attMobile", ord.Attmobile_No);
                    cmd.Parameters.AddWithValue("@customerAddress", ord.Cus_Address);
                    cmd.Parameters.AddWithValue("@customerTermsnCondition", ord.Cus_Terms_Condition);
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
        public async Task<string> DiaSave(List<diaSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (diaSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_dia_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@diaName", ord.DiaName);
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

        public async Task<string>GsmSave(List<gsmSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();
            try
            {
                foreach (gsmSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_gsm_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@gsmName", ord.GsmName);
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
        public async Task<string> DesignSave(List<designSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();
            try
            {
                foreach (designSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_design_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@designName ", ord.designName);
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
