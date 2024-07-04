using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.OrderMgt
{
    public class OrderReceivingAdd
    {
        public int Customer { get; set; }
        public int Buyer { get; set; }
        public string style_no { get; set; }
        public string Po_no { get; set; }
        public string Att_name { get; set; }
        public string Att_mobile_no { get; set; }
        public string Att_email { get; set; }
        public int Item_desc { get; set; }
        public int Item_color { get; set; }
        public int Design { get; set; }
        public int Dia { get; set; }
        public int Gsm { get; set; }
        public int proc_type { get; set; }

        public decimal Oder_qty { get; set; }
        public decimal Unit_price { get; set; }
        public int unit { get; set; }
        public decimal Total_price { get; set; }
        public int Payment_type { get; set; }
        public string Terms_condition { get; set; }
        public DateTime Ord_receive_date { get; set; }
        public DateTime Ord_delivery_date { get; set; }
        public string Remarks { get; set; }
        public string CreatedBy { get; set; }
    }
}
