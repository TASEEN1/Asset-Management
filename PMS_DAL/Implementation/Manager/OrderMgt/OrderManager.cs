using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using PMS_BOL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
            var data = await _SqlCommon.get_InformationDataTableAsync("select distinct cUnitCode , nUnitID from Smt_Unit", _SpecFoInventory);
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
    }
}
