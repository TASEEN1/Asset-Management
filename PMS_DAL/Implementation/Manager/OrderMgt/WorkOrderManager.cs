using PMS_BLL.Interfaces.Manager.OrderMgt;
using PMS_BLL.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_DAL.Implementation.Manager.OrderMgt
{
    public class WorkOrderManager: IworkOrderManager
    {
       
            private readonly Dg_SqlCommon _SqlCommon;
            private readonly SqlConnection _specfo_conn;
            private readonly SqlConnection _dg_Asst_Mgt;
            private readonly SqlConnection _SpecFoInventory;
            private readonly SqlConnection _dg_Oder_Mgt;

            public WorkOrderManager(Dg_SqlCommon sqlCommon)
            {
                _SqlCommon = sqlCommon;
                _specfo_conn = new SqlConnection(Dg_Getway.SpecFoCon);
                _dg_Asst_Mgt = new SqlConnection(Dg_Getway.dg_Asst_Mgt);
                _SpecFoInventory = new SqlConnection(Dg_Getway.SpecFoInventory);
                _dg_Oder_Mgt = new SqlConnection(Dg_Getway.dg_Oder_Mgt);

            }



        }
}
