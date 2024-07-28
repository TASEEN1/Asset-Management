using PMS_BOL.Models.OrderMgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BLL.Interfaces.Manager.OrderMgt
{
    public interface IworkOrderManager
    {
        // Padding Section
        public Task<DataTable>GetPadding_Type();
        public Task<DataTable> GetPadding_Thickness();
        public Task<DataTable> GetPadding_Washstatus();
        public Task<DataTable> GetPadding_GarmentsType();
        public Task<DataTable> GetPadding_HeatSide();
        public Task<DataTable> GetPadding_Chemical_Restriction();


        //Quilting Section
        public Task<DataTable> GetQuilting_Type();
        public Task<DataTable> GetQuilting_MachineType();
        public Task<DataTable> GetQuilting_DesignName();
        public Task<DataTable> GetQuilting_Design_Dimension();
        public Task<DataTable> GetQuilting_Stitch_PerInch();
        public Task<DataTable> GetQuilting_FabricSide();
        public Task<DataTable> GetQuilting_Lining_Usage();
        public Task<DataTable> GetQuilting_Yarn_Count();
        public Task<DataTable> GetQuilting_FabricName();
        public Task<DataTable> GetQuilting_FabricType();
        public Task<DataTable> GetQuilting_Fabric_Composition();


        //work_Order
        public Task<string> Work_Order_Other_Attributes_Save(List<workOrder_Model> app);
        public Task<string> Work_Order_Padding_Type_Save(List<workOrder_Model> app);























    }
}
