using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IDeliveryChallanManager
    {

        //Common 
        //GetDelivery_Challan_PINumber(customer wise)
        public Task<DataTable> GetDelivery_Challan_PINumber( string PI_Number , int custParamForPI, int pageProcId,int itemProcId);


        //-------Padding------//

        //Drop Down

        public Task<DataTable> GetPadding_Challan_ProcessType();



    }
}
