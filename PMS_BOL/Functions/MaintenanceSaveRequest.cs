using PMS_BOL.Models.Asset_Mgt;
using PMS_BOL.Models.OrderMgt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Functions
{
    public class MaintenanceSaveRequest 
    {
        public List<ScheduleMaintenanceModel> ScheduleMaintenanceModels { get; set; }
        public List<SMServiceTypeSave_Model> SMServiceTypeSaveModels { get; set; }

    }
    public class WorkorderSaveRequest
    {
        public List<workOrder_Model> workOrder_Models { get; set; }
        public List<PaddingType> paddingTypes { get; set; }
    }
    public class WorkorderUpdateRequest
    {
        public List<Work_Order_Update_Delete>work_Order_Update_Deletes { get; set; }
        public List<workOrder_Model> workOrder_Models { get; set; }
        public List<PaddingType>paddingTypes { get; set; }
        
    }

  

}
