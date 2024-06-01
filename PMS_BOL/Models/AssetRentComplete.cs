using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMS_BOL.Models
{
    public class AssetRentComplete
    {
        public int ReturnRefNo { get; set; }
        public DateTime ReturnDate { get; set; }
        public string ReturnUser { get; set; }
    }
    public class RentAssetAdd
    {
        public string RentAssetNo { get; set; }
    }
}
