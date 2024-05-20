using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models
{
    public class AssetForApprove
    {
        public string AssetNo { get; set; }
        public string Appby { get; set; }

     



    }

    public class AssetReturnCancel
    {
        public string AssetNo { get; set; }
        public string CancelBy { get; set; }
    }
}
