using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.OrderMgt
{
    public class workOrder_Model
    {
        //Work_Order_Other_Attributes_Save
        public int wo_or_ref_no { get; set; }
        public string wo_remarks { get; set; }
        public int wo_thickness { get; set; }
        public int wo_wash_status { get; set; }
        public int wo_garments_type { get; set; }
        public int wo_heat_side { get; set; }
        public int wo_chemical_restriction { get; set; }
        public int wo_quilting_type { get; set; }
        public int wo_machine_type { get; set; }
        public int wo_quilting_design_name { get; set; }
        public int wo_quilting_design_dimension { get; set; }
        public int wo_spi { get; set; }
        public int wo_quilting_fabric_side { get; set; }
        public int wo_lining_usage { get; set; }
        public int wo_yarn_count { get; set; }
        public int wo_quilting_fabric_name { get; set; }
        public int wo_quilting_fabric_type { get; set; }
        public int wo_quilting_fabric_composition { get; set; }
        public string wo_test_name { get; set; }
        public string wo_created_by { get; set; }

        //Padding Type Save
        public int wopt_or_ref_no { get; set; }
        public int  wopt_padding_type { get; set; }
        public string wopt_created_by { get; set; }



    }
}














