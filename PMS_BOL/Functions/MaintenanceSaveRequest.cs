using PMS_BOL.Models;
using System;
using System.Collections.Generic;
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
}
