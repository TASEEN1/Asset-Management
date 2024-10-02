using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.Order_Mgt
{
    public  class RawmaterialModel
    {  
        public int ComID { get; set; }
        public int Paddingrm_mainCetegory { get; set; }

        public int Paddingrm_subCategory { get; set; }
        public DateTime production_Date { get; set; }
        public string paddingrm_Created_by { get; set; }
        public int Paddingrm_Mc_pad { get; set; }
        public decimal Paddingrm_qty { get; set; }
        public string Paddingrm_remarks { get; set;}




    }
}
