using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public class DeliveryChallanManager:IDeliveryChallanManager
    {
        private readonly Dg_SqlCommon _SqlCommon;
        private readonly SqlConnection _specfo_conn;
        private readonly SqlConnection _dg_Asst_Mgt;
        private readonly SqlConnection _SpecFoInventory;
        private readonly SqlConnection _dg_Oder_Mgt;

        public DeliveryChallanManager(Dg_SqlCommon sqlCommon)
        {
            _SqlCommon = sqlCommon;
            _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
            _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
            _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
            _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

        }
        //Common 
        //GetDelivery_Challan_PINumber(customer wise)
        public async Task<DataTable> GetDelivery_Challan_PINumber(string PI_Number, int custParamForPI, int pageProcId, int itemProcId)
        {
            var query = $"dg_delivery_challan_GetPICustwise '{PI_Number}',{custParamForPI},{pageProcId},{itemProcId}";
            var data = await _SqlCommon.get_InformationDataTableAsync(query, _dg_Oder_Mgt);
            return data;
        }

        //-------Padding------//

        //Drop Down
        public async Task<DataTable> GetPadding_Challan_ProcessType()
        {
            var data = await _SqlCommon.get_InformationDataTableAsync("select pt_id, pt_process_name from dg_dimtbl_process_type where pt_id not in (2) ", _dg_Oder_Mgt);
            return data;
        }

    }
}
