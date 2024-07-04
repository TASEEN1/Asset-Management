using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models.OrderMgt
{
    public class ColorSave
    {
        public string ColorName { get; set; }
        public string createdby { get; set; }
    }



    public class ItemDescriptionSave
    {
        public string ItemName { get; set; }
        public string createdby { get; set; }
    }

    public class ProcessTypeSave
    {
        public string processName { get; set; }
        public string createdby { get; set; }
    }

    public class BuyerSave
    {
        public string BuyerName { get; set; }
        public string AttPerson { get; set; }
        public string AttEmail { get; set; }
        public string Attmobile_No { get; set; }
        public string BuyerAddress { get; set; }
        public string createdby { get; set; }

    }

    public class customerSave
    {
        public string Cus_Name { get; set; }
        public string AttPerson { get; set; }
        public string AttEmail { get; set; }
        public string Attmobile_No { get; set; }

        public string Cus_Address { get; set; }
        public string Cus_Terms_Condition { get; set; }
        public string createdby { get; set; }

    }

    public class diaSave
    {
        public string DiaName { get; set; }
        public string createdby { get; set; }
    }

    public class gsmSave
    {
        public string GsmName { get; set; }
        public string createdby { get; set; }
    }

    public class designSave
    {
        public string designName { get; set; }
        public string createdby { get; set; }
    }


}
