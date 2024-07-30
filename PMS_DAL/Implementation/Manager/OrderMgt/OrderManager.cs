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
            var data = await _SqlCommon.get_InformationDataTableAsync("SELECT pm_id, Payment_Mode  FROM dbo.Smt_PaymentMode where pm_id in (1,2) ", _specfo_conn);
            return data;
        }
        public async Task<DataTable> GetColor()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct c_color_name, c_id as color_id from dbo.dg_dimtbl_color", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetUnit()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct cUnitDes , nUnitID from Smt_Unit", _SpecFoInventory);
            return data;
        }
        public async Task<DataTable> GetItemName()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_dimtbl_item_name", _dg_Oder_Mgt);
            return data;
        }
      

        public async Task<DataTable> GetBuyer()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select b_id, b_buyer_name from dg_dimtbl_buyer where b_active = 1", _dg_Oder_Mgt);

            return data;
        }

        public async Task<DataTable> GetCustomer()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select c_id as customer_id, c_customer_name, c_att_person, c_att_mobile,c_att_email, c_terms_and_condition from dg_dimtbl_customer where c_active = 1", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> GetCustomerEdit()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct or_cust, c_id as customer_id, c_customer_name, c_att_person, c_att_mobile,c_att_email, c_terms_and_condition " +
                "from dg_order_receiving inner join dg_dimtbl_customer on or_cust = c_id where c_active = 1 and or_com_post_bit = 1 and or_pi_add_bit = 0 ", _dg_Oder_Mgt);

            return data;
        }
    public async Task<DataTable> GetDia()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select d_id, d_name from dg_dimtbl_dia", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> Getgsm()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select g_id,g_gsm from dg_dimtbl_gsm", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> Getdesign()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select des_id, des_name from dg_dimtbl_design", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> GetBuyerView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_dimtbl_buyer where b_active = 1", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> GetcustomerView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select c_id as customer_id , c_customer_name,c_address,c_att_person, c_att_mobile,c_att_email ,c_terms_and_condition,c_created_by, c_created_date, c_updated_by, c_updated_date from dg_dimtbl_customer where c_active = 1", _dg_Oder_Mgt);

            return data;
        }

        public async Task<DataTable> GetcolorView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select c_id as color_id, c_color_name , c_created_by ,c_created_date , c_updated_by , c_updated_date from dg_dimtbl_color", _dg_Oder_Mgt);

            return data;
        }

        public async Task<DataTable> GetdesignView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_dimtbl_design", _dg_Oder_Mgt);

            return data;
        }
        public async Task<DataTable> GetDiaView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_dimtbl_dia", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetgsmView()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_dimtbl_gsm", _dg_Oder_Mgt);
            return data;
        }
        //public async Task<DataTable> GetitemView()
        //{
        //    var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_dimtbl_item_description", _dg_Oder_Mgt);
        //    return data;
        //}
        //public async Task<DataTable> GetprocessTypeview()
        //{
        //    var data = await _SqlCommon.get_InformationDataTableAsync("select * from dg_dimtbl_process_type", _dg_Oder_Mgt);
        //    return data;
        //}
        public async Task<DataTable> Getpayment_currency()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select cCurID, cCurdes from SpecFo_Inventory.dbo.Smt_CurencyType where cCurID in (1,4)", _dg_Oder_Mgt);
            return data;
        }


        public async Task<DataTable> GetStyleEdit(int custID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct or_ref_no, or_style_no from dg_order_receiving where  or_com_post_bit = 1 and or_pi_add_bit = 0 and or_cust = '" + custID +"'", _dg_Oder_Mgt);
            return data;
        }

       
        public async Task<DataTable> OrderReceivedAddView(string sessionUser)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_order_receiving_add_order_view " + sessionUser + "", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetOrderReceivedAddEditView(int Customer, int Buyer, string Style_no, int Ref_no)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("dg_order_receiving_add_edit_order_view " + Customer + "," + Buyer + ",'" + Style_no +  "'," + Ref_no + "", _dg_Oder_Mgt);
            return data;
        }

        public async Task<DataTable> GetRefNoFromOrderReceiving()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct or_ref_no from dg_order_receiving where or_ref_no not in (0) order by or_ref_no desc", _dg_Oder_Mgt);
            return data;
        }


        //Report Get :

        public async Task<DataTable> GetReport_Customer()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct or_cust, c_customer_name FROM dbo.dg_order_receiving inner join dg_dimtbl_customer on or_cust = dg_dimtbl_customer.c_id where or_com_post_bit=1", _dg_Oder_Mgt);
            return data;
        }


        public async Task<DataTable> GetReport_Style(int custID)
        {
            var data = await _SqlCommon.get_InformationDataTableAsync(" select distinct or_style_no,or_ref_no FROM  dbo.dg_order_receiving inner join dg_dimtbl_customer on or_cust = dg_dimtbl_customer.c_id where or_com_post_bit=1 and or_cust = '" + custID + "'", _dg_Oder_Mgt);
            return data;
        }
        //----------------------//---------

        public async Task<string> ColorSave(List<ColorSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (ColorSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_color_save", _dg_Oder_Mgt);
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
                    SqlCommand cmd = new SqlCommand("dg_order_receiving_add_order_add", _dg_Oder_Mgt);
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
                    //cmd.Parameters.AddWithValue("@or_design ", ord.Design);
                    cmd.Parameters.AddWithValue("@or_dia", ord.Dia);
                    cmd.Parameters.AddWithValue("@or_gsm", ord.Gsm);
                    //cmd.Parameters.AddWithValue("@or_proc_type", ord.proc_type);
                    cmd.Parameters.AddWithValue("@or_order_qty", ord.Oder_qty);
                    cmd.Parameters.AddWithValue("@or_unit_price", ord.Unit_price);
                    cmd.Parameters.AddWithValue("@or_unit", ord.unit);
                    cmd.Parameters.AddWithValue("@or_total_price", ord.Total_price);
                    cmd.Parameters.AddWithValue("@or_item_HS_code", ord.Hs_code);
                    //cmd.Parameters.AddWithValue("@or_cust_terms_cond", ord.Terms_condition);
                    cmd.Parameters.AddWithValue("@or_order_recv_date",ord.Ord_receive_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@or_order_deli_date", ord.Ord_delivery_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@or_created_by", ord.CreatedBy);
                    cmd.Parameters.AddWithValue("@or_order_net_weight", ord.or_order_net_weight);
                    cmd.Parameters.AddWithValue("@or_order_gross_weight", ord.or_order_gross_weight);
                    cmd.Parameters.AddWithValue("@or_payment_currency", ord.or_payment_currency);
                    cmd.Parameters.AddWithValue("@or_item_name", ord.item_Name);
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
                    SqlCommand cmd = new SqlCommand("dg_order_receiving_add_order_complete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@or_created_by",ord.or_created_by);
                    //cmd.Parameters.AddWithValue("@or_buyer", ord.Buyer);
                    //cmd.Parameters.AddWithValue("@or_style_no", ord.Style_no);
                    //cmd.Parameters.AddWithValue("@remarks", ord.Remarks);
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
        public async Task<string> ItemNameSave(List<ItemDescriptionSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (ItemDescriptionSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_item_name_save", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@itemName", ord.ItemName);
                    cmd.Parameters.AddWithValue("@HSCode", ord.HSCode);
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
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_process_type_save", _dg_Oder_Mgt);
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
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_buyer_save", _dg_Oder_Mgt);
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
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_customer_save", _dg_Oder_Mgt);
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
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_dia_save", _dg_Oder_Mgt);
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
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_gsm_save", _dg_Oder_Mgt);
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
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_design_save", _dg_Oder_Mgt);
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

        public async Task<string> OrderReceiveDelete(List<orderReceiveDelete> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();
            try
            {
                foreach (orderReceiveDelete ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_order_receiving_add_order_detete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", ord.id);
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
        public async Task<string> OrderReceiveEditUpdate(List<OrderReceivingAdd> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (OrderReceivingAdd ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_order_receiving_add_edit_order_update", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", ord.Id);
                    cmd.Parameters.AddWithValue("@or_cust", ord.Customer);
                    cmd.Parameters.AddWithValue("@or_buyer", ord.Buyer);
                    cmd.Parameters.AddWithValue("@or_style_no", ord.style_no);
                    cmd.Parameters.AddWithValue("@or_po_no", ord.Po_no);
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
                    cmd.Parameters.AddWithValue("@or_item_HS_code", ord.Hs_code);
                    cmd.Parameters.AddWithValue("@or_order_recv_date", ord.Ord_receive_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@or_order_deli_date", ord.Ord_delivery_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@or_updated_by", ord.UpdatedBy);
                    cmd.Parameters.AddWithValue("@or_order_net_weight", ord.or_order_net_weight);
                    cmd.Parameters.AddWithValue("@or_order_gross_weight", ord.or_order_gross_weight);
                    cmd.Parameters.AddWithValue("@or_payment_currency", ord.or_payment_currency);
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
        public async Task<string> CustomerDelete(List<customerSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();
            try
            {
                foreach (customerSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_customer_detete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id",ord.customerId);
                    cmd.Parameters.AddWithValue("@updatedBy", ord.UpdatedBy);
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
        public async Task<string> CustomerUpdate(List<customerSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (customerSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_customer_update", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custId", ord.customerId);
                    //cmd.Parameters.AddWithValue("@customerName", ord.Cus_Name);
                    cmd.Parameters.AddWithValue("@attPerson", ord.AttPerson);
                    cmd.Parameters.AddWithValue("@attEmail", ord.AttEmail);
                    cmd.Parameters.AddWithValue("@attMobile", ord.Attmobile_No);
                    cmd.Parameters.AddWithValue("@customerAddress", ord.Cus_Address);
                    cmd.Parameters.AddWithValue("@customerTermsnCondition", ord.Cus_Terms_Condition);
                    cmd.Parameters.AddWithValue("@updatedBy", ord.UpdatedBy);
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

        public async Task<string> BuyerUpdate(List<BuyerSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (BuyerSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_buyer_update", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@buyerId", ord.BuyerID);
                    //cmd.Parameters.AddWithValue("@buyerName", ord.BuyerName);
                    cmd.Parameters.AddWithValue("@attPerson", ord.AttPerson);
                    cmd.Parameters.AddWithValue("@attEmail", ord.AttEmail);
                    cmd.Parameters.AddWithValue("@attMobile", ord.Attmobile_No);
                    cmd.Parameters.AddWithValue("@buyerAddress", ord.BuyerAddress);
                    cmd.Parameters.AddWithValue("@updatedBy", ord.updatedby);
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
        public async Task<string> BuyerDelete(List<BuyerSave> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (BuyerSave ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_dimtbl_buyer_detete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id ", ord.BuyerID);
                    cmd.Parameters.AddWithValue("@updatedBy", ord.updatedby);
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

        public async Task<string> OrderReceiveEditAdd(List<OrderReceivingAdd> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (OrderReceivingAdd ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_order_receiving_add_edit_order_add", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@or_cust", ord.Customer);
                    cmd.Parameters.AddWithValue("@or_buyer", ord.Buyer);
                    cmd.Parameters.AddWithValue("@or_style_no", ord.style_no);
                    cmd.Parameters.AddWithValue("@or_po_no", ord.Po_no);
                    cmd.Parameters.AddWithValue("@or_ref_no", ord.Ref_no);
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
                    cmd.Parameters.AddWithValue("@or_item_HS_code", ord.Hs_code);
                    cmd.Parameters.AddWithValue("@or_cust_terms_cond", ord.Terms_condition);
                    cmd.Parameters.AddWithValue("@or_order_recv_date", ord.Ord_receive_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@or_order_deli_date", ord.Ord_delivery_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@or_created_by", ord.CreatedBy);
                    cmd.Parameters.AddWithValue("@or_order_net_weight", ord.or_order_net_weight);
                    cmd.Parameters.AddWithValue("@or_order_gross_weight", ord.or_order_gross_weight);
                    cmd.Parameters.AddWithValue("@or_payment_currency", ord.or_payment_currency);
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
        public async Task<string> OrderReceiveAddOrderUpdate(List<OrderReceivingAdd> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();

            try
            {
                foreach (OrderReceivingAdd ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_order_receiving_add_order_update", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", ord.Id);
                    cmd.Parameters.AddWithValue("@or_cust", ord.Customer);
                    cmd.Parameters.AddWithValue("@or_buyer", ord.Buyer);
                    cmd.Parameters.AddWithValue("@or_style_no", ord.style_no);
                    cmd.Parameters.AddWithValue("@or_po_no", ord.Po_no);
                    cmd.Parameters.AddWithValue("@or_item_desc", ord.Item_desc);
                    cmd.Parameters.AddWithValue("@or_item_HS_code", ord.Hs_code);
                    cmd.Parameters.AddWithValue("@or_item_color", ord.Item_color);
                    cmd.Parameters.AddWithValue("@or_design ", ord.Design);
                    cmd.Parameters.AddWithValue("@or_dia", ord.Dia);
                    cmd.Parameters.AddWithValue("@or_gsm", ord.Gsm);
                    cmd.Parameters.AddWithValue("@or_proc_type", ord.proc_type);
                    cmd.Parameters.AddWithValue("@or_order_qty", ord.Oder_qty);
                    cmd.Parameters.AddWithValue("@or_unit_price", ord.Unit_price);
                    cmd.Parameters.AddWithValue("@or_unit", ord.unit);
                    cmd.Parameters.AddWithValue("@or_total_price", ord.Total_price);
                    cmd.Parameters.AddWithValue("@or_order_recv_date", ord.Ord_receive_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@or_order_deli_date", ord.Ord_delivery_date.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@or_updated_by", ord.UpdatedBy);
                    cmd.Parameters.AddWithValue("@or_order_net_weight", ord.or_order_net_weight);
                    cmd.Parameters.AddWithValue("@or_order_gross_weight", ord.or_order_gross_weight);
                    cmd.Parameters.AddWithValue("@or_payment_currency", ord.or_payment_currency);
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

        public async Task<string> OrderReceiveAddEditComplete(List<OrderReciveComplete> app)
        {
            string message = string.Empty;
            await _dg_Oder_Mgt.OpenAsync();


            try
            {
                foreach (OrderReciveComplete ord in app)
                {
                    SqlCommand cmd = new SqlCommand("dg_order_receiving_add_edit_order_complete", _dg_Oder_Mgt);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@or_cust", ord.Customer);
                    cmd.Parameters.AddWithValue("@or_buyer", ord.Buyer);
                    cmd.Parameters.AddWithValue("@or_style_no", ord.Style_no);
                    cmd.Parameters.AddWithValue("@or_ref_no",ord.Ref_No);
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

    }
}
