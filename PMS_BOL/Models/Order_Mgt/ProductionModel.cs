using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.Order_Mgt
{
    public class ProductionModel
    {
        public int ComID { get; set; }
        public int pp_ID { get; set; }
        public int production_or_id { get; set; }
        public int production_or_refno { get; set; }

        public decimal production_padding_today_production_entry_qty { get; set; }
        public decimal production_quilting_today_production_entry_qty { get; set; }
        public string createdby { get; set; }
        

    }

    public class MachineDetails
    { 
        public int ComID { get; set; }
        public string machine_Name { get; set; }
        public string machine_No { get; set; }
        public int machine_capacity { get; set; }
        public string Created_by { get; set;}


    }

    public class  ShiftDetails
    {
        public int ComID { get; set; }
        public string shiftName { get; set; }
        public DateTime shiftstartTime { get; set; }
        public DateTime shiftendTime { get; set;}
        public string Created_by { get; set; }

    }
}
