using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.OrderMgt
{
    public class PI_Model
    {
        public int Pi_id { get; set; }
        public int pi_or_id { get; set; }
        public string Po_No { get; set; }
        public string Style_No { get; set;}

        public int Ref_no { get; set; }
        public string Created_by { get; set; }

    }
}
